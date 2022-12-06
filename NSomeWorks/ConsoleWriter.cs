using System;
using System.Diagnostics;
using NSomeWorks.Section;

namespace NSomeWorks
{
    class ConsoleWriter
    {
        Animal[] _animal;

        ISection _section;

        public ConsoleWriter()
        {
            _animal = AnimalCreater.GetAnimals();
        }

        public void ShowConsole()
        {
            ShowAnimal();
            ShowControlPanelAnimal();
        }

        void ShowAnimal()
        {
            Console.Clear();
            if (_section is null)
            {
                Console.WriteLine("У вас нету секции");
            }
            else
            {
                Console.WriteLine($"Создана секция {_section.GetName()}. Тварин в секции {_section.GetAnimals().Length}");
            }

            Console.WriteLine("Тварины");
            for (int i = 0; i < _animal.Length; i++)
            {
                Console.WriteLine(i + ".) " + _animal[i].Name);
            }

            Console.WriteLine("\nВведите номер товара и нажмите ENTER что бы добавить тварину в секцию");
            Console.WriteLine("или * для того что бы перейти в секцию");
            Console.WriteLine("или / перейти к сортировке");
            Console.WriteLine("или exit что бы закрыть");
        }

        void ShowControlPanelAnimal()
        {
            while (true)
            {
                int numberChose = 0;
                string consoleWrite = Console.ReadLine();
                bool succesParseNumber = int.TryParse(consoleWrite, out numberChose);
                if (succesParseNumber)
                {
                    if (numberChose < _animal.Length)
                    {
                        ShowAnimal();
                        if (_section is null)
                        {
                            if (_animal[numberChose] is Mammals)
                            {
                                _section = new Aviary();
                                Console.WriteLine("Создана секция Вольер");
                            }
                            else
                            {
                                _section = new Aquarium();
                                Console.WriteLine("Создана секция Аквариум");
                            }
                        }

                        Console.WriteLine(_section.AddAnimal(_animal[numberChose]));
                    }
                    else
                    {
                        Console.WriteLine("\nНету такой тваринки");
                    }
                }
                else
                {
                    if (consoleWrite == "*")
                    {
                        ShowSection();
                        ShowControlPanelSection();
                    }
                    else if (consoleWrite == "/")
                    {
                        ShowTypeSort();
                    }
                    else if (consoleWrite == "exit")
                    {
                        Process.GetCurrentProcess().Kill();
                    }
                }
            }
        }

        void ShowTypeSort()
        {
            Console.WriteLine("Выберите вариант фильтрования\n");
            Console.WriteLine("1 - показать тварины живущее в аквариуме\n" +
                              "2 - показать тварины живущее в вольере и хижники\n" +
                              "3 - показать  тварины живущее в вольере и травоядные\n");
            int numberChose = 0;
            string consoleWrite = Console.ReadLine();
            bool succesParseNumber = int.TryParse(consoleWrite, out numberChose);
            if (succesParseNumber)
            {
                if (numberChose < 4)
                {
                    for (int i = 0; i < _animal.Length; i++)
                    {
                        if (numberChose == 1 && _animal[i] is AquaticAnimals)
                        {
                            Console.WriteLine(i + ".) " + _animal[i].Name);
                        }

                        if (numberChose == 2 && _animal[i] is PredatoryBeast)
                        {
                            Console.WriteLine(i + ".) " + _animal[i].Name);
                        }

                        if (numberChose == 3 && _animal[i] is Herbivores)
                        {
                            Console.WriteLine(i + ".) " + _animal[i].Name);
                        }
                    }
                }
            }
            else
            {
                Console.Clear();
                ShowTypeSort();
            }

            ShowControlPanelAnimal();
        }

        void ShowSection()
        {
            Console.Clear();
            if (_section == null)
            {
                Console.WriteLine("У вас нету секции");
            }
            else
            {
                Animal[] animals = _section.GetAnimals();

                for (int i = 0; i < animals.Length; i++)
                {
                    Console.WriteLine(i + 1 + ".) " + animals[i].Name + " возраст: " + animals[i].Age);
                }
            }

            Console.WriteLine("\nВведите + что бы создать новую секцию или * что бы выйти до животных ");
            Console.WriteLine("Введите / что бы отсортировать по возрасу");
            Console.WriteLine("Введите ++ что бы подсчитать каждый вид в секции");
            Console.WriteLine("или exit что бы закрыть");
        }

        void ShowControlPanelSection()
        {
            while (true)
            {
                string userInput = Console.ReadLine();
                if (userInput == "+")
                {
                     Console.WriteLine("Вы создали новую секцию");
                     _section = null;
                }
                else if (userInput == "*")
                {
                    ShowAnimal();
                    ShowControlPanelAnimal();
                }
                else if (userInput == "++")
                {
                    (string, int)[] countEachKind = _section.CountEachKind();
                    Console.WriteLine("Каждого вида");
                    for (int i = 0; i < countEachKind.Length; i++)
                    {
                        Console.WriteLine((i + 1) + ".) " + countEachKind[i].Item1 + " : " + countEachKind[i].Item2);
                    }
                }
                else if (userInput == "/")
                {
                    Console.WriteLine("Отсортировано по возрасту");
                    Animal[] sortAnimal = _section.GetAnimals().SortByAge();

                    for (int i = 0; i < sortAnimal.Length; i++)
                    {
                        Console.WriteLine((i + 1) + ".) " + sortAnimal[i].Name + " возраст: " + sortAnimal[i].Age);
                    }
                }
                else if (userInput == "exit")
                {
                    Process.GetCurrentProcess().Kill();
                }
                else
                {
                    Console.WriteLine("Не корректное значение");
                }
            }
        }
    }
}
