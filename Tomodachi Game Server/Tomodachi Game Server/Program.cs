using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tomodachi_Game_Server;

namespace Tomodachi_Game_Server
{
    class Server
    {
        internal TcpListener listener;
        internal Dictionary<string, TcpClient> PlayersConnections = new();
        internal Dictionary<string, Room> Rooms = new();

        public void StartServer()
        {
            listener = new TcpListener(IPAddress.Any, 5000);
            listener.Start();
            Console.WriteLine("Server started on port 5000...");

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
                    ProcessRequest(request, client);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Client disconnected: " + ex.Message);
            }

            client.Close();
        }

        internal void ProcessRequest(string request, TcpClient client)
        {
            string[] parts = request.Split(' ');
            if (parts.Length < 2)
            {
                SendMessageToClient(client, "INVALID_REQUEST");
                return;
            }

            Console.WriteLine(request);
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
                case "Round_Num":
                    SendMessageToClient(client, Rooms[parts[1]].Round.ToString());
                    break;
                case "CHECK_GUESS":
                    Rooms[parts[2]].GuessIsTrue(parts[3], this);
                    break;
                case "WORD":
                    SendMessageToClient(client, Rooms[parts[1]].Word.Length.ToString());
                    break;
                case "NEXT_ROUND":
                    Rooms[parts[1]].NextRound(this);
                    break;
                case "READY":
                    if (parts.Length >= 3)
                        Rooms[parts[1]].PlayerReady(parts[2], this);
                    else
                        SendMessageToClient(client, "INVALID_REQUEST");
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
        List<string> Alive, Dead;
        public bool IsStarted { get; internal set; } = false;
        public int Round { get; internal set; }
        public int Ready { get; internal set; }
        public string Word { get; set; }

        public Room(string roomId, string ownerId)
        {
            RoomId = roomId;
            OwnerId = ownerId;
            Players.Add(ownerId);
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
                Dead = new List<string>();
                Ready = 0;
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

        internal string GuessIsTrue(string guess, Server server)
        {
            if (guess == Word)
            {

                return "TRUE";
            }
            return $"FALSE {CountCommonCharacters(Word, guess)}";
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
            if (Ready == Players.Count)
            {
                ShuffleList(ref Alive);
                Console.WriteLine("game start");
                this.StartGamePlay(server);
                return "Done";
            }
            TellAllPlayers(server, $"READY {Ready}");
            Console.WriteLine(Ready);

            return "Ready";
        }


        private void StartGamePlay(Server server)
        {
            TellAllPlayers(server, "START_GAME_PLAY");
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
