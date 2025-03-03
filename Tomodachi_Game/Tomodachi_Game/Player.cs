using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Tomodachi_Game
{
    enum State
    {
        alive,
        died
    }

    internal class Player
    {
        public string PlayerName { get; set; }
        public string PlayerId { get; set; }
        public State PlayerState { get; set; }
        public bool IsAdmin { get; set; }
        private TcpClient? client;
        private NetworkStream? stream;
        internal bool CloseThread = false;

        public event Action<string>? MessageReceived;

        public Player(string playerName)
        {
            PlayerName = playerName;
            string newId = HelperFunction.GenerateRandomId();
            while (HelperFunction.CheckRandomId(newId))
            {
                newId = HelperFunction.GenerateRandomId();
            }
            PlayerId = newId;

            ConnectToServer();
        }

        private void ConnectToServer()
        {
            try
            {
                client = new TcpClient("127.0.0.1", 5000);
                stream = client.GetStream();
                SendMessage($"REGISTER {PlayerId} {PlayerName}");
                Task.Run(() => ListenToServer());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to server: " + ex.Message);
            }
        }

        private async void ListenToServer()
        {
            try
            {
                byte[] buffer = new byte[1024];
                while (!CloseThread)
                {
                    if (stream == null || !client.Connected) break;

                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        MessageReceived?.Invoke(response);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in ListenToServer: " + ex.Message);
            }
            finally
            {
                Disconnect();
            }
        }

        public void SendMessage(string message)
        {
            try
            {
                if (stream != null && client.Connected)
                {
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    stream.Write(data, 0, data.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending message: " + ex.Message);
            }
        }

        public void Disconnect()
        {
            try
            {
                CloseThread = true;
                SendMessage($"DISCONNECT {PlayerId}");
            }
            catch (Exception) { }
            finally
            {
                stream?.Close();
                client?.Close();
            }
        }
    }
}
