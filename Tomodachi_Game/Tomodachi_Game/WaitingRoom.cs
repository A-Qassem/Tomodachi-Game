using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Tomodachi_Game
{
    public partial class WaitingRoom : Form
    {
        private Thread WaitingThread;
        private int playerCount = 0;
        bool CloseThread = false;
        Player player;
        string? response;
        internal WaitingRoom(Player player ,string roomId ,bool owner)
        {
            InitializeComponent();
            RoomIdLabel.Text = roomId;
            UpdatePlayerCount(1);

            RoomIdLabel.BackColor = Color.Transparent;
            PlayresNumLabel.BackColor = Color.Transparent;
            WaitLabel.Visible = false;
            this.player = player;
            player.MessageReceived += OnMessageReceived;
        }
        internal WaitingRoom(Player player, string roomId)
        {
            InitializeComponent();
            RoomIdLabel.Text = roomId;
            this.player = player;
            player.MessageReceived += OnMessageReceived;

            player.SendMessage("PLAYERS_NUM " + roomId);
            Thread.Sleep(100);
            if (response != null)
                playerCount = int.Parse(response);
            
            PlayresNumLabel.Text = playerCount.ToString();

            RoomIdLabel.BackColor = Color.Transparent;
            PlayresNumLabel.BackColor = Color.Transparent;
            StartGameButton.Visible = false;
            WaitLabel.BackColor = Color.Transparent;
            WaitingThread = new Thread(WaitStart);
            WaitingThread.IsBackground = true;
            WaitingThread.Start();
        }
        void WaitStart()
        {
            while (!CloseThread)
            {
                for (int i = 0; i < 4 && !CloseThread; i++)
                {
                    UpdateLabelText("Waiting" + new string('.', i));
                    Thread.Sleep(1000);
                }
            }
        }


        private void UpdateLabelText(string text)
        {
            if (WaitLabel.InvokeRequired)
            {
                WaitLabel.BeginInvoke((MethodInvoker)(() => WaitLabel.Text = text));
            }
            else
            {
                WaitLabel.Text = text;
            }
        }

        private void OnMessageReceived(string message)
        {
            response = message;
            if (message.StartsWith("RUN_HOW_TO_PLAY"))
            {
                Invoke(new Action(() =>
                {
                    CloseThreads();
                    player.MessageReceived -= OnMessageReceived;
                    this.Hide();
                    HowToPlay howToPlay = new HowToPlay(player,RoomIdLabel.Text);
                    howToPlay.Show();
                }));
            }
            else if (message.StartsWith("ADD"))
            {
                Invoke(new Action(() => UpdatePlayerCount(1)));
            }
            else if (message.StartsWith("REMOVE"))
            {
                Invoke(new Action(() => UpdatePlayerCount(-1)));
            }
            else if(message.StartsWith("LEAVE"))
            {
                Invoke(new Action(() =>
                {
                    CloseThreads();
                    player.MessageReceived -= OnMessageReceived;
                    var startGame = Application.OpenForms["startGame"] as StartGame;
                    MessageBox.Show("Owner leave room");
                    startGame.Show();
                    this.Hide();
                }));
            }
        }

        private void UpdatePlayerCount(int count)
        {
            playerCount += count;
            PlayresNumLabel.Text = playerCount.ToString();
        }
        void CloseThreads()
        {
            CloseThread = true;
            player.CloseThread = true;

            if (WaitingThread != null && WaitingThread.IsAlive)
            {
                WaitingThread.Join();
                WaitingThread = null;
            }
        }
        private void WaitingRoom_FormClosing(object sender, FormClosingEventArgs e)
        {
            player.MessageReceived -= OnMessageReceived;
            CloseThreads();
            this.Dispose();
            player.Disconnect();
            Application.Exit();
        }


        private void StartGameButton_Click_1(object sender, EventArgs e)
        {
            if (playerCount >= 2)
            {
                player.SendMessage("START "+RoomIdLabel.Text);
                CloseThreads();
                player.MessageReceived -= OnMessageReceived;
                this.Hide();
                HowToPlay howToPlay = new HowToPlay(player, RoomIdLabel.Text);
                howToPlay.Show();
            }
            else
            {
                MessageBox.Show("Can't start without at least 3 players");
            }
        }
    }
}