using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
//using static WindowsFormsApp1.Game_screen;
namespace WindowsFormsApp1
{
    public partial class AI_game : Form
    {
        // database
        SqlCommand Command;
        SqlConnection Connection;
        public string userName;

        // timer
        private Stopwatch stopWatch1;

        // instantiates the random class which is public thus accessible through the program
        public static Random rnd = new Random();
        public Ships Player1 = new Ships(1);  // instantiates an object as player 1 and public
        public Ships Player2 = new Ships(2); // instantiates an object as player 2 and public
        public int shipDestroyed1 = 0;
        public int shipDestroyed2 = 0;
        public List<string> already_hit = new List<string>();

        public AI_game(string username)
        {
            InitializeComponent();
            stopWatch1 = new Stopwatch();
            userName = username;

        }

        private void Form1_Load(object sender, EventArgs e)
        {   // connection to database
            Connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = G:\Dinal school homework\year 13\Computer science\Nea\Battleship\Database.mdf; Integrated Security = True"); // makes a connection to the database
            Connection.Open();

            Player1.carrier(rnd);  // calls function carrier which makes location of the cruiser (5 tiles)
            Player1.battleship(rnd);  // calls function carrier which makes location of the cruiser (5 tiles)
            Player1.Cruiser_and_Submarine(rnd);  // calls function carrier which makes location of the cruiser / submarine (3 tiles)
            Player1.Cruiser_and_Submarine(rnd);  // calls function carrier which makes location of the cruiser / submarine (3 tiles)
            Player1.Destroyer(rnd);  // calls function carrier which makes location of the destroyer (2 tiles)
            Player1.printLocation();  // prints the location out in the console

            Player2.carrier(rnd);   // calls function carrier which makes location of the cruiser (5 tiles)
            Player2.battleship(rnd);  // prints the location out in the console
            Player2.Cruiser_and_Submarine(rnd);  // calls function carrier which makes location of the cruiser / submarine (3 tiles)
            Player2.Cruiser_and_Submarine(rnd);  // calls function carrier which makes location of the cruiser / submarine (3 tiles)
            Player2.Destroyer(rnd);  // calls function carrier which makes location of the destroyer (2 tiles)
            Player2.printLocation();  // prints the location out in the console
            // switches the players turns
            int turn = rnd.Next(1, 3);
            switchturn(turn);

            Console.WriteLine("Username in Game: " + userName);
        }
        public void AI()
        {
            bool repeat = true;
            bool check;
            string location = "";

            while (repeat == true)
            {
                check = false;
                int H = rnd.Next(65, 75);  // chooses a number between 65 and 75 which is the corresponding ascii values for A to J   
                int V = rnd.Next(1, 11); // chooses a number between 1 and 10
                location = char.ConvertFromUtf32(H) + V + "_" + 1; // concatenates the location
                Console.WriteLine(location);
                if (already_hit.Contains(location))
                {
                    check = true;
                    Console.WriteLine(check);
                }

                if (check == false)
                {
                    already_hit.Add(location);
                    repeat = false;

                }
            }
            

            string[] shipLoc = Player1.GetLocation(); // gets ship location
            bool hit = false;
            for (int i = 0; i < 17; i++)// loops through the array
            {
                if (shipLoc[i] == location)
                {
                    hit = true; // if the location is the same as the location in the array then it sets hit = true
                }
            }
            foreach (Control control in Controls)
            {
                if (control is Button && control.Name == location)
                {
                    if (hit == true)
                    {
                        Console.WriteLine("Hit");// debugging purposes. prints is it has hit the ship
                        control.Name = "Hit";
                        control.BackgroundImage = Properties.Resources.explosion; // shows as an explosion on that tile
                        control.Enabled = false;
                        shipDestroyed2++;
                    }
                    else
                    {
                        Console.WriteLine("Miss"); // debugging purposes. prints is it has miss the ships
                        control.Name = "Miss";
                        control.BackgroundImage = Properties.Resources.miss; // shows that it has missed the tile
                        control.Enabled = false;
                    }

                }
            }

            switchturn(1);
        }
        private void Player_1(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            //Console.WriteLine(button.Name); // debugging purposes. displays the name of the button
            bool hit = false;
            string[] location = Player2.GetLocation(); // gets ship location
            for (int i = 0; i < 17; i++)// loops through the array
            {
                if (location[i] == button.Name)
                {
                    hit = true; // if the button click location is the same as the location in the array then it sets hit = true
                }
            }
            if (hit == true)
            {
                ///Console.WriteLine("Hit");// debugging purposes. prints is it has hit the ship
                button.Name = "Hit";
                button.BackgroundImage = Properties.Resources.explosion; // shows as an explosion on that tile
                button.Enabled = false;
                shipDestroyed1++;
            }
            else
            {
                //Console.WriteLine("Miss"); // debugging purposes. prints is it has miss the ships
                button.Name = "Miss";
                button.BackgroundImage = Properties.Resources.miss; // shows that it has missed the tile
                button.Enabled = false;
            }
            switchturn(2);

        }
        public void switchturn(int turn)
        {
            Form form = this; // gets the current form
            if (turn == 1)
            {
                stopWatch1.Start();
                Disable_tile(form, 1); // disables all tiles for the first grid
                Enable_tile(form, 2); // enables all tiles for the second grid
            }
            else if (turn == 2)
            {
                stopWatch1.Stop();
                Disable_tile(form, 2);// disables all tiles for the second grid
                Enable_tile(form, 1);  // enables all tiles for the first grid
                AI();

            }
            if (shipDestroyed1 == 17)
            {
                stopWatch1.Stop();
                TimeSpan ts = stopWatch1.Elapsed; // gets the time taken as a timeSpan value
                string Time = String.Format("{0:00}:{1:00}.{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds); // formats the string only for the minutes, seconds and milliseconds.
                string message = "Player 1 won the Game! \nTime taken: " + Time;
                MessageBox.Show(message, "Winner"); // Tells player 1 they won
                InsertToDatabase(Time);
                this.Hide();
                menu menuWindow = new menu(userName);  // if there is an account in the database it sends the user to the main menu
                menuWindow.ShowDialog();

            }
            else if (shipDestroyed2 == 17)
            {
                stopWatch1.Stop();
                string message = "AI won the Game!";
                MessageBox.Show(message, "Winner"); // Tells player 2 they won
                this.Hide();
                menu menuWindow = new menu(userName);  // sends them to the main menu
                menuWindow.ShowDialog();
            }
        }
        public void InsertToDatabase(string time)
        {
            Command = new SqlCommand("insert into Highscore values(@username,@score)", Connection); // adds username and hashed password to the database
            Command.Parameters.AddWithValue("Username", userName);
            Command.Parameters.AddWithValue("score", time);
            Command.ExecuteNonQuery();

        }
        public void Disable_tile(Form form, int Player)// disables all buttons that contains the string _x where x is the players grid
        {
            foreach (Control control in Controls)
            {
                Button b = control as Button;
                if (b != null)
                {
                    if (b.Name.Contains("_" + Convert.ToString(Player)))
                    {
                        b.Enabled = false;
                    }
                }
            }
        }
        public void Enable_tile(Form form, int Player) // enable all buttons that contains the string _x where x is the players grid
        {
            foreach (Control control in Controls)
            {
                Button b = control as Button;
                if (b != null)
                {
                    if (b.Name.Contains("_" + Convert.ToString(Player)))
                    {
                        b.Enabled = true;
                    }
                }
            }
        }
        // right named function

        private void timer_1_Tick(object sender, EventArgs e) // increases the time for the stopwatch
        {
            Timer1.Text = string.Format("{0:mm\\:ss\\:fff}", stopWatch1.Elapsed);

        }

        private void Backbtn_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("You are currently in a game.\nDo you really want to go back?", "Leave current game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                stopWatch1.Stop();
                this.Hide();
                menu menuWindow = new menu(userName);  // if there is an account in the database it sends the user to the main menu
                menuWindow.ShowDialog();
            }

        }
    }

}

