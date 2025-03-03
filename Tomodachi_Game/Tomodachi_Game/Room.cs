using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tomodachi_Game
{
    internal class Room
    {
        public List<string> Players { get; } = new List<string>();
        public string RoomId { get; private set; }
        private TcpClient _connection;
        private NetworkStream _stream;
        private bool _isListening;

        public Room(string playerId)
        {
            try
            {
                _connection = new TcpClient(HelperFunction.serverIp, HelperFunction.serverPort);
                _stream = _connection.GetStream();

                Players.Add(playerId);
                string roomId = HelperFunction.GenerateRandomId();
                string response = SendRequest($"CREATE_ROOM {playerId} {roomId}");

                while (response == "ROOM_ID_TAKEN")
                {
                    roomId = HelperFunction.GenerateRandomId();
                    response = SendRequest($"CREATE_ROOM {playerId} {roomId}");
                }

                RoomId = roomId;

                _isListening = true;
                Task.Run(() => ListenToServer());
            }
            catch
            {
                CloseConnection();
            }
        }

        private string SendRequest(string message)
        {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(message);
                _stream.Write(data, 0, data.Length);

                byte[] buffer = new byte[1024];
                int bytesRead = _stream.Read(buffer, 0, buffer.Length);
                return Encoding.UTF8.GetString(buffer, 0, bytesRead);
            }
            catch
            {
                return "";
            }
        }

        private void ListenToServer()
        {
            try
            {
                byte[] buffer = new byte[1024];

                while (_isListening && _connection.Connected)
                {
                    int bytesRead = _stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    if (message.StartsWith("ADD "))
                    {
                        string newPlayerId = message.Substring(4);
                        if (!Players.Contains(newPlayerId))
                        {
                            Players.Add(newPlayerId);
                        }
                    }
                    else if (message == "CLOSE" || (message.StartsWith("REMOVE ") && message.Substring(4) == Players[0]))
                    {
                        SendRequest("CLOSE_ROOM " + RoomId);
                        CloseConnection();
                        break;
                    }
                    else if(message.StartsWith("REMOVE "))
                    {
                        Players.Remove(message.Substring(4));
                    }
                }
            }
            catch
            {
                CloseConnection();
            }
        }

        public void CloseConnection()
        {
            _isListening = false;
            _stream?.Close();
            _connection?.Close();
        }
    }
}
