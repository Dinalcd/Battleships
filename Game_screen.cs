using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace WindowsFormsApp1
{
    public partial class Game_screen : Form
    {
        // database
        SqlCommand Command;
        SqlConnection Connection;
        public string userName;

        // timer
        private Stopwatch stopWatch1;
        private Stopwatch stopWatch2;

        // instantiates the random class which is public thus accessible through the program
        public static Random rnd = new Random();  
        public Ships Player1 = new Ships(1);  // instantiates an object as player 1 and public
        public Ships Player2 = new Ships(2); // instantiates an object as player 2 and public
        public int shipDestroyed1 = 0;
        public int shipDestroyed2 = 0;

        public Game_screen(string username)
        {
            InitializeComponent();
            stopWatch1 = new Stopwatch();
            stopWatch2 = new Stopwatch();
            userName = username;
            
        }

        private void Game_screen_Load(object sender, EventArgs e)
        {
            // database connectoin
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
        
        public void switchturn(int turn)
        {
            Form form = this; // gets the current form
            if (turn == 1)
            {
                stopWatch2.Stop();
                stopWatch1.Start();
                Disable_tile(form, 1); // disables all tiles for the first grid
                Enable_tile(form, 2); // enables all tiles for the second grid
            }
            else if (turn == 2)
            {
                stopWatch1.Stop();
                stopWatch2.Start();
                Disable_tile(form, 2);// disables all tiles for the second grid
                Enable_tile(form, 1);  // enables all tiles for the first grid

            }
            if (shipDestroyed1 == 17)
            {
                stopWatch2.Stop();
                stopWatch1.Stop();
                TimeSpan ts = stopWatch1.Elapsed; // gets the time taken as a timeSpan value
                string Time = String.Format("{0:00}:{1:00}.{2:00}",ts.Minutes, ts.Seconds,ts.Milliseconds); // formats the string only for the minutes, seconds and milliseconds.
                string message = "Player 1 won the Game! \nTime taken: "+ Time;
                MessageBox.Show( message , "Winner") ; // Tells player 1 they won
                InsertToDatabase(Time);
                this.Hide();
                menu menuWindow = new menu(userName);  // if there is an account in the database it sends the user to the main menu
                menuWindow.ShowDialog();

            }
            else if (shipDestroyed2 == 17)
            {
                stopWatch1.Stop();
                stopWatch2.Stop();
                TimeSpan ts = stopWatch2.Elapsed; // gets the time taken as a timeSpan value
                string Time = String.Format("{0:00}:{1:00}.{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds); // formats the string only for the minutes, seconds and milliseconds.
                string message = "Player 2 won the Game! \nTime taken: " + Time;
                MessageBox.Show(message, "Winner"); // Tells player 2 they won
                InsertToDatabase(Time);
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
                    if (b.Name.Contains("_"+ Convert.ToString(Player))) 
                    {
                        b.Enabled = false;
                    }
                }
            }
        }
        public void Enable_tile(Form form,int Player) // enable all buttons that contains the string _x where x is the players grid
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

        public void Player_1_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Console.WriteLine(button.Name); // debugging purposes. displays the name of the button
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
                Console.WriteLine("Hit");// debugging purposes. prints is it has hit the ship
                button.Name = "Hit";
                button.BackgroundImage = Properties.Resources.explosion; // shows as an explosion on that tile
                button.Enabled = false;
                shipDestroyed1++;
            }
            else
            {
                Console.WriteLine("Miss"); // debugging purposes. prints is it has miss the ships
                button.Name = "Miss";
                button.BackgroundImage = Properties.Resources.miss; // shows that it has missed the tile
                button.Enabled = false;
            }
            switchturn(2);

        }

        public void Player_2_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Console.WriteLine(button.Name); // debugging purposes. displays the name of the button
            bool hit = false;
            string[] location = Player1.GetLocation(); // gets ship location
            for (int i = 0; i < 17; i++) // loops through the array
            {
                if (location[i] == button.Name)
                {
                    hit = true; // if the button click location is the same as the location in the array then it sets hit = true
                }
            }
            if (hit == true)
            {
                Console.WriteLine("Hit");// debugging purposes. prints is it has hit the ship
                button.Name = "Hit";
                button.BackgroundImage = Properties.Resources.explosion; // shows as an explosion on that tile
                button.Enabled = false;
                shipDestroyed2++;
            }
            else
            {
                Console.WriteLine("Miss"); // debugging purposes. prints is it has miss the ships
                button.Name = "Miss";
                button.BackgroundImage = Properties.Resources.miss; // shows that it has missed the tile
                button.Enabled = false;

            }
            switchturn(1);

        }

        private void timer1_Tick(object sender, EventArgs e) // increases the time for the stopwatch
        {
            Timer1.Text = string.Format("{0:mm\\:ss\\:fff}", stopWatch1.Elapsed);

        }

        private void timer_2_Tick(object sender, EventArgs e) // increases the time for the stopwatch
        {
            Timer2.Text = string.Format("{0:mm\\:ss\\:fff}", stopWatch2.Elapsed);

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


    public class Ships
    {
        private string[] ship;
        private int player = 0;

        public Ships(int myPlayer)
        {
            ship = new String[17];  // makes an array
            player = myPlayer;
        }

        public void carrier(Random rnd)
        {
            int H_or_V = rnd.Next(1, 3);    // randomly generaters if the ship should be vertical or horizontal
            int H_starting_pos;
            int V_starting_pos;
            if (H_or_V == 1)  // ship placed horizontally
            {
                H_starting_pos = rnd.Next(65, 71);  // chooses a number between 65 and 70 which is the corresponding ascii values for A to F   
                V_starting_pos = rnd.Next(1, 11); // chooses a number between 1 and 10


                for (int i = 0; i < 5; i++)  // loop which records the location of the ship and goes to the next horizontal tile
                {
                    string location = char.ConvertFromUtf32(H_starting_pos) + V_starting_pos + "_" + player; // concatenates the location
                    ship[i] = location;
                    H_starting_pos++;
                }

            }
            else if (H_or_V == 2) // ship placed vertically
            {
                H_starting_pos = rnd.Next(65, 75); // chooses a number between 65 and 75 which is the corresponding ascii values for A to J   
                V_starting_pos = rnd.Next(1, 7); // chooses a number between 1 and 6

                for (int i = 0; i < 5; i++)  // loop which records the location of the ship and goes to the next vertical tile
                {
                    string location = char.ConvertFromUtf32(H_starting_pos) + V_starting_pos + "_" + player;
                    ship[i] = location;
                    V_starting_pos++;
                }
            }
        }


        public void battleship(Random rnd)
        {
            int H_or_V = rnd.Next(1, 3);    // randomly generaters if the ship should be vertical or horizontal
            int H_starting_pos = 0;
            int V_starting_pos = 0;
            bool repeat = true;
            if (H_or_V == 1)  // ship placed horizontally
            {
                while (repeat == true)
                {
                    H_starting_pos = rnd.Next(65, 72);  // chooses a number between 65 and 70 which is the corresponding ascii values for A to G   
                    V_starting_pos = rnd.Next(1, 11); // chooses a number between 1 and 10

                    repeat = H_checkLocation(H_starting_pos, V_starting_pos, 4); // checks the locations.  returning true, it will generate new locations. returning false would break the loop
                }
                H_addLocation(false, H_starting_pos, V_starting_pos, 4);// if repeat is set to false by the check location function, then it adds to the ship array

            }

            else if (H_or_V == 2) // ship placed vertically
            {

                while (repeat == true)
                {
                    H_starting_pos = rnd.Next(65, 75);  // chooses a number between 65 and 75 which is the corresponding ascii values for A to J   
                    V_starting_pos = rnd.Next(1, 8); // chooses a number between 1 and 7

                    repeat = V_checkLocation(H_starting_pos, V_starting_pos, 4); // checks the locations.  returning true, it will generate new locations. returning false would break the loop
                }
                V_addLocation(false, H_starting_pos, V_starting_pos, 4); // if repeat is set to false by the check location function, then it adds to the ship array
            }
        }
        public void Cruiser_and_Submarine(Random rnd)
        {
            int H_or_V = rnd.Next(1, 3);    // randomly generaters if the ship should be vertical or horizontal
            int H_starting_pos = 0;
            int V_starting_pos = 0;
            bool repeat = true;
            if (H_or_V == 1)  // ship placed horizontally
            {
                while (repeat == true)
                {
                    H_starting_pos = rnd.Next(65, 73);  // chooses a number between 65 and 72 which is the corresponding ascii values for A to H   
                    V_starting_pos = rnd.Next(1, 11); // chooses a number between 1 and 10

                    repeat = H_checkLocation(H_starting_pos, V_starting_pos, 3);
                }
                H_addLocation(false, H_starting_pos, V_starting_pos, 3);

            }
            else if (H_or_V == 2) // ship placed vertically
            {
                while (repeat == true)
                {
                    H_starting_pos = rnd.Next(65, 75);  // chooses a number between 65 and 75 which is the corresponding ascii values for A to J   
                    V_starting_pos = rnd.Next(1, 9); // chooses a number between 1 and 8

                    repeat = V_checkLocation(H_starting_pos, V_starting_pos, 3);
                }

                V_addLocation(false, H_starting_pos, V_starting_pos, 3);
            }
        }
        public void Destroyer(Random rnd)
        {
            int H_or_V = rnd.Next(1, 3);    // randomly generaters if the ship should be vertical or horizontal
            int H_starting_pos = 0;
            int V_starting_pos = 0;
            bool repeat = true;
            if (H_or_V == 1)  // ship placed horizontally
            {
                while (repeat == true)
                {
                    H_starting_pos = rnd.Next(65, 74);  // chooses a number between 65 and 70 which is the corresponding ascii values for A to H   
                    V_starting_pos = rnd.Next(1, 11); // chooses a number between 1 and 10

                    repeat = H_checkLocation(H_starting_pos, V_starting_pos, 2);
                }
                H_addLocation(false, H_starting_pos, V_starting_pos, 2);

            }
            else if (H_or_V == 2) // ship placed vertically
            {
                while (repeat == true)
                {
                    H_starting_pos = rnd.Next(65, 75);  // chooses a number between 65 and 75 which is the corresponding ascii values for A to G   
                    V_starting_pos = rnd.Next(1, 10); // chooses a number between 1 and 7

                    repeat = V_checkLocation(H_starting_pos, V_starting_pos, 2);
                }

                V_addLocation(false, H_starting_pos, V_starting_pos, 2);
            }
        }
        public bool H_checkLocation(int H_starting_pos, int V_starting_pos, int shipLength)  // function which checks the locations
        {
            int H_check = H_starting_pos;
            int V_check = V_starting_pos; // making new variables so it does not override when checking for duplicates
            int x = 0;
            while (x < shipLength)  // checks until it has reached the length of the ship
            {
                string location = char.ConvertFromUtf32(H_check) + V_check + "_" + player; // makes a variable which holds the location
                for (int i = 0; i < ship.Length; i++)// loops until the end of the array
                {
                    if (location == ship[i])  // if there is a match, it returns true
                    {
                        return true;
                    }
                }
                H_check++;// next horziontal location
                x++;  // adds another value

            }
            return false;  // if there isnt a match it will return false
        }
        public bool V_checkLocation(int H_starting_pos, int V_starting_pos, int shipLength) // function which checks the locations
        {
            int H_check = H_starting_pos;
            int V_check = V_starting_pos;  // making new variables so it does not override when checking for duplicates
            int x = 0;
            while (x < shipLength)  // checks until it has reached the length of the ship
            {
                string location = char.ConvertFromUtf32(H_check) + V_check + "_" + player; // makes a variable which holds the location
                for (int i = 0; i < ship.Length; i++)  // loops until the end of the array
                {
                    if (location == ship[i]) // if there is a match, it returns true
                    {
                        return true;
                    }
                }
                V_check++; // next vertical location
                x++; // adds another value
            }
            return false; // if there isnt a match it will return false
        }

        public void H_addLocation(bool repeat, int H_starting_pos, int V_starting_pos, int limit)
        {
                int lowerPointer = 0;
                for (int j = 0; j < 16; j++)
                {
                    if (ship[j] == null)  // gets the lowest index which is empty
                    {
                        lowerPointer = j; 
                        break;
                    }
                }
                for (int j = lowerPointer; j < lowerPointer + limit; j++)  // loop which records the location of the ship and goes to the next vertical tile
                {
                    string location = char.ConvertFromUtf32(H_starting_pos) + V_starting_pos + "_" + player;
                    ship[j] = location;
                    H_starting_pos++;
                }
        }
        public void V_addLocation(bool repeat, int H_starting_pos, int V_starting_pos, int limit)
        {

            int lowerPointer = 0;
            for (int j = 0; j < 16; j++)  // gets the lowest index which is empty
            {
                if (ship[j] == null)
                {
                    lowerPointer = j;
                    break;
                }
            }
            for (int j = lowerPointer; j < lowerPointer + limit; j++)  // loop which records the location of the ship and goes to the next vertical tile
            {
                string location = char.ConvertFromUtf32(H_starting_pos) + V_starting_pos + "_" + player;
                ship[j] = location;
                V_starting_pos++;
            }

        }
        public string[] GetLocation()
        {
            return ship;
        }
        // debugging purposes
        public void printLocation() // prints out the location of the ship to the console 
        {
            foreach (var item in ship)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("");
        }
    }

}

