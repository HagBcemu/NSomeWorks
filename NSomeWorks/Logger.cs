using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NSomeWorks
{
    class Logger
    {
        private int _nConfiguration;

        private List<Result> _results;

        object _locker = "f";

        public Logger()
        {
            _nConfiguration = GetNConfigurator();
            _results = new List<Result>();
            Starter.EventStarter += WriteLog;
            Starter.EventStarter += WriteConsoleResult;
        }

        public void WriteLog(Result result)
        {
            lock (_locker)
            {
                _results.Add(result);
                if (_results.Count % _nConfiguration == 0)
                {
                    Task task = Task.Run(() => MakeBackupAsync(_results));
                }
            }
        }

        private async Task MakeBackupAsync(List<Result> results)
        {
            CreateDirectory();
            DateTime now = DateTime.Now;
            string nameFile = @"../Backup/" + now.ToString("hh.mm.ss.ff dd.MM.yyyy") + ".txt";

            string logText = null;

            for (int i = 0; i < results.Count; i++)
            {
                logText += $"{i + 1}.) " + results[i].DateTime + ": " + results[i].TypeLog + ": " + results[i].TextLog + "\n";
            }

            await File.WriteAllLinesAsync(nameFile, logText.Split("\n"));
        }

        void CreateDirectory()
        {
            string path = @"../Backup";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private int GetNConfigurator()
        {
            int nDefault = 15;
            using (FileStream fs = new FileStream("Nconfigurator.json", FileMode.OpenOrCreate))
            {
                int.TryParse(JsonSerializer.DeserializeAsync<string>(fs).Result, out nDefault);
            }

            return nDefault;
        }

        private void WriteConsoleResult(Result result)
        {
            string textToLog = DateTime.Now.ToString("hh.mm.ss.ff") + ": " + result.TypeLog + ": " + result.TextLog;
            Console.WriteLine(textToLog);
        }
    }
}
