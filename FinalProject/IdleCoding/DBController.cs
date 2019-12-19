using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdleCoding
{
    class DBController
    {
        //Hent Mysql.data fra NuGet, skulle det ikke automatisk ske.
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBController()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            Console.WriteLine("Please specifiy database info.\n");
            Console.Write("Hostname [Default: localhost]: ");
            
            //If the new host is not empty it will use that as host, if it is, it will use the default
            //To-do: Change this to ?? operator.
            String newHost = Console.ReadLine();
            if(newHost != "")
            {
                server = newHost;
            } else { server = "localhost"; }

            database = "";
            //Make sure the user enters a database, to avoid errors.
            while(database == "")
            {
                Console.Write("Database: ");
                database = Console.ReadLine();
            }

            //Same as hostname, but with username
            Console.Write("mysql username [Default: root]: ");
            String newUser = Console.ReadLine();
            if (newUser != "")
            {
                uid = newUser;
            }
            else
            {
                uid = "root";
            }
            Console.Write("Password [Default is no password]: ");
            password = Console.ReadLine();

            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
            Console.Clear();
            Console.WriteLine("Reset/Set up database? Use this is it's your first time running the program or if you want to reset scores");
            Console.WriteLine("If your database isn't set up correct it can result in errors. [y/n]");
            ConsoleKeyInfo answer = Console.ReadKey();
            if (answer.Key == ConsoleKey.Y || answer.Key == ConsoleKey.Enter)
            {
                DatabaseSetup();
            }
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException e)
            {

                switch (e.Number)
                {
                    case 0:
                        Console.WriteLine("Error occured, try check inputs or play without saves.");
                        break;
                    case 1042:
                        Console.WriteLine("Cannot resolve hostname, try again");
                        break;
                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                Environment.Exit(100);
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        private void DatabaseSetup()
        {
            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd;
                String[] queryList = {"DROP TABLE IF EXISTS saves" ,
                    "DROP TABLE IF EXISTS users",
                    "CREATE TABLE users(id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY, name VARCHAR(30) UNIQUE NOT NULL , password VARCHAR(30) NOT NULL)",
                    "CREATE TABLE saves(save_id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY, user_id INT UNSIGNED, cash INT NOT NULL, clickmulti INT NOT NULL, item1 INT NOT NULL, FOREIGN KEY (user_id) REFERENCES users(id) ON DELETE CASCADE)"};

                foreach(String query in queryList)
                {
                    cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
 

                Console.WriteLine("Database set up");

                
                //close connection
                this.CloseConnection();
            }
        }
        //Insert statement
        public int CreateUser()
        {
            Console.Clear();
            String name = "";
            //If the username is empty or the user already exists, we want to try again
            while (name == "" || checkUserName(name))
            {
                Console.Write("Enter username: ");
                name = Console.ReadLine();
                if (checkUserName(name))
                {
                    Console.WriteLine("Username taken..\n");
                }
            }

            Console.Write("Enter password: ");
            String password = Console.ReadLine();
            
            //To-do: Create password encryption function that will be used when creating user, and when validating password
            string query = "INSERT INTO users (name, password) VALUES('"+name+"', '"+password+"')";
            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);
                Console.WriteLine("Creating user..");

                //Execute command
                cmd.ExecuteNonQuery();

                long lastInsert = cmd.LastInsertedId;
                int userID = Convert.ToInt32(lastInsert);
                //close connection
                this.CloseConnection();
                return userID;
                
            }
            else
            {
                return 0;
            }
        }

        //Checks how many rows contain the username given, if any is found, returns true.
        private bool checkUserName(String username)
        {
            if(username == "")
            {
                return false;
            }

            
            string query = "SELECT COUNT(*) FROM users WHERE name = '"+username+"'";
            //open connection
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command and put amount in int
                int count = int.Parse(cmd.ExecuteScalar() + "");
                this.CloseConnection();
                if(count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
            
        }
        //Update statement
        public void Update()
        {
            string query = "UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete()
        {
            string query = "DELETE FROM tableinfo WHERE name='John Smith'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Select statement
        public List<string>[] Select()
        {
            string query = "SELECT * FROM tableinfo";

            //Create a list to store the result
            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["id"] + "");
                    list[1].Add(dataReader["name"] + "");
                    list[2].Add(dataReader["age"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }
    }
}
