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
                checkInput(Console.ReadKey(true).KeyChar);
            }

            // wait for the task to finish before exiting
            game.task.Wait();

            Console.WriteLine("Hello World!");
        }
        static void checkInput(char input)
        {
            double itemCost = int.MaxValue;
            switch (input)
            {
                case 'q':
                    Console.WriteLine("\nQuit called from main thread");

                    game.Stop();
                    running = false;
                    break;
                case '1':
                    itemCost = Game.getCost(1, game.items, game.ownedItems);
                    if(itemCost < game.cash)
                    {
                        game.purchaseItem(1);
                        game.cash -= itemCost;
                    }
                    break;
                case '2':
                    itemCost = Game.getCost(2, game.items, game.ownedItems);
                    if (itemCost < game.cash)
                    {
                        game.purchaseItem(2);
                        game.cash -= itemCost;
                    }
                    break;
                default:
                    game.cash++;
                    break;
            }
        }
    }
}



