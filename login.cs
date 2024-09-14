using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;


namespace WindowsFormsApp1
{
    public partial class login : Form
    {
        SqlCommand Command;
        SqlConnection Connection;
        SqlDataReader DataReader;
        public int tries = 0;
        public login()
        {
            InitializeComponent();
        }
        private void login_Load(object sender, EventArgs e)
        {
            Connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = G:\Dinal school homework\year 13\Computer science\Nea\Battleship\Database.mdf; Integrated Security = True"); // makes a connection to the database
            Connection.Open();

        }
        private void Register_Click(object sender, EventArgs e)
        {
            this.Hide();
            registration registrationWindow = new registration();  // when you click registration button, it send you to the registration form
            registrationWindow.ShowDialog();
        }
        private void Login_Click(object sender, EventArgs e)
        {
            
            if (password.Text != string.Empty || userName.Text != string.Empty) // checks if the user inputted anything
            {
                string passHash = PasswordHash(password.Text);
                Console.WriteLine(passHash);
                Command = new SqlCommand("select * from Accounts where username='" + userName.Text + "' and password='" + passHash + "'", Connection); // sql command to check if that username and password are in the database
                DataReader = Command.ExecuteReader();
                if (DataReader.Read())
                {
                    DataReader.Close();
                    Game_screen GameWindow = new Game_screen(userName.Text);
                    this.Hide();
                    menu menuWindow = new menu(userName.Text);  // if there is an account in the database it sends the user to the main menu
                    menuWindow.ShowDialog();
                }
                else
                {
                    tries= tries +1;
                    DataReader.Close();
                    MessageBox.Show("No Account avilable with this username and password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // if there is no matching accounts it pops up an error telling there is no account
                }

            }
            else
            {
                tries = tries + 1;
                MessageBox.Show("Please enter a username and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // if the user doesnt input anything for the username or password it tells them to input something
            }
            Console.WriteLine(tries);
            if (tries == 5)
            {
                MessageBox.Show("You have exceeded the amount of tries. Try again later", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // if the user doesnt input anything for the username or password it tells them to input something
                Application.Exit();

            }
        }
        private void userNm_TextChanged(object sender, EventArgs e)
        {

            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

        }
        private string PasswordHash(string password, string salt = "dlqp9BRB")
        {
            // Using SHA256 to create the hash
            using (var sha = new SHA256Managed())
            {
                // Converting the string to a byte array first
                byte[] Passwordbyte = Encoding.UTF8.GetBytes(password + salt);
                byte[] hashBytes = sha.ComputeHash(Passwordbyte);
                string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty); // converts the byte[] to string and removes the - between the values
                return hash;
            }
        }

        private void Exitbtn_Click(object sender, EventArgs e) // asks the user if they want to clsoe the program
        {
            DialogResult dialog = MessageBox.Show("Do you want to exit the program?", "Exit Program", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
