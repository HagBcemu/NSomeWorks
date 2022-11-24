using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NSomeWorks
{
    class ConsoleWriter
    {
        private Collection<string> _collection;
        public ConsoleWriter()
        {
            _collection = new Collection<string>();
            _collection.AddRange(new string[] { "String1", "Audi A8", "Tiger", "Item1", "Computer", "Xiaomi" });
        }

        public void ShowConsole()
        {
            ShowColection();
            ShowControlPanel();
        }

        void ShowColection()
        {
            string[] arrayToShow = _collection.GetColection();

            Console.Clear();
            Console.WriteLine("Colection");
            for (int i = 0; i < arrayToShow.Length; i++)
            {
                Console.WriteLine(i + ".) " + arrayToShow[i]);
            }

            Console.WriteLine("\nВведите номер команды:");
            Console.WriteLine("1 для команды Add");
            Console.WriteLine("2 для команды AddRange (Добавление массива)");
            Console.WriteLine("3 для команды Remove (Удаление по итему из списка)");
            Console.WriteLine("4 для команды RemoveAt (Удаление по индексу)");
            Console.WriteLine("5 для команды Sort");
            Console.WriteLine("или exit что бы закрыть");
        }

        void ShowControlPanel()
        {
            while (true)
            {
                int numberChose = -2;
                string consoleWrite = Console.ReadLine();
                bool succesParseNumber = int.TryParse(consoleWrite, out numberChose);
                if (succesParseNumber)
                {
                    if (numberChose == 1)
                    {
                        Console.WriteLine("Введите новое значение и нажмите Enter");
                        _collection.Add(Console.ReadLine());
                        ShowConsole();
                        Console.WriteLine("Успешно добавленно");
                    }

                    if (numberChose == 2)
                    {
                        Console.WriteLine("Введите через /");
                        string userInput = Console.ReadLine();
                        string[] inputSlit = userInput.Split("/");
                        _collection.AddRange(inputSlit);
                        ShowConsole();
                    }

                    if (numberChose == 3)
                    {
                        Console.WriteLine("Введите елемент");
                        string userInput = Console.ReadLine();
                        bool resultRemove = _collection.Remove(userInput);
                        ShowConsole();
                        Console.WriteLine("Успешность результата " + resultRemove);
                    }

                    if (numberChose == 4)
                    {
                        Console.WriteLine("Введите нормер");
                        int numberRemove = 0;
                        string consoleWrite2 = Console.ReadLine();
                        bool succesParseNumber2 = int.TryParse(consoleWrite, out numberRemove);
                        if (succesParseNumber2)
                        {
                            _collection.RemoveAt(numberRemove);
                            ShowConsole();
                        }
                        else
                        {
                            ShowConsole();
                            Console.WriteLine("Не корректное значение");
                        }
                    }

                    if (numberChose == 5)
                    {
                        Array.Sort(_collection.GetColection());
                        ShowConsole();
                    }
                }
                else if (consoleWrite == "exit")
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
