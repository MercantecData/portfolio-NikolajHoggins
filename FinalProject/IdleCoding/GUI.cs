﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IdleCoding
{
    class GUI
    {
        public static void gameIntro()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            String[] greetings = { "Welcome to", "A game by Nikolaj Hoggins", "Press enter to continue..." };
            PrintName();
            Console.SetCursorPosition(14 , 7);
            Console.WriteLine(greetings[0]);
        }

        private static void PrintName() {
            String[] gameName = {
                "    ______        __  __                   ______                    __ __                         "
                , "/      |      /  |/  |                 /      \\                 /  |/  |                    "
                , "     $$$$$$/   ____$$ |$$ |  ______        /$$$$$$  |  ______    ____$$ |$$/  _______    ______        "
                , "  $$ |   /    $$ |$$ | /      \\       $$ |  $$/  /      \\  /    $$ |/  |/       \\  /      \\ "
                , "  $$ |  /$$$$$$$ |$$ |/$$$$$$  |      $$ |      /$$$$$$  |/$$$$$$$ |$$ |$$$$$$$  |/$$$$$$  |"
                , "  $$ |  $$ |  $$ |$$ |$$    $$ |      $$ |   __ $$ |  $$ |$$ |  $$ |$$ |$$ |  $$ |$$ |  $$ |"
                , " _$$ |_ $$ \\__$$ |$$ |$$$$$$$$/       $$ \\__/  |$$ \\__$$ |$$ \\__$$ |$$ |$$ |  $$ |$$ \\__$$ |"
                , "/ $$   |$$    $$ |$$ |$$       |      $$    $$/ $$    $$/ $$    $$ |$$ |$$ |  $$ |$$    $$ |"
                , "$$$$$$/  $$$$$$$/ $$/  $$$$$$$/        $$$$$$/   $$$$$$/   $$$$$$$/ $$/ $$/   $$/  $$$$$$$ |"
                , "                                                                                  /  \\__$$ |"
                , "                                                                                  $$    $$/ "
                , "                                                                                   $$$$$$/  "};
            int lineNr = 0;
            foreach(String line in gameName)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - line.Length/2, Console.WindowHeight/2-gameName.Length/2+lineNr);
                Console.WriteLine(line);
                lineNr++;
            }
        }
        //Quikc GUI function that animates a computer typing for a "coding" effect
        public static void drawPC(int i)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(0,0);
            if (i % 2 == 0)
            {
                Console.WriteLine("   ._________________.");
                Console.WriteLine("   |.---------------.|");
                Console.WriteLine("   || x      1      ||");
                Console.WriteLine("   ||    0     c#   ||");
                Console.WriteLine("   ||  1      1     ||");
                Console.WriteLine("   ||     if 1  1   ||");
                Console.WriteLine("   ||         1  0  ||");
                Console.WriteLine("   ||____{_______1__||");
                Console.WriteLine("   /.-___-.-.-.-.__-.\\");
                Console.WriteLine("  /.-.-.-._.-.___.-.-.\\");
                Console.WriteLine(" /.-._.-__.-._.-._.-.-.\\");
                Console.WriteLine("/______/__________\\___o_\\");
                Console.WriteLine("\\_______________________/");
            }
            else
            {
                Console.WriteLine("   ._________________.");
                Console.WriteLine("   |.---------------.|");
                Console.WriteLine("   || x    0     1  ||");
                Console.WriteLine("   ||   0    ] }    ||");
                Console.WriteLine("   ||      1   1    ||");
                Console.WriteLine("   ||   {       0   ||");
                Console.WriteLine("   ||     s   1  x  ||");
                Console.WriteLine("   ||___m____f__0___||");
                Console.WriteLine("   /.-.-__._-._.-.-.-\\");
                Console.WriteLine("  /._.__-.-.-.-____.-.\\");
                Console.WriteLine(" /.-.-._.___._.-._.-.-.\\");
                Console.WriteLine("/______/__________\\___o_\\");
                Console.WriteLine("\\_______________________/");
            }

        }
        public static String getBit()
        {
            String[] bits = new String[] { "1", "0", " ", " ", " ", "[", "}", "{", "/" };
            Random rnd = new Random();
            return bits[rnd.Next(0, bits.Length)];
        }
        public static void drawBuyMenu(List<Item> items, List<Item> ownedItems, int clickMulti, int clickPrice)
        {
            int currnentLine = 16;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(0, currnentLine);
            foreach (Item item in items)
            {
                int owned = Game.countItem(item.itemID, ownedItems);
                Console.SetCursorPosition(0, currnentLine);
                Console.Write(item.itemID + ")" + item.itemName);
                Console.SetCursorPosition(28, currnentLine);
                Console.WriteLine("Cost: " + Game.getCost(item.itemID, items, ownedItems) + " L/S: " + item.earning);
                currnentLine++;
                Console.SetCursorPosition(0, currnentLine);
                Console.WriteLine("\tOwned: ("+ owned + ") L/S: " + item.earning+" ("+Math.Round(item.earning*owned, 2)+")                       ");
                currnentLine++;
            }
            Console.Write("0) 2x Click Upgrade");
            Console.SetCursorPosition(28, currnentLine);
            Console.WriteLine("Cost: "+5000*clickMulti + " Click earnings: " + clickMulti);
            
        }
    }
}
