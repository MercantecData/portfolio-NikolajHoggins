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
        public Item[] items;
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
            int sec = 0;
            double sEarn = 0;
            while (!token.IsCancellationRequested)
            {
                double currentMoney = cash;
                int i = 0;
                int runtime = 10;
                while(i < 1000 / runtime)
                {
                    
                    token.ThrowIfCancellationRequested();
                    Console.SetCursorPosition(0, 0);
                    Console.ForegroundColor = ConsoleColor.Green;
                    GUI.drawPC((int)Math.Round(cash));
                    if(sEarn < 0) { sEarn = 0; }
                    Console.WriteLine("Lines/Sec: " + sEarn.ToString() + "                     ");
                    Console.WriteLine("Lines of code: " + cash);
                    Thread.Sleep(runtime);
                    i++;
                }
                sec++;
                sEarn = cash - currentMoney;
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
