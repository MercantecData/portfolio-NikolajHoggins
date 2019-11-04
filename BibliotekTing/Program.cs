using System;

namespace BibliotekTing
{
    class Program
    {
        static void Main(string[] args)
        {
            var src = DateTime.Now;
            var hm = new DateTime(src.Year, src.Month, src.Day, src.Hour, src.Minute, 0);
            Console.WriteLine(DateTime.Now.Day);

        }
    }
}
