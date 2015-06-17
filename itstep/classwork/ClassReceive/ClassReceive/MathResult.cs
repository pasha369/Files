using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClassReceive
{
    [DataContract]
    public class MathResult
    {
        [DataMember]
        public double sum;
        [DataMember]
        public double subtr;
        [DataMember]
        public double div;
        [DataMember]
        public double mult;


    }
    [ServiceContract]
    public interface IMyMath
    {
        [OperationContract]
        MathResult Total(int x, int y);
        [OperationContract]
        MathResult TotalDouble(double x, double y);
    }
    public class MyMath: IMyMath
    {
        public MathResult Total(int x, int y)
        {
            MathResult mr = new MathResult();
            mr.sum = x + y;
            mr.subtr = x - y;
            mr.div = x / y;
            mr.mult = x * y;
            return mr;
        }
        public MathResult TotalDouble(double x, double y)
        {
            MathResult mr = new MathResult();
            mr.sum = x + y;
            mr.subtr = x - y;
            mr.div = x / y;
            mr.mult = x * y;
            return mr;
        }
    }
}
