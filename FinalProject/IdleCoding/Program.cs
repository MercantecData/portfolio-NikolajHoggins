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
            game.cash++;
            if (input == 'q')
            {
                Console.WriteLine("\nQuit called from main thread");

                game.Stop();
                running = false;

            }
        }
    }
}



