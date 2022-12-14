using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NSomeWorks
{
    class Starter
    {
        private Result _result;

        public delegate void StarterHadler(Result result);

        public static event StarterHadler EventStarter;
        public async Task Run()
        {
            await Task.Run(() => MakeResult());
        }

        private void MakeResult()
        {
            Actions actions = new Actions();
            for (int i = 0; i < 50; i++)
            {
                switch (new Random().Next(1, 4))
                {
                    case 1:
                        _result = actions.StartMethod();
                        EventStarter(_result);
                        break;
                    case 2:
                        _result = actions.SkipedMethod();
                        EventStarter(_result);
                        break;
                    case 3:
                        _result = actions.ErrorMethod();
                        EventStarter(_result);
                        break;
                }

                Thread.Sleep(new Random().Next(30, 70));
            }
        }
    }
}