using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lab5_MPP
{
    public class Parallel
    {
        

        public static void WaitAll(MyDelegate[] indata)
        {

            /*var task_list = new Task[indata.Length];
            for (int i = 0; i < indata.Length; i++)
                task_list[i] = Task.Run(new Action(indata[i]));

            for (int i = 0; i < indata.Length; i++)
                task_list[i].Wait();*/
            var locker = new object();
            int i = 0;
            var waitHandler = new AutoResetEvent[indata.Length];
            while (i < indata.Length)
            {

                waitHandler[i] = new AutoResetEvent(false);
                ThreadPool.QueueUserWorkItem(new WaitCallback((s) =>
                {
                    indata[i]();
                    waitHandler[i].Set();
                }));
                i++;
            }
            i = 0;
            lock (locker)
            {
                while (i < indata.Length)
                {
                    waitHandler[i].WaitOne();
                    i++;
                }
            }

        }
    }
}
