using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace NSomeWorks
{
    class Starter
    {
        Logger _logger;

        Result _result;
        public void Run()
        {
            for (int i = 0; i < 100; i++)
            {
                Actions actions = new Actions();
                switch (new Random().Next(1, 4))
                {
                    case 1:
                        _result = actions.StartMethod();
                        break;
                    case 2:
                        _result = actions.SkipedMethod();
                        break;
                    case 3:
                        _result = actions.ErrorMethod();
                        break;
                }

                _logger = Logger.GetLogger();
                if (_result.Status == false)
                {
                    _logger.ErorLog(_result);
                }
                else
                {
                    _logger.WriteLogInConsole(_result);
                }

                Thread.Sleep(100);
            }

            _logger.WriteLogInFile();
        }
    }
}
