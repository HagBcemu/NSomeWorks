using System;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks.Section
{
    interface ISection
    {
        public string AddAnimal(Animal animal);

        public string GetName();

        public Animal[] GetAnimals();

        public (string, int)[] CountEachKind();
    }
}
