using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace homework_1._3
{
    class Program
    {
        
           
        static void Main(string[] args)
        {

            ThreadStart threadstart = new ThreadStart(detect_click);
            Thread click = new Thread(threadstart);

            click.Start();
            
        }

        public static void detect_click()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("Press any key");
            while (true)
            {
                if (Console.KeyAvailable == true)
                {
                    break;
                    stopwatch.Stop();
                    
                }
            }
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
            Thread.CurrentThread.Suspend();
        }
    }
}
