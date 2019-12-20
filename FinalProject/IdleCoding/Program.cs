using System;
using System.Threading;

/// <summary>
/// 
///     ====Big todo====
/// 
/// 0 - Re-Write Buy menu
/// 
/// 5 - check if save exists before saving
/// 
/// 4 - Load data on login
/// 
/// 3 - Add quick explanation in start of game
/// 
/// 1 - Create start menu animation
/// 
/// 0 - Add time played to save
/// </summary>
namespace IdleCoding
{
    class Program
    {
        static bool running;
        static Game game;
        static DBController db;
        static int[] itemcounts = new int[5];
        static bool newUser = true;
        static void Main(string[] args)
        {
            //Prints the titlescreen
            GUI.gameIntro();
            //Initialise the game.
            game = new Game();
            Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            
            //Ask if the user want to use the save system, if not it skips all database stuff.
            Console.WriteLine("Would you like to use saves? This function requires a database ready for use [y/n] [default: y]");
            ConsoleKeyInfo answer = Console.ReadKey();
            Console.Clear();
            if (answer.Key == ConsoleKey.Y || answer.Key == ConsoleKey.Enter)
            {
                //Initialises the database, and runs connections settings.
                game.useSaves = true;
                //In the future i would have initialized the database connection inside the game for easier and more "tidy" access, but it's last moment though. Migrating to game object would take too long.
                db = new DBController();

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
                        newUser = false;
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
                game.userId = userid;

            }
            Console.Clear();
            Console.WriteLine("You play this game by clicking the letter keys on your keyboards, this action earns you 'lines of code'.");
            Console.WriteLine("Lines of Code is the games currency.");
            Console.WriteLine("\nBuy menu (will show ingame): Use the buttons 1-5 to buy items, these items automatically generate lines of code. \nPressing 0 will buy a clicker upgrade meaning your normal click will give more income pr. click. Lastly, esc will close the game, and save if saves has been enabled");
            Console.WriteLine("\n\nPress enter to continue...");
            Console.ReadLine();
            Console.Clear();
            //This goes into the game object and runs the Start funtions, which starts the main loop.
            game.Start();
            if(game.userId != 0 && !newUser)
            {
                int[] queryReturn = db.GetData(game.userId);
                int[] itembuys = { queryReturn[2], queryReturn[3], queryReturn[4], queryReturn[5], queryReturn[6], }; 
                game.loadData(queryReturn[0], queryReturn[1], itembuys);
            }
            running = true;

            while (running)
            {
                // check for user input
                checkInput(Console.ReadKey(true).Key);
            }

            // wait for the task to finish before exiting
            game.task.Wait();
            Console.Clear();
            Console.WriteLine("Thanks for playing!");
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
                    if (game.userId != 0)
                    {
                        int[] data = game.getSaveData();
                        db.CreateSave(game.userId, game.getSaveData());
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
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



