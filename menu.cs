using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp1
{
    public partial class menu : Form
    {
        public string Username;
        public menu(string username)
        {
            InitializeComponent();
             Username = username;
            Console.WriteLine("Username in menu: "+username);
        }

        private void Instruction_Click(object sender, EventArgs e)
        {
            this.Hide();
            Instructions_screen InstructionWindow = new Instructions_screen(Username); // send you to the instruction window
            InstructionWindow.ShowDialog();
        }
        private void Highscore_Click(object sender, EventArgs e)
        {
            this.Hide();
            Highscore_screen HighscoreWindow = new Highscore_screen(Username); // send you to the highscore window
            HighscoreWindow.ShowDialog();
        }

        private void Button_MouseHover(object sender, EventArgs e)
        {
            Button button = (Button) sender;
            button.ForeColor = Color.Cyan;
            button.Font = new Font("Stencil", 50, FontStyle.Regular);
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.ForeColor = Color.White;
            button.Font = new Font("Stencil", 50, FontStyle.Regular);
        }

        private void menu_Load(object sender, EventArgs e)
        {

        }

        private void Backbtn_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                this.Hide();
                login loginWindow = new login();  // when you click login button, it send you to the login form
                loginWindow.ShowDialog();
            }

        }

        private void P1_click(object sender, EventArgs e)
        {
            this.Hide();
            AI_game AIwindow = new AI_game(Username);  // send you to the PvE game 
            AIwindow.ShowDialog();
        }

        private void P2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Game_screen gameWindow = new Game_screen(Username);  // send you to the PvP game 
            gameWindow.ShowDialog();
        }
    }
}
