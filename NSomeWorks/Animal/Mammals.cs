using System;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks
{
    class Mammals : Animal
    {
        public Mammals(string name, int age)
            : base(name, age)
        {
        }

        public override Habitat GetHabitat()
        {
            return Habitat.Aviary;
        }

        public override void Move()
        {
            Console.WriteLine("Я бегаю по суши");
        }
    }
}
