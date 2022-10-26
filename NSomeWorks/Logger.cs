using System;
using System.IO;

namespace NSomeWorks
{
    class Logger
    {
        private static Logger _logger;

        private string _logText;

        private Logger()
        {
        }

        public static Logger GetLogger()
        {
            if (_logger == null)
            {
                _logger = new Logger();
            }

            return _logger;
        }

        public void WriteLogInConsole(Result result)
        {
            string addStringToLog = DateTime.Now + ": " + result.TypeLog + ": " + result.TextLog;
            _logText += "\n" + addStringToLog;
        }

        public void ErorLog(Result result)
        {
            string addStringToLog = "Action failed by а reason: " + result.TextLog;
            _logText += "\n" + addStringToLog;
            Console.WriteLine(addStringToLog);
        }

        public void WriteLogInFile()
        {
            File.WriteAllLines("log.txt", _logText.Split('\n'));
        }
    }
}
