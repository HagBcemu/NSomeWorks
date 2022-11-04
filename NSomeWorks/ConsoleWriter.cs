using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NSomeWorks
{
    class ConsoleWriter
    {
        Transport[] _transports;

        Garage _garage;

        public void ShowConsole()
        {
            _transports = TransportCreater.GetTransports();

            _garage = new Garage();

            ShowTransort();

            ShowControlPranelTransport();
        }

        public void ShowTransort()
        {
            Console.Clear();
            Console.WriteLine("Весь список транспорта " + "\n");
            for (int i = 0; i < _transports.Length; i++)
            {
                Console.WriteLine(i + ".) " + _transports[i].Name);
            }

            Console.WriteLine("\nВведите номер товара и нажмите ENTER что бы добавить транспорт в гараж");
            Console.WriteLine("или * для того что бы перейти в гараж");
            Console.WriteLine("или / перейти к сортировке");
            Console.WriteLine("или exit что бы закрыть");
        }

        void ShowTypeSort()
        {
            Console.WriteLine("Выберите вариант фильтрования\n");
            Console.WriteLine("1 - показать електрокары\n" +
                              "2 - показать спорткары\n" +
                              "3 - показать машины с двс\n");
            int numberChose = 0;
            string consoleWrite = Console.ReadLine();
            bool succesParseNumber = int.TryParse(consoleWrite, out numberChose);
            if (succesParseNumber)
            {
                if (numberChose < 4)
                {
                    for (int i = 0; i < _transports.Length; i++)
                    {
                        if (numberChose == 1 && _transports[i] is ElectroCar)
                        {
                            Console.WriteLine(i + ".) " + _transports[i].Name);
                        }

                        if (numberChose == 2 && _transports[i] is SportICECar)
                        {
                            Console.WriteLine(i + ".) " + _transports[i].Name);
                        }

                        if (numberChose == 3 && _transports[i] is ICECar)
                        {
                            Console.WriteLine(i + ".) " + _transports[i].Name);
                        }
                    }
                }
            }
            else
            {
                Console.Clear();
                ShowTypeSort();
            }
        }

        void ShowGarage()
        {
            Console.Clear();
            Console.WriteLine("Добро пожаловать в гараж\n");
            Console.WriteLine("Общий пробег транспорта " + _garage.GetSummMileage());
            Transport[] transportChose = _garage.GetTransprotInGarage();

            for (int i = 1; i < transportChose.Length; i++)
            {
                Console.WriteLine(i + ".) " + transportChose[i].Name + " пробег: " + transportChose[i].Mileage);
            }
        }

        void ShowControlPranelTransport()
        {
            while (true)
            {
                int numberChose = 0;
                string consoleWrite = Console.ReadLine();
                bool succesParseNumber = int.TryParse(consoleWrite, out numberChose);
                if (succesParseNumber)
                {
                    if (numberChose < _transports.Length)
                    {
                        _garage.AddProductToBasket(_transports[numberChose]);
                        Console.Clear();
                        ShowTransort();
                        Console.WriteLine("\nТранспорт успешно добавлен " + _transports[numberChose].Name);
                    }
                    else
                    {
                        Console.WriteLine("\nНету такого транспорта");
                    }
                }
                else
                {
                    if (consoleWrite == "*")
                    {
                        ShowGarage();
                        ControlPanelGarage();
                    }
                    else if (consoleWrite == "exit")
                    {
                        Process.GetCurrentProcess().Kill();
                    }
                    else if (consoleWrite == "/")
                    {
                        ShowTypeSort();
                    }
                    else
                    {
                        Console.WriteLine("\nНе корректно введена команда");
                    }
                }
            }
        }

        void ControlPanelGarage()
        {
            while (true)
            {
                Console.WriteLine("\nВведите + что бы создать гараж или * что бы выйти до транспорта ");
                Console.WriteLine("или / что бы отсортировать по пробегу");
                Console.WriteLine("или exit что бы закрыть");
                string userInput = Console.ReadLine();
                if (userInput == "+")
                {
                    if (_garage.GetSummMileage() == 0)
                    {
                        Console.WriteLine("У вас пустой гараж\n");
                    }
                    else
                    {
                        Console.WriteLine("Вы создали новый гараж");
                        _garage = new Garage();
                    }
                }
                else if (userInput == "*")
                {
                    ShowTransort();
                    ShowControlPranelTransport();
                }
                else if (userInput == "/")
                {
                    Console.Clear();
                    Console.WriteLine("Отсортировано по пробегу");
                    Transport[] sortGarage = _garage.GetTransprotInGarage().SortByMealeAge();

                    for (int i = 0; i < sortGarage.Length; i++)
                    {
                        Console.WriteLine((i + 1) + ".) " + sortGarage[i].Name + " пробег: " + sortGarage[i].Mileage);
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
