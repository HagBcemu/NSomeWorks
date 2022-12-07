using System;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks
{
    class ConsoleWriter
    {
        private DelegateExercise _delegateExercise;

        private ContactLINQ _contactLINQ;
        public ConsoleWriter()
        {
           _delegateExercise = new DelegateExercise();
           _contactLINQ = new ContactLINQ(ContactCreator.GetContacts());
        }

        public void ShowConsoleDelegate()
        {
            ShowPanelDelegate();
            ShowControlPanelDelegate();
        }

        public void ShowConsoleLinq()
        {
            ShowPanelLinq();
            ShowControlPanelLINQ();
        }

        private void ShowPanelDelegate()
        {
            Console.WriteLine("Выберите команду: ");
            Console.WriteLine("1 - для проверки метода который суммирует");
            Console.WriteLine("2 - для того что бы подписаться дважды на собитие");
            Console.WriteLine("3 - для подсчета суммы результатов обчислений методов");
            Console.WriteLine("4 - перейти к заданию LINQ");
        }

        private void ShowPanelLinq()
        {
            List<Contact> contacts = _contactLINQ.GetAllContact();

            Console.WriteLine("Список контактов: ");

            for (int i = 0; i < contacts.Count; i++)
            {
                Console.WriteLine(i + 1 + ".) " + contacts[i].FirstName + " - " + contacts[i].Number);
            }

            Console.WriteLine("\nВыберите команду: ");
            Console.WriteLine("1 - для проверки метода WhereContact по имени");
            Console.WriteLine("2 - для SelectContact для выбору по имени и модерниации");
            Console.WriteLine("3 - для FirstContact по началу номера");
            Console.WriteLine("4 - для Count по похожих комбинациях чисел");
            Console.WriteLine("5 - для ContainsContact для проверки есть ли контакт с таким именем");
            Console.WriteLine("6 - для SkipTakeReverse для пропуска, взятия, реверса контактов");
            Console.WriteLine("7 - перейти к заданию Delegate");
        }

        private void ShowControlPanelDelegate()
        {
            while (true)
            {
                int numberChose = 0;
                string consoleWrite = Console.ReadLine();
                bool succesParseNumber = int.TryParse(consoleWrite, out numberChose);
                if (succesParseNumber)
                {
                    if (numberChose == 1)
                    {
                        Console.WriteLine("Ведите 2 числа через /");
                        string[] stringArray = Console.ReadLine().Split("/");
                        if (stringArray.Length == 2)
                        {
                            int number1 = 0;
                            int number2 = 0;
                            bool parse1 = int.TryParse(stringArray[0], out number1);
                            bool parse2 = int.TryParse(stringArray[1], out number2);
                            if (parse1 && parse2)
                            {
                                Console.WriteLine(_delegateExercise.Sum(number1, number2));
                            }
                        }
                        else
                        {
                            Console.WriteLine("Не корректное значение");
                        }
                    }

                    if (numberChose == 2)
                    {
                        _delegateExercise.AddEventSum();
                        Console.WriteLine("Удачно");
                    }

                    if (numberChose == 3)
                    {
                        Console.WriteLine("Ведите 2 числа через /");
                        string[] stringArray = Console.ReadLine().Split("/");
                        if (stringArray.Length == 2)
                        {
                            int number1 = 0;
                            int number2 = 0;
                            bool parse1 = int.TryParse(stringArray[0], out number1);
                            bool parse2 = int.TryParse(stringArray[1], out number2);
                            if (parse1 && parse2)
                            {
                                _delegateExercise.SumAllEvents(number1, number2);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Не корректное значение");
                        }
                    }

                    if (numberChose == 4)
                    {
                        Console.Clear();
                        ShowConsoleLinq();
                    }
                }
                else
                {
                    Console.WriteLine("Не корректное значение");
                }
            }
        }

        private void ShowControlPanelLINQ()
        {
            while (true)
            {
                int numberChose = 0;
                string consoleWrite = Console.ReadLine();
                bool succesParseNumber = int.TryParse(consoleWrite, out numberChose);
                if (succesParseNumber)
                {
                    if (numberChose == 1)
                    {
                        Console.WriteLine("Введите имя");
                        var someList = _contactLINQ.WhereContact(Console.ReadLine());
                        Console.WriteLine("Результат:");
                        for (int i = 0; i < someList.Count; i++)
                        {
                            Console.WriteLine(someList[i].FirstName + " - " + someList[i].Number);
                        }
                    }

                    if (numberChose == 2)
                    {
                        Console.WriteLine("Введите имя");
                        var someList = _contactLINQ.SelectContact(Console.ReadLine());
                        Console.WriteLine("Результат:");
                        for (int i = 0; i < someList.Count; i++)
                        {
                            Console.WriteLine(someList[i].FirstName + " - " + someList[i].Number);
                        }
                    }

                    if (numberChose == 3)
                    {
                        Console.WriteLine("Введите номер");
                        var someList = _contactLINQ.FirstContact(Console.ReadLine());
                        Console.WriteLine("Результат:");
                        Console.WriteLine(someList?.FirstName + " - " + someList?.Number);
                    }

                    if (numberChose == 4)
                    {
                        Console.WriteLine("Введите комбинацию числел");
                        var someList = _contactLINQ.CountSubNumber(Console.ReadLine());
                        Console.WriteLine("Результат: " + someList);
                    }

                    if (numberChose == 5)
                    {
                        Console.WriteLine("Введите имя");
                        var someRespons = _contactLINQ.ContainsContact(Console.ReadLine());
                        Console.WriteLine("Результат: " + someRespons);
                    }

                    if (numberChose == 6)
                    {
                        Console.WriteLine("Введите числа через / сколько пропустить и взять и реверс");
                        var someList = _contactLINQ.SkipTakeReverse(Console.ReadLine());
                        Console.WriteLine("Результат:");
                        for (int i = 0; i < someList.Count; i++)
                        {
                            Console.WriteLine(someList[i].FirstName + " - " + someList[i].Number);
                        }
                    }

                    if (numberChose == 7)
                    {
                        ShowConsoleDelegate();
                    }

                    Console.WriteLine("Выберите команду: ");
                }
                else
                {
                    Console.WriteLine("Не корректное значение");
                }
            }
        }
    }
}
