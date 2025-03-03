namespace Tomodachi_Game
{
    partial class StartGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartGame));
            JoinButton = new Button();
            CreateButton = new Button();
            RoomCodeTextBox = new TextBox();
            EnterRoomCodeLabel = new Label();
            CheckRoomCodeButton = new Button();
            BackButton = new Button();
            SuspendLayout();
            // 
            // JoinButton
            // 
            JoinButton.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            JoinButton.Location = new Point(423, 217);
            JoinButton.Name = "JoinButton";
            JoinButton.Size = new Size(159, 56);
            JoinButton.TabIndex = 0;
            JoinButton.Text = "Join Room";
            JoinButton.UseVisualStyleBackColor = true;
            JoinButton.Click += JoinRoom_Click;
            // 
            // CreateButton
            // 
            CreateButton.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CreateButton.Location = new Point(423, 335);
            CreateButton.Name = "CreateButton";
            CreateButton.Size = new Size(159, 55);
            CreateButton.TabIndex = 1;
            CreateButton.Text = "Create Room";
            CreateButton.UseVisualStyleBackColor = true;
            CreateButton.Click += CreateButton_Click;
            // 
            // RoomCodeTextBox
            // 
            RoomCodeTextBox.Location = new Point(423, 302);
            RoomCodeTextBox.Name = "RoomCodeTextBox";
            RoomCodeTextBox.Size = new Size(159, 27);
            RoomCodeTextBox.TabIndex = 2;
            RoomCodeTextBox.Visible = false;
            // 
            // EnterRoomCodeLabel
            // 
            EnterRoomCodeLabel.AutoSize = true;
            EnterRoomCodeLabel.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EnterRoomCodeLabel.ForeColor = SystemColors.ButtonHighlight;
            EnterRoomCodeLabel.Location = new Point(406, 261);
            EnterRoomCodeLabel.Name = "EnterRoomCodeLabel";
            EnterRoomCodeLabel.Size = new Size(196, 26);
            EnterRoomCodeLabel.TabIndex = 3;
            EnterRoomCodeLabel.Text = "Enter Room Code";
            EnterRoomCodeLabel.Visible = false;
            // 
            // CheckRoomCodeButton
            // 
            CheckRoomCodeButton.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CheckRoomCodeButton.Location = new Point(423, 352);
            CheckRoomCodeButton.Name = "CheckRoomCodeButton";
            CheckRoomCodeButton.Size = new Size(159, 57);
            CheckRoomCodeButton.TabIndex = 4;
            CheckRoomCodeButton.Text = "Join";
            CheckRoomCodeButton.UseVisualStyleBackColor = true;
            CheckRoomCodeButton.Visible = false;
            CheckRoomCodeButton.Click += CheckRoomCodeButton_Click;
            // 
            // BackButton
            // 
            BackButton.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BackButton.Location = new Point(423, 429);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(159, 60);
            BackButton.TabIndex = 5;
            BackButton.Text = "Back";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Visible = false;
            BackButton.Click += BackButton_Click;
            // 
            // StartGame
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1050, 591);
            Controls.Add(BackButton);
            Controls.Add(CheckRoomCodeButton);
            Controls.Add(EnterRoomCodeLabel);
            Controls.Add(RoomCodeTextBox);
            Controls.Add(CreateButton);
            Controls.Add(JoinButton);
            Name = "StartGame";
            Text = "StartGame";
            FormClosing += StartGame_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button JoinButton;
        private Button CreateButton;
        private TextBox RoomCodeTextBox;
        private Label EnterRoomCodeLabel;
        private Button CheckRoomCodeButton;
        private Button BackButton;
    }
}