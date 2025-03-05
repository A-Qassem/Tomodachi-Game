using System;
using System.Threading;
using System.Windows.Forms;

namespace Tomodachi_Game
{
    public partial class HowToPlay : Form
    {
        Player player;
        string roomId;
        internal HowToPlay(Player player , string roomId)
        {
            InitializeComponent();
            this.player = player;
            this.roomId = roomId;
            ReadyCounter.BackColor = Color.Transparent;
            TimerLabel.BackColor = Color.Transparent;
            TimerLabel.Visible = false;
            ReadyCounter.Text = $"0 Players ready";
            player.MessageReceived += OnMessageReceived;
        }
        private void OnMessageReceived(string message)
        {
            if (message.StartsWith("READY"))
            {
                string text = $"{message.Split()[1]} Players ready";
                if (ReadyCounter.InvokeRequired)
                {
                    ReadyCounter.BeginInvoke((MethodInvoker)(() => ReadyCounter.Text = text));
                }
                else
                {
                    ReadyCounter.Text = text;
                }
            }
            if(message == "START_GAME_PLAY")
            {
                Invoke(new Action(() =>
                {
                    player.MessageReceived -= OnMessageReceived;
                    this.Hide();
                    GamePlay gamePlay = new GamePlay(player, roomId);
                    gamePlay.Show();
                }));
            }

        }

        void CloseThreads()
        {
            player.CloseThread = true;
        }

        private void HowToPlay_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseThreads();
            this.Dispose();
            player.Disconnect();
            Application.Exit();
        }
        private void ReadyButton_Click(object sender, EventArgs e)
        {
            player.SendMessage($"READY {roomId} {player.PlayerId}");
            ReadyButton.Visible = false;
        }
    }
}
