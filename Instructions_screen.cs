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
    public partial class Instructions_screen : Form
    {
        public string userName;
        public Instructions_screen(string username)
        {
            InitializeComponent();
            userName = username;
        }

        private void Backbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu menuWindow = new menu(userName);  // send you to the game window
            menuWindow.ShowDialog();
        }

        private void Instructions_screen_Load(object sender, EventArgs e)
        {
            //  changes the backcolour of the labels and pictures to white with opacity 175
            label1.BackColor = Color.FromArgb(175, Color.White);
            label2.BackColor = Color.FromArgb(175, Color.White);
            label3.BackColor = Color.FromArgb(175, Color.White);
            label4.BackColor = Color.FromArgb(175, Color.White);
            label5.BackColor = Color.FromArgb(175, Color.White);
            pictureBox1.BackColor = Color.FromArgb(175, Color.White);
            pictureBox2.BackColor = Color.FromArgb(175, Color.White);

        }
    }
}
