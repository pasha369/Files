using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MyServer
{
    [ServiceContract]
    public interface IMyMath
    {
        [OperationContract]
        int Add(int a, int b);
    }
    public  class MyMath: IMyMath
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(MyMath));
            sh.AddServiceEndpoint(
                typeof (IMyMath),
                new WSHttpBinding(),
                "http://localhost:9090/MyMath/ep1"
                );
            sh.Open();
            Console.WriteLine("For over click <ENTER>");
            Console.ReadLine();
            sh.Close();

        }
    }
}
