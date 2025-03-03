
using System.Collections.Immutable;

namespace Tomodachi_Game
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            Start_Button = new Button();
            NickNameLabel = new Label();
            NickNameTextBox = new TextBox();
            SuspendLayout();
            // 
            // Start_Button
            // 
            Start_Button.Font = new Font("Showcard Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Start_Button.Location = new Point(447, 271);
            Start_Button.Name = "Start_Button";
            Start_Button.Size = new Size(188, 49);
            Start_Button.TabIndex = 0;
            Start_Button.Text = "Start";
            Start_Button.UseVisualStyleBackColor = true;
            Start_Button.Click += Start_Button_Click;
            // 
            // label1
            // 
            NickNameLabel.AutoSize = true;
            NickNameLabel.BackColor = Color.DarkSlateBlue;
            NickNameLabel.Font = new Font("Showcard Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NickNameLabel.ForeColor = SystemColors.ButtonHighlight;
            NickNameLabel.Location = new Point(344, 228);
            NickNameLabel.Name = "label1";
            NickNameLabel.Size = new Size(97, 21);
            NickNameLabel.TabIndex = 1;
            NickNameLabel.Text = "Nick Name";
            NickNameLabel.Visible = false;
            // 
            // textBox1
            // 
            NickNameTextBox.Location = new Point(447, 227);
            NickNameTextBox.Name = "textBox1";
            NickNameTextBox.Size = new Size(188, 27);
            NickNameTextBox.TabIndex = 2;
            NickNameTextBox.Visible = false;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1053, 592);
            Controls.Add(NickNameTextBox);
            Controls.Add(NickNameLabel);
            Controls.Add(Start_Button);
            Name = "Home";
            Text = "Tomodachi Game\n";
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private Button Start_Button;
        private Label NickNameLabel;
        private TextBox NickNameTextBox;
    }
}
