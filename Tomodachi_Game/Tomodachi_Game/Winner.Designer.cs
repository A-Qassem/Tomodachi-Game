
namespace Tomodachi_Game
{
    partial class Winner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Winner));
            button1 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(185, 417);
            button1.Name = "button1";
            button1.Size = new Size(170, 48);
            button1.TabIndex = 0;
            button1.Text = "Good By";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Winner
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1051, 598);
            Controls.Add(button1);
            Name = "Winner";
            Text = "Winner";
            FormClosing += WinnerFormClosing;
            ResumeLayout(false);
        }

       
        #endregion

        private Button button1;
    }
}