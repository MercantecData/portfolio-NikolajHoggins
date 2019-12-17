using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IdleCoding
{
    class Game
    {
        CancellationTokenSource cts; //undersøg
        public Task task;
        public double cash;

        public void Start()
        {
            Console.WriteLine("Game started");
            if (cts == null)
            {
                cts = new CancellationTokenSource();


                task = Task.Factory.StartNew(() => Loop(cts.Token), cts.Token);
            }
        }

        private void Loop(CancellationToken token)
        {
            // The core loop
            Console.WriteLine("\tLoop started");

            while (!token.IsCancellationRequested)
            {

                token.ThrowIfCancellationRequested();
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Green;
                GUI.drawPC((int) Math.Round(cash));
                Console.WriteLine("L/s: " + "");
                Console.WriteLine("Lines of code: " + cash);
                Thread.Sleep(10);
            }

            Console.WriteLine("\tLoop ending");
        }

        public void Stop()
        {
            Console.WriteLine("\tStop called");

            if (cts != null)
            {
                cts.Cancel();
                cts = null;
            }
        }
    }
}
