using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_Car
{
    class FordFactory : IFordFactory
    {
        public IFamilyCar _familyCar;
        public ISportCar _sportCar;

        public FordFactory()
        {
            _familyCar = new FamilyCar()
            {
                Color = "--",
                Motor = "--",
                Shield = "--"
            };
            _sportCar = new SportCar()
            {
                Color = "--",
                Motor = "--",
                Shield = "--"
            };
        }

        public IFamilyCar getFamilyCar()
        {
            return this._familyCar;
        }

        public ISportCar getSportCar()
        {
            return this._sportCar;
        }

    }
}
