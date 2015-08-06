using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_Car
{
    class SportCar : ISportCar
    {
        public string Motor { set; get; }
        public string Color { set; get; }
        public string Shield { set; get; }

        public void Display(IPrintable print)
        {
            print.Print(Motor, Color, Shield);
        }
    }
}
