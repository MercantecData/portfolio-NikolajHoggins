using System;

/// <summary>
/// 
///     ====Big todo====
/// 
/// - Re-Write Buy menu
/// 
/// - Create Save data function
/// 
/// - Load data on login
/// 
/// - Add quick explanation in start of game
/// 
/// - Create start menu animation
/// 
/// </summary>
namespace IdleCoding
{
    class Program
    {
        static bool running;
        static Game game;
        static void Main(string[] args)
        {
            //Prints the titlescreen
            GUI.gameIntro();
            Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            
            //Ask if the user want to use the save system, if not it skips all database stuff.
            Console.WriteLine("Would you like to use saves? [y/n]");
            ConsoleKeyInfo answer = Console.ReadKey();
            Console.Clear();
            if (answer.Key == ConsoleKey.Y || answer.Key == ConsoleKey.Enter)
            {
                //Initialises the database, and runs connections settings.
                DBController db = new DBController();
                Console.Clear();
                Console.WriteLine("1) Log in");
                Console.WriteLine("2) Create user");
                Console.WriteLine("3) Don't use the system :/");
                ConsoleKey accountAnswer;
                bool validAnswer = false;
                int userid = 0;
                while (!validAnswer)
                {
                    accountAnswer = Console.ReadKey().Key;
                    if (accountAnswer == ConsoleKey.D1)
                    {
                        userid = db.loginUser();
                        validAnswer = true;
                    }
                    else if(accountAnswer == ConsoleKey.D2)
                    {
                        userid = db.CreateUser();
                        validAnswer = true;
                    }
                    else if (accountAnswer == ConsoleKey.D3)
                    {
                        validAnswer = true;
                    }
                }
                
                Console.WriteLine("id: " + userid);
                Console.ReadLine();

            }
            else
            {

            }








            Console.Clear();
            game = new Game();
            game.Start();

            running = true;

            while (running)
            {
                // check for user input
                checkInput(Console.ReadKey(true).Key);
            }

            // wait for the task to finish before exiting
            game.task.Wait();

            Console.WriteLine("Hello World!");
        }
        static void checkInput(ConsoleKey input)
        {
            //To-do: rewrite to less repetetive code by doing a try parse and then using that number directly in sendbuy function.
            switch (input)
            {
                case ConsoleKey.Escape:
                    Console.WriteLine("\nQuit called from main thread");

                    game.Stop();
                    running = false;
                    break;
                case ConsoleKey.D1:
                    sendBuy(game, 1);
                    break;
                case ConsoleKey.D2:
                    sendBuy(game, 2);
                    break;
                case ConsoleKey.D3:
                    sendBuy(game, 3);
                    break;
                case ConsoleKey.D4:
                    sendBuy(game, 4);
                    break;
                case ConsoleKey.D5:
                    sendBuy(game, 5);
                    break;
                case ConsoleKey.D0:
                    game.upgradeClick();
                    break;
                case ConsoleKey.UpArrow:
                    game.cash += 100000;
                    break;
                case ConsoleKey.DownArrow:
                    game.cash = 0;
                    break;
                default:
                    game.cash += 1*game.clickMulti;
                    break;
            }
        }

        //This function calls the purchaseItem function in the Game object with the id representing the button pressed
        static void sendBuy(Game game, int id)
        {
            double itemCost = Game.getCost(id, game.items, game.ownedItems);
            if (itemCost < game.cash)
            {
                game.purchaseItem(id);
                game.cash -= itemCost;
            }
        }
    }
}



