using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp1
{
    public partial class Highscore_screen : Form
    {
        SqlCommand Command;
        SqlConnection Connection;
        SqlDataReader DataReader;
        public string userName;
        public Highscore_screen(string userNm)
        {
            InitializeComponent();
             userName = userNm;
        }

        private void Highscore_screen_Load(object sender, EventArgs e)
        {
            Connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = G:\Dinal school homework\year 13\Computer science\Nea\Battleship\Database.mdf; Integrated Security = True"); // makes connection to the database
            Connection.Open();
            displayScore();
        }
        private void displayScore()
        {
            using (Command = new SqlCommand("SELECT Username, score FROM Highscore ORDER BY score ASC", Connection)) // command to get the username and score form the database
            {
                using (DataReader = Command.ExecuteReader()) // executes the command
                {
                    int i = 1;
                    while (DataReader.Read()) // if there is a value it prints them out
                    {
                        // debugging purposes
                        Console.WriteLine(DataReader["Username"].ToString());
                        Console.WriteLine(DataReader["score"].ToString());

                        foreach (Control L in Controls)// loops through all labels in the windows.
                        {
                            //Console.WriteLine(L.Name); prints out all labels names
                            if (L.Name == "username" + Convert.ToString(i)) // if the label contants the name "usernamex" where x is the index of the line, it replaces the name
                            {  
                                L.Text = DataReader["Username"].ToString();
                            }
                            if (L.Name == "score" + Convert.ToString(i)) // if the label contants the name "scorex" where x is the index of the line, it replaces the score
                            {
                                L.Text = DataReader["score"].ToString();
                            }
                        }
                        i++; // next i
                    }
                }

            }
        }

        private void Backbtn_Click(object sender, EventArgs e)
        {
                this.Hide();
                menu menuWindow = new menu(userName);  // if there is an account in the database it sends the user to the main menu
                menuWindow.ShowDialog();

        }
    }
}
