using System;

namespace IdleCoding
{
    class Program
    {
        static bool running;
        static Game game;
        static void Main(string[] args)
        {
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



