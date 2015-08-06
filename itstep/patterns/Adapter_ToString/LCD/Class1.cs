using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCD
{
    /// <summary>
    /// Adaptee
    /// </summary>
    public class LcdDisplay
    {
        public void Display(byte[] input)
        {
            Console.WriteLine("LCD Display class");
            Console.WriteLine("Type: {0}", input);
            Console.WriteLine("Data: ");
            foreach (var b in input)
            {
                Console.Write(" {0}", b );
            }
        }
    }
}
