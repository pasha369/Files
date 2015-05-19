using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace semaphore
{
    class Program
    {
        static void Main(string[] args)
        {
            Semaphore s = new Semaphore(3, 3, "Semaphore");

            for (int i = 0; i < 6; i++)
            {
                ThreadPool.QueueUserWorkItem(SomeMethod, s);
            }
            Console.Read();
        }

        private static void SomeMethod(object state)
        {
            Semaphore s = state as Semaphore;
            bool stop = false;
            s.WaitOne();
            Console.WriteLine("Thread {0} run", Thread.CurrentThread.ManagedThreadId);
            while (true)
            {
                int sum = 1 + 1;
            }

            s.Release(1);   
        }
    }
}
