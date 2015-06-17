using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MyClient
{
    [ServiceContract]
    public interface IMyMath
    {
        [OperationContract]
        int Add(int a, int b);
    }
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IMyMath> factory = new ChannelFactory<IMyMath>(
                new WSHttpBinding(),
                new EndpointAddress("http://localhost:9090/MyMath/ep1"));
            IMyMath channel = factory.CreateChannel();
            int result = channel.Add(22, 33);
            Console.WriteLine("Result: {0}", result);
            Console.WriteLine("For over click <Enter>");
            Console.ReadLine();
            factory.Close();
        }
    }
}
