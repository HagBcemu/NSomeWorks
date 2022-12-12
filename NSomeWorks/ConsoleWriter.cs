using System;
using System.Diagnostics;

namespace NSomeWorks
{
    class ConsoleWriter
    {
        private AsyncMetoth _asyncMetoth;

        public ConsoleWriter()
        {
            _asyncMetoth = new AsyncMetoth();
        }

        public void ShowConsole()
        {
            Console.WriteLine("Команды ");
            Console.WriteLine("1 - считать з файлу Hello");
            Console.WriteLine("2 - считать з файлу World");
            Console.WriteLine("3 - виконання параллельно и конкатенация");
            Console.WriteLine("4 - виконання синхронно медов и конкатенация");
            ControPanel();
        }

        void ControPanel()
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
                        Console.WriteLine(_asyncMetoth.ReadHello().Result);
                    }

                    if (numberChose == 2)
                    {
                        Console.WriteLine(_asyncMetoth.ReadWorld().Result);
                    }

                    if (numberChose == 3)
                    {
                        Console.WriteLine(_asyncMetoth.ReadAllConcad());
                    }

                    if (numberChose == 4)
                    {
                       Console.WriteLine(_asyncMetoth.ReadAllConcadSynch());
                    }

                    if (numberChose == 5)
                    {
                        Process.GetCurrentProcess().Kill();
                    }
                }
                else
                {
                    Console.WriteLine("Не корректное значение");
                }
            }
        }
    }
}
