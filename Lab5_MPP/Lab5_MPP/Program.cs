using System;

namespace Lab1_MPP
{
    class Program
    {
        static int[,] GetRandArr()
        {
            const
                int SIZE = 10,
                    MIN_VALUE = 100,
                    MAX_VALUE = 999;

            Random rand = new Random();
            int[,] outdata = new int[SIZE, SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    outdata[i, j] = rand.Next(MIN_VALUE, MAX_VALUE);
                    Console.Write(outdata[i, j] + " ");
                }
                Console.WriteLine();
            }
            return outdata;
        }

        static void Main(string[] args)
        {
            int[,] first_arr = GetRandArr();
            Console.WriteLine("\n+\n");
            int[,] second_arr = GetRandArr();
            Console.WriteLine("\n________________________________________\n");
            //Res

        }
    }
}
