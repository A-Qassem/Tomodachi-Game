namespace Tomodachi_Game
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            NickNameLabel.BackColor = Color.Transparent;

        }
        private void Start_Button_Click(object sender, EventArgs e)
        {
            if (Start_Button.Text == "Start")
            {
                NickNameLabel.Visible = true;
                NickNameTextBox.Visible = true;
                Start_Button.Text = "Let's GOOO";
            }
            else
            {
                if (string.IsNullOrWhiteSpace(NickNameTextBox.Text))
                {
                    MessageBox.Show("Don't forget to write your nickname.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    NickNameTextBox.Text = string.Empty;
                    return;
                }
                this.Hide();
                Player NewPlayer = new Player(NickNameTextBox.Text);
                StartGame startGame = new StartGame(NewPlayer);
                startGame.Show();

            }
        }
    }
}
