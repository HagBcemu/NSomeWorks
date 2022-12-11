using System;
using System.Diagnostics;

namespace NSomeWorks
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageBox messageBox = new MessageBox();
            messageBox.Notify += StateShow;
            messageBox.Open();
            MessageBoxOpen(messageBox);
        }

        private static void StateShow(State state)
        {
            Console.WriteLine("State status = " + state);
        }

        private static void MessageBoxOpen(MessageBox messageBox)
        {
            bool whileBool = true;
            while (whileBool)
            {
                Console.WriteLine("\nЧто бы вызвать еще раз MessageBox.Open() напишите - 1 или для выхода - 2 + Enter \n");
                string userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    messageBox.Open();
                }

                if (userInput == "2")
                {
                    Process.GetCurrentProcess().Kill();
                }
            }
        }
    }
}
