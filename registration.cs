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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp1
{
    public partial class registration : Form
    {
        SqlCommand Command;
        SqlConnection Connection;
        SqlDataReader DataReader;
        public registration()
        {
            InitializeComponent();
        }

        private void registration_Load(object sender, EventArgs e)
        {
            Connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = G:\Dinal school homework\year 13\Computer science\Nea\Battleship\Database.mdf; Integrated Security = True"); // makes connection to the database
            Connection.Open();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            this.Hide();
            login loginWindow = new login();  // when you click login button, it send you to the login form
            loginWindow.ShowDialog();
        }

        private void Register_Click(object sender, EventArgs e)
        {
            if (ConfirmPassword.Text != string.Empty || password.Text != string.Empty || userName.Text != string.Empty) // checks if the fields are empty or not
            {
                if (userName.Text.Length >= 3)
                {
                    if (password.Text.Length >= 5)
                    {

                        if (password.Text == ConfirmPassword.Text) // checks if the passwords match
                        {
                            Command = new SqlCommand("select * from Accounts where username='" + userName.Text + "'", Connection);
                            DataReader = Command.ExecuteReader();
                            if (DataReader.Read())
                            {
                                DataReader.Close();
                                MessageBox.Show("Username Already exist please try another ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // gives an error that there is already another accoutn with that same username
                            }
                            else
                            {
                                string passHash = PasswordHash(password.Text); // calls function to hash password
                                Console.WriteLine(passHash);
                                DataReader.Close();
                                Command = new SqlCommand("insert into Accounts values(@username,@password)", Connection); // adds username and hashed password to the database
                                Command.Parameters.AddWithValue("username", userName.Text);
                                Command.Parameters.AddWithValue("password", passHash);
                                Command.ExecuteNonQuery();
                                MessageBox.Show("Your Account is created . Please login now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information); // gives a pop up that an account has been created and added to the database
                                this.Hide();
                                login loginWindow = new login();  // once you are created an account it send you to the main screen
                                loginWindow.ShowDialog();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Passwords do not match ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // tells the user that the passwords do not match
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a password with more than 4 characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // tells the user that the password needs to have 3 or more characters

                    }
                }
                else
                {
                    MessageBox.Show("Please enter a username with more than 2 characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // tells the user that the username needs 5 or more characters

                }
            }
            else
            {
                MessageBox.Show("Please enter a Username, and confirm the password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // tells the user to enter a username and/or password
            }
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

        private void Exitbtn_Click(object sender, EventArgs e) // asks the user if they want to close the program
        {
            DialogResult dialog = MessageBox.Show("Do you want to exit the program?", "Exit Program", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}


