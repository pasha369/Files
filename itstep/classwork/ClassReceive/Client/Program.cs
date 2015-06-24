using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.ServiceReference1;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMathClient mathClient = new MyMathClient();
            MathResult resulr = mathClient.Total(0, 0);
            Console.WriteLine(" +: {0}", resulr.sum);
            Console.WriteLine(" -: {0}", resulr.subtr);
            Console.WriteLine(" /: {0}", resulr.div);
            Console.WriteLine(" *: {0}", resulr.mult);
            Console.Read();
        }
    }
}
