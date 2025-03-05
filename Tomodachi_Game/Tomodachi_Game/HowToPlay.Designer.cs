namespace Tomodachi_Game
{
    partial class HowToPlay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HowToPlay));
            ReadyButton = new Button();
            ReadyCounter = new Label();
            TimerLabel = new Label();
            SuspendLayout();
            // 
            // ReadyButton
            // 
            ReadyButton.Font = new Font("Showcard Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ReadyButton.Location = new Point(167, 461);
            ReadyButton.Name = "ReadyButton";
            ReadyButton.Size = new Size(133, 48);
            ReadyButton.TabIndex = 0;
            ReadyButton.Text = "Ready";
            ReadyButton.UseVisualStyleBackColor = true;
            ReadyButton.Click += ReadyButton_Click;
            // 
            // ReadyCounter
            // 
            ReadyCounter.AutoSize = true;
            ReadyCounter.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ReadyCounter.ForeColor = SystemColors.ButtonHighlight;
            ReadyCounter.Location = new Point(144, 386);
            ReadyCounter.Name = "ReadyCounter";
            ReadyCounter.Size = new Size(192, 29);
            ReadyCounter.TabIndex = 1;
            ReadyCounter.Text = "Players ready";
            // 
            // TimerLabel
            // 
            TimerLabel.AutoSize = true;
            TimerLabel.Font = new Font("Showcard Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TimerLabel.ForeColor = SystemColors.ButtonHighlight;
            TimerLabel.Location = new Point(138, 421);
            TimerLabel.Name = "TimerLabel";
            TimerLabel.Size = new Size(198, 37);
            TimerLabel.TabIndex = 2;
            TimerLabel.Text = "TimerLabel";
            // 
            // HowToPlay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1048, 572);
            Controls.Add(TimerLabel);
            Controls.Add(ReadyCounter);
            Controls.Add(ReadyButton);
            Name = "HowToPlay";
            Text = "GamePlay";
            FormClosing += HowToPlay_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ReadyButton;
        private Label ReadyCounter;
        private Label TimerLabel;
    }
}