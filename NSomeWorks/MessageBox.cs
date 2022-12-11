using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NSomeWorks
{
    enum State
    {
        Ok,
        Cancel
    }

    class MessageBox
    {
        public delegate void StateHandler(State state);
        public event StateHandler Notify;

        public async void Open()
        {
            Console.WriteLine("Окно отрыто");
            await Task.Run(() =>
            {
                Thread.Sleep(3000);
            });
            Console.WriteLine("Окно закрыто користувачем");
            Random random = new Random();
            switch (random.Next(0, 2))
            {
                case 0:
                    Notify(State.Ok);
                    break;
                case 1:
                    Notify(State.Cancel);
                    break;
            }
        }
    }
}
