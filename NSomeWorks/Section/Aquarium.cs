using System;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks.Section
{
    class Aquarium : ISection
    {
        private Animal[] _animals;

        private Habitat _habitat;

        public Aquarium()
        {
            _habitat = Habitat.Aquarium;
            _animals = new Animal[0];
        }

        public string AddAnimal(Animal animal)
        {
            if (animal.GetHabitat() == _habitat)
            {
                Animal[] tempAnimal = _animals;
                _animals = new Animal[_animals.Length + 1];
                for (int i = 0; i < tempAnimal.Length; i++)
                {
                    _animals[i] = tempAnimal[i];
                }

                _animals[_animals.Length - 1] = animal;
                return "Добавлено в аквариум " + animal.Name;
            }
            else
            {
                return "Не подходящая среда обитания";
            }
        }

        public (string, int)[] CountEachKind()
        {
            (string, int)[] countEachKind = new (string, int)[0];

            for (int i = 0; i < _animals.Length; i++)
            {
                if (countEachKind.Length == 0)
                {
                    countEachKind = countEachKind.Add((_animals[i].Name, 1));
                    continue;
                }

                for (int j = 0; j < countEachKind.Length; ++j)
                {
                    if (countEachKind[j].Item1 == _animals[i].Name)
                    {
                        countEachKind[j].Item2++;
                        break;
                    }

                    if (j == countEachKind.Length - 1)
                    {
                        countEachKind = countEachKind.Add((_animals[i].Name, 1));
                        break;
                    }
                }
            }

            return countEachKind;
        }

        public Animal[] GetAnimals()
        {
            return _animals;
        }

        public string GetName()
        {
            return "Аквариум";
        }
    }
}
