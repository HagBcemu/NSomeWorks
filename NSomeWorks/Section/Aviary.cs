using System;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks.Section
{
    class Aviary : ISection
    {
        private Animal[] _animals;

        private Habitat _habitat;

        public Aviary()
        {
            _habitat = Habitat.Aviary;
            _animals = new Animal[0];
        }

        public string AddAnimal(Animal animal)
        {
            if (animal.GetHabitat() == _habitat)
            {
                    if (_animals.Length != 0)
                    {
                        if (animal is Herbivores)
                        {
                            if (_animals[0] is Herbivores)
                            {
                            Animal[] tempAnimal = _animals;
                            _animals = new Animal[_animals.Length + 1];

                            for (int i = 0; i < tempAnimal.Length; i++)
                            {
                                _animals[i] = tempAnimal[i];
                            }

                            _animals[_animals.Length - 1] = animal;
                            return "Добавлено в вольер " + animal.Name;
                        }
                            else
                            {
                                return "Травоядных в вольер с хижниками не добавляем";
                            }
                        }

                        if (_animals[0] is PredatoryBeast)
                        {
                            Animal[] tempAnimal = _animals;
                            _animals = new Animal[_animals.Length + 1];

                            for (int i = 0; i < tempAnimal.Length; i++)
                            {
                                _animals[i] = tempAnimal[i];
                            }

                            _animals[_animals.Length - 1] = animal;
                            return "Добавлено в вольер " + animal.Name;
                        }
                        else
                        {
                            return "Хищних животных в вольер с травоядными не добавляем";
                        }
                    }
                    else
                    {
                    _animals = new Animal[_animals.Length + 1];
                    _animals[_animals.Length - 1] = animal;
                    return "Добавлено в вольер " + animal.Name;
                    }
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
            return "Вольер";
        }
    }
}
