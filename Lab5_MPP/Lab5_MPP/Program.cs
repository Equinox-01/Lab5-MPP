using System;
using System.Threading;

namespace Lab5_MPP
{
    public delegate void MyDelegate();

    class Program
    {
       
        static void Func()
        {
            object locker = new object();
            int time_to_sleep = 0;
            lock (locker)
            {
                var rand = new Random((int)DateTime.Now.Ticks);

                time_to_sleep = rand.Next(1000, 5000);

                Console.WriteLine("Процесс заморожен на {0}", time_to_sleep/1000);
                Thread.Sleep(time_to_sleep);
            }
            Console.WriteLine("Процесс возобновлён после паузы в {0}", time_to_sleep / 1000);

        }

        static void Main(string[] args)
        {
            Console.Write("Введите количество потоков - ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("\n");
            MyDelegate[] del_arr = new MyDelegate[n];
            for (int i = 0; i < n; i++)
                del_arr[i] = Func;
            Parallel.WaitAll(del_arr);
            Console.WriteLine("Потоки отработали");
            Console.ReadKey();
        }
    }

}