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
        Thread listeningThread;
        string roomId;
        private bool stopThread;

        internal GamePlay(Player player, string roomId)
        {
            InitializeComponent();
           /* this.player = player;
            this.roomId = roomId;
            RoundNum.BackColor = Color.FromArgb(11, 5, 51);
            RoundNum.BackColor = Color.Transparent;
            PlayerName.BackColor = Color.FromArgb(11, 5, 51);
            Word.BackColor = Color.FromArgb(11, 5, 51);

            player.MessageReceived += OnMessageReceived;

            listeningThread = new Thread(player.ListenToServer);
            listeningThread.IsBackground = true;
            listeningThread.Start();

            RoundNum.Text = "ROUND " + player.SendRequestToServer($"Round_Num {roomId}");
            PlayerName.Text = player.PlayerName + " TURN";
            Word.Text = new string('*', int.Parse(player.SendRequestToServer($"WORD {roomId}"))).Replace("*", "* ");*/
        }

        private void OnMessageReceived(string message)
        {
            if (message == "NOT_YOUR_TURN")
            {
                // افتح فروم المشاهدة
            }

        }

        private void EnterGuess_Click(object sender, EventArgs e)
        {/*
            string guess = GuessTextBox.Text;
            string ans = player.SendRequestToServer($"CHECK_GUESS {player.PlayerId} {roomId} {guess}");
            if (ans.StartsWith("TRUE"))
            {
                Word.Text = guess;
                Thread.Sleep(3000);
                // فورم الاعدام
            }
            else
            {
                Word.Text = $"{guess} has {ans.Split(' ')[1]} correct letters";
                Thread.Sleep(3000);
                player.SendRequestToServer($"NEXT_ROUND {roomId}");
            
            }*/
        }
        void CloseTheared()
        {
            stopThread = true;
            if (listeningThread != null && listeningThread.IsAlive)
            {
                listeningThread.Join();
            }
        }
        private void GamePlay_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseTheared();
            player.Disconnect();
            Application.Exit();
        }
    }
}
