using System;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks
{
    class ICECar : Car
    {
        private int _gasTank;

        public ICECar(string name, int mileage, TypeTires typeTires, int gasTank)
            : base(name, mileage, typeTires)
        {
            _gasTank = gasTank;
        }

        public int GasTank { get; }

        public override void Move()
        {
            Console.WriteLine($"{Name} машина с двигательом внутреннего сгорания поехала");
        }

        public void Refueling(int gasCount)
        {
            _gasTank += gasCount;
            Console.WriteLine($"{Name} заправилась на {gasCount}");
        }
    }
}
