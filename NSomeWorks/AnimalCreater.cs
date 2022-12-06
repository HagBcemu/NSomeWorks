using System;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks
{
    class AnimalCreater
    {
        public static Animal[] GetAnimals()
        {
            Animal[] animals =
            {
                new Fish("Сельдь", new Random().Next(2, 4)),
                new Fish("Пузанок", new Random().Next(3, 6)),
                new Fish("Салака", new Random().Next(1, 3)),
                new Fish("Тюлька", new Random().Next(2, 5)),

                new PredatoryBeast("Тигр", new Random().Next(7, 18)),
                new PredatoryBeast("Андская кошка", new Random().Next(5, 17)),
                new PredatoryBeast("Бурая гиена", new Random().Next(4, 12)),
                new PredatoryBeast("Гепард", new Random().Next(3, 8)),
                new PredatoryBeast("Красный волк", new Random().Next(1, 15)),

                new Herbivores("Верблюд", new Random().Next(3, 15)),
                new Herbivores("Слон", new Random().Next(4, 14)),
                new Herbivores("Носорог", new Random().Next(8, 15)),
                new Herbivores("Лошадь", new Random().Next(5, 12)),
                new Herbivores("Зебра", new Random().Next(4, 17)),
            };

            return animals;
        }
    }
}
