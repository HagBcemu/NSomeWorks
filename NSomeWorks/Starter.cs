using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace NSomeWorks
{
    class Starter
    {
        Result _result;
        public void Run()
        {
            Actions actions = new Actions();
            for (int i = 0; i < 100; i++)
            {
                try
                {
                    switch (new Random().Next(1, 4))
                    {
                        case 1:
                            _result = actions.StartMethod();
                            Logger.GetLogger().WriteLog(_result);
                            break;
                        case 2:
                            var businessException = actions.SkipedMethod();
                            Result result = new Result(businessException.Message, TypeLog.Warning, true);
                            Logger.GetLogger().WriteLog(result);
                            break;
                        case 3:
                            _result = actions.ErrorMethod();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Result result = new Result(ex.Message, TypeLog.Error, false);
                    Logger.GetLogger().WriteLog(result);
                }

                Thread.Sleep(50);
            }
        }
    }
}
