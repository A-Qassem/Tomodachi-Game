using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tomodachi_Game_Server;
using System.Runtime.InteropServices;

namespace Tomodachi_Game_Server
{
    class Server
    {
        internal TcpListener? listener;
        internal Dictionary<string, TcpClient> PlayersConnections = new();
        internal Dictionary<string, Room> Rooms = new();

        private Queue<(string request, TcpClient client)> requestQueue = new();
        private readonly object queueLock = new();
        private bool isProcessing = false;

        public void StartServer()
        {
            listener = new TcpListener(IPAddress.Any, 5000);
            listener.Start();
            Console.WriteLine("Server started on port 5000...");

            Task.Run(ProcessQueue); 

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Task.Run(() => HandleClient(client));
            }
        }

        internal void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];

            try
            {
                while (client.Connected)
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    string request = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine($"Received: {request}");

                    lock (queueLock)
                    {
                        requestQueue.Enqueue((request, client));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Client disconnected: " + ex.Message);
            }

            client.Close();
        }
        private void ProcessQueue()
        {
            while (true)
            {
                if (requestQueue.Count > 0)
                {
                    lock (queueLock)
                    {
                        if (requestQueue.Count > 0)
                        {
                            var task = requestQueue.Dequeue();
                            ProcessRequest(task.request, task.client);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
        }
        internal void ProcessRequest(string request, TcpClient client)
        {
            string[] parts = request.Split(' ');
            if (parts.Length < 2)
            {
                SendMessageToClient(client, "INVALID_REQUEST");
                return;
            }
            string command = parts[0];
            string playerId = parts[1];

            switch (command)
            {
                case "CHECK":
                    SendMessageToClient(client, CheckPlayerId(playerId));
                    break;
                case "DISCONNECT":
                    DisconectPlayer(playerId, client);
                    break;
                case "REGISTER":
                    SendMessageToClient(client, RegisterPlayer(playerId, parts[2], client));
                    break;
                case "CREATE_ROOM":
                    CreateRoom(playerId);
                    break;
                case "JOIN_ROOM":
                    JoinRoom(playerId, parts[2]);
                    break;
                case "START":
                    RoomStartGame(parts[1]);
                    break;
                case "PLAYERS_NUM":
                    SendMessageToClient(client, Rooms[parts[1]].Players.Count.ToString());
                    break;
                case "MY_TURN":
                    Rooms[parts[2]].TellPlayersTheirTurn(client, parts[1], this);
                    break;
                case "WORD":
                    SendMessageToClient(client, Rooms[parts[1]].Word.Length.ToString());
                    break;
                case "GUESS":
                    Rooms[parts[2]].CheckGuess(this, parts[1], parts[3]);
                    break;
                case "READY":
                        Rooms[parts[1]].PlayerReady(parts[2], this);
                    break;
                default:
                    SendMessageToClient(client, "UNKNOWN_COMMAND");
                    break;
            }
        }

        internal void SendMessageToClient(TcpClient client, string message)
        {
            NetworkStream stream = client.GetStream();
            byte[] data = Encoding.UTF8.GetBytes(message);
            stream.Write(data, 0, data.Length);
        }

        internal void DisconectPlayer(string playerId, TcpClient client)
        {
            client.Close();
            PlayersConnections.Remove(playerId);
            foreach (var room in Rooms)
            {
                if (room.Value.Players.Contains(playerId))
                {
                    room.Value.RemovePlayer(playerId, this);
                }
            }
        }

        internal void RoomStartGame(string roomId)
        {
            if (Rooms.ContainsKey(roomId))
            {
                Rooms[roomId].GoToHowToHowPlay(this);
            }
        }

        internal void JoinRoom(string playerId, string roomId)
        {
            if (!Rooms.ContainsKey(roomId))
            {
                SendMessageToClient(PlayersConnections[playerId], "ROOM_NOT_FOUND");
                return;
            }
            string ret = Rooms[roomId].JoinToRoom(playerId, this);
            SendMessageToClient(PlayersConnections[playerId], ret);
        }

        internal void CreateRoom(string playerId)
        {
            string roomId = GenerateRandomId();
            while (Rooms.ContainsKey(roomId))
            {
                roomId = GenerateRandomId();
            }
            Room room = new Room(roomId, playerId);
            Rooms[roomId] = room;
            Console.WriteLine($"Room :{roomId} is running");
       
            SendMessageToClient(PlayersConnections[playerId], $"ROOM_ID {roomId}");
        }
        public string GenerateRandomId()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        internal string CheckPlayerId(string playerId)
        {
            return PlayersConnections.ContainsKey(playerId) ? "ID Exists" : "ID Not Exists";
        }

        internal string RegisterPlayer(string playerId, string playerName, TcpClient client)
        {
            if (PlayersConnections.ContainsKey(playerId))
                return "ID Already Registered";

            PlayersConnections.Add(playerId, client);
            return "Player Registered";
        }
    }
    public class Room
    {
        public string RoomId { get; }
        public string OwnerId { get; }
        internal List<string> Players = new();
        List<string> Alive;
        public bool IsStarted { get; internal set; } = false;
        public int Round { get; internal set; }
        public int Ready { get; internal set; }
        public string Word { get; set; }

        List<string> Words = new List<string> { "apple", "banana", "cherry", "date", "elderberry", "fig", "grape", "honeydew", "kiwi", "lemon", "mango", "nectarine", "orange", "papaya", "quince", "raspberry", "strawberry", "tangerine", "watermelon" };
        public Room(string roomId, string ownerId)
        {
            RoomId = roomId;
            OwnerId = ownerId;
            Players.Add(ownerId);
            Ready = 0;
        }

        internal string JoinToRoom(string playerId, Server server)
        {
            if (Players.Count == 3)
                return "ROOM_FULL";
            if (IsStarted)
                return "ROOM_RUNNING";

            this.Players.Add(playerId);
            TellAllPlayers(server, "ADD");
            return "JOINED_ROOM " + RoomId;
        }
        internal void TellAllPlayers(Server server, string message)
        {
            foreach (string player in Players)
            {
                server.SendMessageToClient(server.PlayersConnections[player], message);
            }
        }
        internal string GoToHowToHowPlay(Server server)
        {
            if (Players.Count < 1)
                return "PLAYERS_NOT_ENOUGH";
            else
            {
                foreach (var player in Players)
                {
                    if (player != OwnerId)
                        server.SendMessageToClient(server.PlayersConnections[player], "RUN_HOW_TO_PLAY");
                }
                IsStarted = true;
                Alive = Players;
                Ready = 0;
                Round = 0;
                return "GAME_STARTED";
            }
        }

        internal void RemovePlayer(string playerId, Server server)
        {
            Players.Remove(playerId);
            if (playerId == OwnerId)
            {
                TellAllPlayers(server, "LEAVE");
                server.Rooms.Remove(this.RoomId);
                Console.WriteLine($"Room {RoomId} colsed");
            }
            else
                TellAllPlayers(server, "REMOVE");
        }
        int CountCommonCharacters(string a, string b)
        {
            HashSet<char> setA = new HashSet<char>(a);
            HashSet<char> setB = new HashSet<char>(b);

            setA.IntersectWith(setB);
            return setA.Count;
        }
        void ShuffleList<T>(ref List<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            for (int i = n - 1; i > 0; i--)
            {
                int j = rng.Next(0, i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }
        internal string NextRound(Server server)
        {
            foreach (var player in Alive)
            {
                if (player == Alive[Round - 1])
                {
                    server.SendMessageToClient(server.PlayersConnections[player], "YOUR_TURN");
                }
                else
                {
                    server.SendMessageToClient(server.PlayersConnections[player], "NOT_YOUR_TURN");
                }
            }
            return "Done";
        }

        internal string PlayerReady(string playerId, Server server)
        {
            Ready++;
            Console.WriteLine(Ready);
            TellAllPlayers(server, $"READY {Ready}");
            Thread.Sleep(1000);
            if (Ready == Players.Count)
            {
                this.StartGamePlay(server);
                return "Done";
            }
            return "Ready";
        }


        private void StartGamePlay(Server server)
        {
            ShuffleList(ref Alive);
            Console.WriteLine("game start");
            TellAllPlayers(server, "START_GAME_PLAY");
            Word = Words[new Random().Next(0, Words.Count)];
            TellAllPlayers(server, $"WORD {Word.Length}");

        }

        internal void TellPlayersTheirTurn(TcpClient client, string playerId, Server server)
        {
                server.SendMessageToClient(client, $"TURN {Alive[Round]}");
        }

        internal void CheckGuess(Server server, string playerId, string guess)
        {
            TellAllPlayers(server, $"GUESS {CountCommonCharacters(guess, Word)} {guess}");
            if (Word == guess.ToLower())
            {
                TellAllPlayers(server, $"WIN {playerId}");
            }
            else
            {
                Round++;
                if (Round == Alive.Count)
                {
                    TellAllPlayers(server, $"WIN -1");
                }
                
                TellAllPlayers(server, $"TURN {Alive[Round]}");
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Server server = new Server();
        server.StartServer();
    }
}
