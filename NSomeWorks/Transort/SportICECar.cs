using System;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks
{
    class SportICECar : ICECar
    {
        private int _downForse;

        public SportICECar(string name, int mileage, TypeTires typeTires, int gasTank, int downForse)
            : base(name, mileage, typeTires, gasTank)
        {
            _downForse = downForse;
        }

        public override void Move()
        {
            base.Move();
            Console.WriteLine($"Спорткар поехал");
        }
    }
}
