using System;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks
{
    public enum TypeTires
    {
        Summer,
        Winter,
        AllSeason,
        Slick
    }

    class Car : Transport
    {
        private TypeTires _tires;
        public Car(string name, int mileage, TypeTires typeTires)
            : base(name, mileage)
        {
            _tires = typeTires;
        }

        public TypeTires Tires { get; set; }
        public override void Move()
        {
            Console.WriteLine($"{Name} поехала ");
        }

        public void ChangeTires(TypeTires tires)
        {
            _tires = tires;
        }
    }
}
