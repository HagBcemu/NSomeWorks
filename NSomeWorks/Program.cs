using System;
using static NSomeWorks.Class1;

namespace NSomeWorks
{
    class Program
    {
        static PowHadler _powHadler;

        static ShowHadler _showHadler;
        static void Main(string[] args)
        {
            _powHadler = Class1.Pow;
            _showHadler = Show;

            Class2 class2 = new Class2();

            while (true)
            {
                Console.WriteLine("Введіть 2 множника та чисто перевірки на остачу через / (5/5/5)");
                string[] stringInput = Console.ReadLine().Split("/");
                if (stringInput.Length == 3)
                {
                    bool parse = int.TryParse(stringInput[0], out int number1);
                    bool pars2 = int.TryParse(stringInput[1], out int number2);
                    bool pars3 = int.TryParse(stringInput[2], out int number3);

                    if (parse && pars2 && pars3)
                    {
                        ResultHadler resultHadler = class2.Calc(_powHadler, number1, number2);

                        _showHadler(resultHadler.Invoke(number3));
                    }
                    else
                    {
                        Console.WriteLine("Что-то не так");
                    }
                }
                else
                {
                    Console.WriteLine("Что-то не так");
                }
            }
        }

        private static void Show(bool boolstatus)
        {
            Console.WriteLine("Перевірка на те, що чи ділитися число у нас без залишку: " + boolstatus + "\n");
        }
    }
}