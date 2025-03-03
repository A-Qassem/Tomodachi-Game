namespace Tomodachi_Game
{
    partial class WaitingRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaitingRoom));
            RoomIdLabel = new Label();
            PlayresNumLabel = new Label();
            StartGameButton = new Button();
            WaitLabel = new Label();
            SuspendLayout();
            // 
            // RoomIdLabel
            // 
            RoomIdLabel.AutoSize = true;
            RoomIdLabel.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RoomIdLabel.ForeColor = SystemColors.ButtonHighlight;
            RoomIdLabel.Location = new Point(579, 63);
            RoomIdLabel.Name = "RoomIdLabel";
            RoomIdLabel.Size = new Size(112, 29);
            RoomIdLabel.TabIndex = 0;
            RoomIdLabel.Text = "Room ID";
            // 
            // PlayresNumLabel
            // 
            PlayresNumLabel.AutoSize = true;
            PlayresNumLabel.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PlayresNumLabel.ForeColor = SystemColors.ButtonHighlight;
            PlayresNumLabel.Location = new Point(605, 157);
            PlayresNumLabel.Name = "PlayresNumLabel";
            PlayresNumLabel.Size = new Size(62, 29);
            PlayresNumLabel.TabIndex = 1;
            PlayresNumLabel.Text = "Num";
            // 
            // StartGameButton
            // 
            StartGameButton.Font = new Font("Showcard Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StartGameButton.Location = new Point(449, 357);
            StartGameButton.Name = "StartGameButton";
            StartGameButton.Size = new Size(134, 48);
            StartGameButton.TabIndex = 2;
            StartGameButton.Text = "Start Game";
            StartGameButton.UseVisualStyleBackColor = true;
            StartGameButton.Click += StartGameButton_Click_1;
            // 
            // WaitLabel
            // 
            WaitLabel.AutoSize = true;
            WaitLabel.Font = new Font("Showcard Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            WaitLabel.ForeColor = SystemColors.ButtonHighlight;
            WaitLabel.Location = new Point(449, 255);
            WaitLabel.Name = "WaitLabel";
            WaitLabel.Size = new Size(116, 37);
            WaitLabel.TabIndex = 3;
            WaitLabel.Text = "label1";
            // 
            // WaitingRoom
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1046, 587);
            Controls.Add(WaitLabel);
            Controls.Add(StartGameButton);
            Controls.Add(PlayresNumLabel);
            Controls.Add(RoomIdLabel);
            Name = "WaitingRoom";
            Text = "WaitingRoom";
            FormClosing += WaitingRoom_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label RoomIdLabel;
        private Label PlayresNumLabel;
        private Button StartGameButton;
        private Label WaitLabel;
    }
}