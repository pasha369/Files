using System;

namespace Adapter_ToString
{
    class Program
    {
        static void Main(string[] args)
        {
            IStringAdapter adapter = new LcdAdapter();

            var data = Console.ReadLine();
            adapter.GetData(data);

            Console.ReadLine();
        }
    }
}
