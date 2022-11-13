using System;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks
{
    class ElectroCar : Car
    {
        private int _batteryStatus;

        public ElectroCar(string name, int mileage, TypeTires typeTires, int batteryStatus)
            : base(name, mileage, typeTires)
        {
            _batteryStatus = batteryStatus;
        }

        public override void Move()
        {
            Console.WriteLine($"{Name} електромобиль поехал");
        }
    }
}
