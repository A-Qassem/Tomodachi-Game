namespace Tomodachi_Game
{
    partial class GamePlay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GamePlay));
            RoundNum = new Label();
            Word = new Label();
            GuessTextBox = new TextBox();
            EnterGuess = new Button();
            PlayerName = new Label();
            SuspendLayout();
            // 
            // RoundNum
            // 
            RoundNum.AutoSize = true;
            RoundNum.Font = new Font("Showcard Gothic", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RoundNum.ForeColor = SystemColors.ButtonHighlight;
            RoundNum.Location = new Point(74, 59);
            RoundNum.Name = "RoundNum";
            RoundNum.Size = new Size(248, 74);
            RoundNum.TabIndex = 0;
            RoundNum.Text = "Round ";
            // 
            // Word
            // 
            Word.AutoSize = true;
            Word.Font = new Font("Showcard Gothic", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Word.Location = new Point(376, 205);
            Word.Name = "Word";
            Word.Size = new Size(196, 59);
            Word.TabIndex = 1;
            Word.Text = "* * * * * *";
            // 
            // GuessTextBox
            // 
            GuessTextBox.Location = new Point(376, 307);
            GuessTextBox.Name = "GuessTextBox";
            GuessTextBox.Size = new Size(196, 27);
            GuessTextBox.TabIndex = 2;
            // 
            // EnterGuess
            // 
            EnterGuess.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EnterGuess.Location = new Point(376, 352);
            EnterGuess.Name = "EnterGuess";
            EnterGuess.Size = new Size(196, 46);
            EnterGuess.TabIndex = 3;
            EnterGuess.Text = "Enter guess";
            EnterGuess.UseVisualStyleBackColor = true;
            EnterGuess.Click += EnterGuess_Click;
            // 
            // PlayerName
            // 
            PlayerName.AutoSize = true;
            PlayerName.Font = new Font("Showcard Gothic", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PlayerName.ForeColor = SystemColors.ButtonHighlight;
            PlayerName.Location = new Point(778, 415);
            PlayerName.Name = "PlayerName";
            PlayerName.Size = new Size(150, 59);
            PlayerName.TabIndex = 4;
            PlayerName.Text = "Turn";
            // 
            // GamePlay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1050, 589);
            Controls.Add(PlayerName);
            Controls.Add(EnterGuess);
            Controls.Add(GuessTextBox);
            Controls.Add(Word);
            Controls.Add(RoundNum);
            Name = "GamePlay";
            Text = "GamePlay";
            FormClosing += GamePlay_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label RoundNum;
        private Label Word;
        private TextBox GuessTextBox;
        private Button EnterGuess;
        private Label PlayerName;
    }
}