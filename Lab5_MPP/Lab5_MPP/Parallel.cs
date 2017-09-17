using System;
using System.Threading.Tasks;

namespace Lab5_MPP
{
    public class Parallel
    {
        public static void WaitAll(MyDelegate[] indata)
        {
            var task_list = new Task[indata.Length];
            for (int i = 0; i < indata.Length; i++)
                task_list[i] = Task.Run(new Action(indata[i]));

            for (int i = 0; i < indata.Length; i++)
                task_list[i].Wait();
        }
    }
}
