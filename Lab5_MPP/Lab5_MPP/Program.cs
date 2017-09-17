using System;
using System.Threading;

namespace Lab5_MPP
{
    public delegate void MyDelegate();

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество потоков - ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("\n");
            MyDelegate[] del_arr = new MyDelegate[n];
            for (int i = 0; i < n; i++)
                del_arr[i] = () => 
                {
                    Console.WriteLine("Информация об исполняющем потоке:");
                    Console.WriteLine("Организационный ID потока - " + Thread.CurrentThread.ManagedThreadId);
                    Console.WriteLine("Имя потока - " + Thread.CurrentThread.Name);
                    Console.WriteLine("Приоритет потока - " + Thread.CurrentThread.Priority);
                    Console.WriteLine("Состояние потока - " + Thread.CurrentThread.ThreadState);
                    Console.WriteLine("Поток фоновый - " + ((Thread.CurrentThread.IsBackground) ? "Да":"Нет"));
                    Console.WriteLine("\n");
                };
            Parallel.WaitAll(del_arr);
            Console.WriteLine("Потоки отработали");
            Console.ReadKey();
        }
    }

}