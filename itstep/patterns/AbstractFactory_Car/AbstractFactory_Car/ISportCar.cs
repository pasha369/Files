using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_Car
{
    interface ISportCar
    {
        string Motor { set; get; }
        string Color { set; get; }
        string Shield { set; get; }

        void Display(IPrintable print);
    }


}
