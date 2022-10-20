using System;

namespace NSomeWorks
{
    class Program
    {
        static void Main(string[] args)
        {
            Exercise();

            int lengsArray;

            void Exercise()
            {
                string[] charToUpper = new string[] { "a", "e", "i", "d", "h", "j" };

                char[] charToChange = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

                Console.WriteLine("Введіть N: ");

                bool parseSucses = int.TryParse(Console.ReadLine(), out lengsArray);

                if (!parseSucses)
                {
                    Console.WriteLine("Некоректне введення");
                    Exercise();
                }

                int[] arrayNumber = new int[lengsArray];

                for (int i = 0; i < arrayNumber.Length; i++)
                {
                    arrayNumber[i] = new Random().Next(0, 25);
                }

                Console.WriteLine("\nЗгенерований масив");
                PrintArray(arrayNumber);

                string[] pairNumber = new string[arrayNumber.Length];

                string[] noPairNumber = new string[arrayNumber.Length];

                int theUperLineMost = 0;

                for (int i = 0; i < arrayNumber.Length; i++)
                {
                    if ((arrayNumber[i] + 1) % 2 == 1)
                    {
                        noPairNumber[i] = charToChange[arrayNumber[i]].ToString();
                        if (Array.IndexOf(charToUpper, noPairNumber[i]) != -1)
                        {
                            noPairNumber[i] = noPairNumber[i].ToUpper();
                            theUperLineMost++;
                        }
                    }
                    else
                    {
                        pairNumber[i] = charToChange[arrayNumber[i]].ToString();
                        if (Array.IndexOf(charToUpper, pairNumber[i]) != -1)
                        {
                            pairNumber[i] = pairNumber[i].ToUpper();
                            theUperLineMost--;
                        }
                    }
                }

                Console.WriteLine("\nМасив де буде більше букв у верхньому регістрі");
                if (theUperLineMost > 0)
                {
                    Console.WriteLine("Масив не парних значень");
                    PrintArrayString(noPairNumber);
                }
                else
                {
                    Console.WriteLine("Масив парних значень ");
                    PrintArrayString(pairNumber);
                }

                Console.WriteLine("\nДва мисива");
                Console.WriteLine("\nМасив парних значень");
                PrintArrayString(pairNumber);
                Console.WriteLine("\n\nМасив не парних значень ");
                PrintArrayString(noPairNumber);
            }

            void PrintArray(int[] array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write(array[i] + " ");
                }
            }

            void PrintArrayString(string[] array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write(array[i] + " ");
                }
            }
        }
    }
}
