using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Hosting
{
    class Program
    {

        static void Main(string[] args)
        {

            ServiceHost sh = new ServiceHost(typeof(Autorize));
            sh.Open();
            Console.WriteLine("Press any key for over");
            Console.Read();
            sh.Close();
            
        }
    }
}
