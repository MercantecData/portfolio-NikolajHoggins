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
        public List<Item> items = new List<Item>();
        public List<Item> ownedItems = new List<Item>();

        public void Start()
        {
            cash = 1000;
            Console.WriteLine("Game started");
            AddGameItems();
            purchaseItem(1);
            if (cts == null)
            {
                cts = new CancellationTokenSource();

                //Tager vores Method Loop, og laver den til et object der kan køre async.
                task = Task.Factory.StartNew(() => Loop(cts.Token), cts.Token);
            }
        }

        private void Loop(CancellationToken token)
        {
            // The core loop
            Console.WriteLine("Game Loop started");
            int sec = 0;
            double sEarn = 0;
            while (!token.IsCancellationRequested)
            {
                double currentMoney = cash;
                int i = 0;
                int runtime = 20;
                GUI.drawBuyMenu(items, ownedItems);

                while (i < 1000 / runtime)
                {
                    
                    token.ThrowIfCancellationRequested();
                    Console.ForegroundColor = ConsoleColor.Green;
                    GUI.drawPC((int)Math.Round(cash));
                    foreach (Item item in ownedItems)
                    {
                        cash += (item.earning/1000)*runtime;
                    }

                    if (sEarn < 0) { sEarn = 0; }
                    Console.WriteLine("Lines/Sec: " + Math.Round(sEarn,2).ToString() + "                     ");
                    Console.WriteLine("Lines of code: " + Math.Round(cash,2) + "                        ");
                    Console.WriteLine("Sec: " + sec);
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

        private void AddGameItems()
        {
            items.Add(new Item(1, "Python Script", 100, 0.4));
            items.Add(new Item(2, "Machine Learning", 1000, 1500));
            items.Add(new Item(3, "AI Super Computer", 20000000, 50000));
        }

        public void purchaseItem(int id)
        {
            ownedItems.Add(items.Find(delegate (Item i)
            {
                return i.itemID == id;
            }));
        }

        public static int countItem(int id, List<Item> ownedItems)
        {
            int count = 0;
            foreach(Item item in ownedItems)
            {
                if(item.itemID == id)
                {
                    count++;
                }
            }
            return count;
        }

        public static double getCost(int id, List<Item> items, List<Item> ownedItems)
        {
            foreach (Item item in items)
            {
                if (item.itemID == id)
                {
                    return item.price+(item.price*countItem(id, ownedItems)*0.1);
                }
                
            }
            return 0;
        }
    }
}
