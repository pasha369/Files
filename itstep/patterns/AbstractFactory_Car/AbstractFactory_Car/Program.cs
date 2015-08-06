using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_Car
{
    interface IPrintable
    {
        void Print(string Motor, string Color, string Shield);
    }

    class Printable: IPrintable
    {
         public void Print(string Motor, string Color, string Shield)
         {
             Console.WriteLine("---------------------");
             Console.WriteLine("motor: {0}",  Motor);
             Console.WriteLine("color: {0}",  Color);
             Console.WriteLine("sheild: {0}", Shield);
             Console.WriteLine("---------------------");
         }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IFordFactory fordFactory = new FordFactory();
            IMitsubishiFactory mitsubishiFactory = new MitsubishiFactory();

            IFamilyCar fordFamilyCar = fordFactory.getFamilyCar();
            ISportCar fordSportCar = fordFactory.getSportCar();
            IFamilyCar mFamilyCar = mitsubishiFactory.getFamilyCar();
            ISportCar mSportCar = mitsubishiFactory.getSportCar();

            Console.WriteLine("Ford");
            fordSportCar.Display(new Printable());
            fordFamilyCar.Display(new Printable());
            Console.WriteLine("Mitsubishi");
            mFamilyCar.Display(new Printable());
            mSportCar.Display(new Printable());
            Console.Read();
        }
    }
}
