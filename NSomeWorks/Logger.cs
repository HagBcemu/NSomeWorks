using System;
using System.IO;

namespace NSomeWorks
{
    class Logger
    {
        private static Logger _logger;
        private FileService _fileService;

        private Logger()
        {
            _fileService = new FileService();
        }

        public static Logger GetLogger()
        {
            if (_logger == null)
            {
                _logger = new Logger();
            }

            return _logger;
        }

        public void WriteLog(Result result)
        {
            string textToLog = DateTime.Now + ": " + result.TypeLog + ": " + result.TextLog;
            Console.WriteLine(textToLog);
            _fileService.WriteToFile(textToLog);
        }
    }
}
