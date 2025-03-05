using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tomodachi_Game
{
    public partial class GamePlay : Form
    {
        Player player;
        string roomId;
        internal GamePlay(Player player, string roomId)
        {
            InitializeComponent();
            this.player = player;
            this.roomId = roomId;
            player.MessageReceived += OnMessageReceived;
            Word.BackColor = Color.Transparent;
            StateLabel.BackColor = Color.Transparent;
        }
        private readonly object Lock = new();
        private void OnMessageReceived(string message)
        {

            if (message.StartsWith("WORD"))
            {
                string text = string.Join(" ", new string('*', int.Parse(message.Split()[1])).ToCharArray());
                if (Word.InvokeRequired)
                {
                    Word.BeginInvoke((MethodInvoker)(() => Word.Text = text));
                }
                else
                {
                    Word.Text = text;
                }
                player.SendMessage($"MY_TURN {player.PlayerId} {roomId}");

            }
            if (message.StartsWith("TURN") && player.PlayerId == message.Split()[1])
            {
                GuessTextBox.Visible = true;
                EnterGuess.Visible = true;
                if (StateLabel.InvokeRequired)
                {
                    StateLabel.BeginInvoke((MethodInvoker)(() => StateLabel.Text = "Your Turn"));
                }
                else
                {
                    StateLabel.Text = "Your Turn";
                }

            }
            if ((message.StartsWith("TURN") && player.PlayerId != message.Split()[1]) || message == "DEAD")
            {
                GuessTextBox.Visible = false;
                EnterGuess.Visible = false;
                if (StateLabel.InvokeRequired)
                {
                    StateLabel.BeginInvoke((MethodInvoker)(() => StateLabel.Text = (message == "DEAD" ? "You are dead" : "Spectator")));
                }
                else
                {
                    StateLabel.Text = (message == "DEAD" ? "You are dead" : "Spectator");
                }
            }
            if (message.StartsWith("WIN"))
            {
                if (message.Split()[1] == player.PlayerId)
                {
                    Invoke(new Action(() =>
                    {
                    player.MessageReceived -= OnMessageReceived;
                    Winner winner = new Winner();
                    winner.Show();
                    this.Hide();

                    }));

                }
                else
                {
                    Invoke(new Action(() => {
                   player.MessageReceived -= OnMessageReceived;
                    Loser loser = new Loser();
                    loser.Show();
                    this.Hide();
                    }));
                }
            }
            if (message.StartsWith("GUESS"))
            {
                MessageBox.Show($"Last guess is {message.Split()[2]} has {message.Split()[1]} correct letters");
            }
        }

        private void EnterGuess_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(GuessTextBox.Text))
                MessageBox.Show("Please enter a guess");
            else
                player.SendMessage($"GUESS {player.PlayerId} {roomId} {GuessTextBox.Text}");
        }
        private void GamePlay_FormClosing(object sender, FormClosingEventArgs e)
        {
            //CloseTheared();
            player.MessageReceived -= OnMessageReceived;
            player.Disconnect();
            Application.Exit();
        }
    }
}
