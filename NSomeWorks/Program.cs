using System;
using System.Threading.Tasks;

namespace NSomeWorks
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger();
            Starter starter = new Starter();
            Task task1 = Task.Run(async () => await starter.Run());
            Task task2 = Task.Run(async () => await starter.Run());
            Task.WaitAll(task1, task2);
            Console.ReadKey();
        }
    }
}
