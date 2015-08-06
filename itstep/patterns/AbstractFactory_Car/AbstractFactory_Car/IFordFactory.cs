using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_Car
{
    interface IFordFactory
    {
        IFamilyCar getFamilyCar();
        ISportCar getSportCar();
    }
}
