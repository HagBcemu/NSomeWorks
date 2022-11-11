using System;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks
{
    class AquaticAnimals : Animal
    {
        public AquaticAnimals(string name, int age)
            : base(name, age)
        {
        }

        public override Habitat GetHabitat()
        {
            return Habitat.Aquarium;
        }

        public override void Move()
        {
            Console.WriteLine("Я плаваю");
        }
    }
}
