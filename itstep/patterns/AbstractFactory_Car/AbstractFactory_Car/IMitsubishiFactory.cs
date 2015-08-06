using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_Car
{
    interface IMitsubishiFactory
    {
        IFamilyCar getFamilyCar();
        ISportCar getSportCar();
    }
}
