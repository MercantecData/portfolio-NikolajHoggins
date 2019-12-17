/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;

namespace NotifierBot
{
    class Program
    {
        static bool _running;
        static Bot _bot;
        public static int i;
        static void Main()
        {
            _bot = new Bot();
            _bot.Start();

            _running = true;

            while (_running)
            {
                // check for user input
                checkInput(Console.ReadKey().KeyChar);
            }

            // wait for the task to finish before exiting
            _bot._task.Wait();
        }


        static void checkInput(char input)
        {
            i++;

            if (input == 'q')
            {
                Console.WriteLine("\nQuit called from main thread");

                _bot.Stop();
                _running = false;

            }
        }
    }

    public class Bot
    {
        // we use Task.Factory to start a gameloop on a different thread. this allows the console to listen to user input events like 'q' 
        // as per
        // http://stackoverflow.com/questions/4576982/are-there-best-practices-for-implementing-an-asynchronous-game-engine-loop        

        CancellationTokenSource _cts;
        public Task _task;
        int i = 0;
        public void Start()
        {
            Console.WriteLine("\tBot Started");
            if (_cts == null)
            {
                _cts = new CancellationTokenSource();


                _task = Task.Factory.StartNew(() => Loop(_cts.Token), _cts.Token);
            }
        }

        private void Loop(CancellationToken token)
        {
            // The core loop
            Console.WriteLine("\tLoop started");


            while (!token.IsCancellationRequested)
            {

                token.ThrowIfCancellationRequested();
                Thread.Sleep(20);
                Console.WriteLine(Program.i);
            }

            Console.WriteLine("\tLoop ending");
        }
        public void Add()
        {
            i++;
        }
        public void Stop()
        {
            Console.WriteLine("\tStop called");

            if (_cts != null)
            {
                _cts.Cancel();
                _cts = null;
            }
        }
    }
}


*/