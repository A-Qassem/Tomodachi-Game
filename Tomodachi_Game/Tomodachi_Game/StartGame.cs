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
    public partial class StartGame : Form
    {
        Player player;
        string? response;
        internal StartGame(Player player)
        {
            InitializeComponent();
            this.player = player;
            player.MessageReceived += GotMessage;
            EnterRoomCodeLabel.BackColor = Color.Transparent;
        }

        private void JoinRoom_Click(object sender, EventArgs e)
        {
            EnterRoomCodeLabel.Visible = true;
            CheckRoomCodeButton.Visible = true;
            RoomCodeTextBox.Visible = true;
            BackButton.Visible = true;

            JoinButton.Visible = false;
            CreateButton.Visible = false;
        }
        void GotMessage(string message)
        {
            response = message;
        }
        private void CreateButton_Click(object sender, EventArgs e)
        {
            player.SendMessage($"CREATE_ROOM {player.PlayerId}");
            Thread.Sleep(100);
            if (response != null)
            {
                WaitingRoom waitingRoom = new WaitingRoom(player, response.Split()[1], true);
                this.Hide();
                waitingRoom.Show();
            }
        }

        private void CheckRoomCodeButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RoomCodeTextBox.Text))
            {
                MessageBox.Show("Don't forget to enter room code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string roomId = RoomCodeTextBox.Text;
            player.SendMessage($"JOIN_ROOM {player.PlayerId} {roomId}");
            Thread.Sleep(100);

            if (response == $"JOINED_ROOM {roomId}")
            {
                WaitingRoom room = new WaitingRoom(player, roomId);
                room.Show();
                this.Hide();
            }
            else if (response == "ROOM_NOT_FOUND")
            {
                MessageBox.Show("Room Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (response == "ROOM_FULL")
            {
                MessageBox.Show("Room is full", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (response == "ROOM_RUNNING")
            {
                MessageBox.Show("The game has already started!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Error: " + response, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StartGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            player.MessageReceived -= GotMessage;
            player.Disconnect();
            Application.Exit();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            EnterRoomCodeLabel.Visible = false;
            CheckRoomCodeButton.Visible = false;
            RoomCodeTextBox.Visible = false;
            BackButton.Visible = false;

            JoinButton.Visible = true;
            CreateButton.Visible = true;
        }
    }
}
