using System;
using System.Collections.Generic;
using System.Text;

namespace IdleCoding
{
    class GUI
    {
        public static void drawPC(int i)
        {
            if (i%2 == 0)
            {
                Console.WriteLine("   ._________________.");
                Console.WriteLine("   |.---------------.|");
                Console.WriteLine("   || x      0      ||");
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
    }
}
