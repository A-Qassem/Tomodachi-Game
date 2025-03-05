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
            Word = new Label();
            GuessTextBox = new TextBox();
            EnterGuess = new Button();
            StateLabel = new Label();
            ModeLabel = new Label();
            PasswordLabel = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // Word
            // 
            Word.AutoSize = true;
            Word.Font = new Font("Showcard Gothic", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Word.ForeColor = SystemColors.ButtonHighlight;
            Word.Location = new Point(731, 445);
            Word.Name = "Word";
            Word.Size = new Size(196, 59);
            Word.TabIndex = 1;
            Word.Text = "* * * * * *";
            // 
            // GuessTextBox
            // 
            GuessTextBox.Location = new Point(407, 246);
            GuessTextBox.Name = "GuessTextBox";
            GuessTextBox.Size = new Size(196, 27);
            GuessTextBox.TabIndex = 2;
            // 
            // EnterGuess
            // 
            EnterGuess.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EnterGuess.Location = new Point(407, 345);
            EnterGuess.Name = "EnterGuess";
            EnterGuess.Size = new Size(196, 46);
            EnterGuess.TabIndex = 3;
            EnterGuess.Text = "Enter guess";
            EnterGuess.UseVisualStyleBackColor = true;
            EnterGuess.Click += EnterGuess_Click;
            // 
            // StateLabel
            // 
            StateLabel.AutoSize = true;
            StateLabel.Font = new Font("Showcard Gothic", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StateLabel.ForeColor = SystemColors.ButtonHighlight;
            StateLabel.Location = new Point(172, 177);
            StateLabel.Name = "StateLabel";
            StateLabel.Size = new Size(142, 50);
            StateLabel.TabIndex = 5;
            StateLabel.Text = "State";
            // 
            // ModeLabel
            // 
            ModeLabel.AutoSize = true;
            ModeLabel.BackColor = Color.Transparent;
            ModeLabel.Font = new Font("Showcard Gothic", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModeLabel.ForeColor = SystemColors.ButtonHighlight;
            ModeLabel.Location = new Point(22, 177);
            ModeLabel.Name = "ModeLabel";
            ModeLabel.Size = new Size(144, 46);
            ModeLabel.TabIndex = 6;
            ModeLabel.Text = "Mode: ";
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.BackColor = Color.Transparent;
            PasswordLabel.Font = new Font("Showcard Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PasswordLabel.ForeColor = SystemColors.ButtonHighlight;
            PasswordLabel.Location = new Point(390, 445);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(303, 37);
            PasswordLabel.TabIndex = 7;
            PasswordLabel.Text = "Password Length";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Showcard Gothic", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(319, 50);
            label1.Name = "label1";
            label1.Size = new Size(374, 50);
            label1.TabIndex = 8;
            label1.Text = "Tomodachi Game";
            // 
            // GamePlay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1050, 589);
            Controls.Add(label1);
            Controls.Add(PasswordLabel);
            Controls.Add(ModeLabel);
            Controls.Add(StateLabel);
            Controls.Add(EnterGuess);
            Controls.Add(GuessTextBox);
            Controls.Add(Word);
            Name = "GamePlay";
            Text = "GamePlay";
            FormClosing += GamePlay_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label Word;
        private TextBox GuessTextBox;
        private Button EnterGuess;
        private Label StateLabel;
        private Label ModeLabel;
        private Label PasswordLabel;
        private Label label1;
    }
}