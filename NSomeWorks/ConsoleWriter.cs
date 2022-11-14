using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NSomeWorks
{
    class ConsoleWriter
    {
        private Electrical[] _electricals;

        private ConnectedElectrical _connected;
        public ConsoleWriter()
        {
            _electricals = ElectricalCreater.GetElectricals();
            _connected = new ConnectedElectrical();
        }

        public void ShowConsole()
        {
            ShowElecrical();
            ShowControlPanelElecrical();
        }

        void ShowElecrical()
        {
            Console.Clear();
            Console.WriteLine("У вас подлючено приборов: " + _connected.GetElectricals().Length);

            for (int i = 0; i < _electricals.Length; i++)
            {
                Console.WriteLine(i + ".) " + _electricals[i].Name + " мощность: " + _electricals[i].Power);
            }

            Console.WriteLine("\nВведите номер прилада и нажмите ENTER что бы подлючить в розетку");
            Console.WriteLine("или * для того что бы перейти к подлюченным приладам");
            Console.WriteLine("или exit что бы закрыть");
        }

        void ShowControlPanelElecrical()
        {
            while (true)
            {
                int numberChose = 0;
                string consoleWrite = Console.ReadLine();
                bool succesParseNumber = int.TryParse(consoleWrite, out numberChose);
                if (succesParseNumber)
                {
                    if (numberChose < _electricals.Length)
                    {
                        _connected.AddElectrical(_electricals[numberChose]);
                        ShowElecrical();
                        Console.WriteLine("Успешно добавленно " + _electricals[numberChose].Name);
                    }
                    else
                    {
                        Console.WriteLine("\nНету такого прибора");
                    }
                }
                else
                {
                    if (consoleWrite == "*")
                    {
                        ShowConectedElectrical();

                        ShowConrolPanelConeccted();
                    }
                    else if (consoleWrite == "exit")
                    {
                        Process.GetCurrentProcess().Kill();
                    }
                }
            }
        }

        void ShowConectedElectrical()
        {
            Console.Clear();
            if (_connected.GetElectricals().Length == 0)
            {
                Console.WriteLine("У вас не подлюченые приборы");
            }
            else
            {
                Console.WriteLine("Общая потребляемая мощность: " + _connected.GetAllPower());
                Electrical[] connected = _connected.GetElectricals();

                for (int i = 0; i < connected.Length; i++)
                {
                    Console.WriteLine(i + 1 + ".) " + connected[i].Name + " мощность: " + connected[i].Power);
                }
            }

            Console.WriteLine("\nВведите + что бы создать новую квартиру или * что бы выйти до елетроприборов ");
            Console.WriteLine("Введите / что бы отсортировать по мощности");
            Console.WriteLine("Введите ++ что бы найти прибор по диапазону");
            Console.WriteLine("или exit что бы закрыть");
        }

        void ShowConrolPanelConeccted()
        {
            while (true)
            {
                string userInput = Console.ReadLine();
                if (userInput == "+")
                {
                    Console.WriteLine("Вы создали новую квартиру");
                    _connected = new ConnectedElectrical();
                }
                else if (userInput == "*")
                {
                    ShowConsole();
                }
                else if (userInput == "++")
                {
                    while (true)
                    {
                        Console.WriteLine("Введите чезез / диапаон мощности");
                        userInput = Console.ReadLine();
                        string[] inputSlit = userInput.Split("/");
                        if (inputSlit.Length == 2)
                        {
                            bool parse = int.TryParse(inputSlit[0], out int number1);
                            bool pars2 = int.TryParse(inputSlit[1], out int number2);
                            if (parse && pars2)
                            {
                                if (number1 > number2)
                                {
                                    int temp = number1;
                                    number1 = number2;
                                    number2 = temp;
                                }

                                Console.WriteLine("Приборы в диапазоне от " + number1 + " до " + number2);
                                Electrical[] electricals = _connected.GetElectricals();

                                for (int i = 0; i < electricals.Length; i++)
                                {
                                    if (number1 < electricals[i].Power && electricals[i].Power < number2)
                                    {
                                        Console.WriteLine((i + 1) + ".) " + electricals[i].Name + " мощность: " + electricals[i].Power);
                                    }
                                }

                                break;
                            }
                        }

                        Console.WriteLine("Что то пошло не так");
                    }
                }
                else if (userInput == "/")
                {
                    Console.WriteLine("Отсортировано по мощности");
                    Electrical[] sortElectrical = _connected.GetElectricals().SortByAge();

                    for (int i = 0; i < sortElectrical.Length; i++)
                    {
                        Console.WriteLine((i + 1) + ".) " + sortElectrical[i].Name + " мощность: " + sortElectrical[i].Power);
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