using System;

namespace lilletalting
{
    class Program
    {
        static void Main(string[] args)
        {
            //Her har du hvad opgaven siger (0,1,2,3,4,5,6) og hvad eksemplet siger (1,2,3,4,5,6)
            var returnArray = returnFullArrayFrom0(6);
            var returnArray1 = returnFullArrayFrom1(6);

            Console.WriteLine("FROM 0");
            foreach (var item in returnArray)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("FROM 1");
            foreach (var item in returnArray1)
            {
                Console.WriteLine(item);
            }
        }

        static int[] returnFullArrayFrom1(int number)
        {
            int[] array = new int[number];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i + 1;
            }

            return array;
        }

        static int[] returnFullArrayFrom0(int number)
        {
            int[] array = new int[number+1];

            for (int i = 0; i <= array.Length-1; i++)
            {
                array[i] = i;
            }

            return array;
        }
    }
}
