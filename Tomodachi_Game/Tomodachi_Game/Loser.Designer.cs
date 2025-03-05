
namespace Tomodachi_Game
{
    partial class Loser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loser));
            button1 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Showcard Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(181, 399);
            button1.Name = "button1";
            button1.Size = new Size(206, 54);
            button1.TabIndex = 0;
            button1.Text = "Go loser";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Loser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1046, 584);
            Controls.Add(button1);
            Name = "Loser";
            Text = "Loser";
            FormClosing += LoserFormClosing;
            ResumeLayout(false);
        }

       

        #endregion

        private Button button1;
    }
}