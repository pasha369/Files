using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainofResp_Line
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number: ");
        }
    }



    abstract class LineHandler
    {
        public static int n;
        public string _line;
        public LineHandler state;

        public abstract void SetState(LineHandler state);
        public abstract LineHandler GetState(int numLine);

    }

    class LineConcreteHandler : LineHandler
    {
        public override void SetState(LineHandler _state)
        {
            this.state = _state;
            n++;
        }

        public override LineHandler GetState(int numLine)
        {
            if (n != numLine)
            {
                GetState(n);
            }
            state = null;

            return this; 
        }
    }
}
