using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace NSomeWorks
{
    class FileService
    {
        private string _nameFile = null;

        public void WriteToFile(string logText)
        {
            if (_nameFile == null)
            {
                CreateFile();
                DateTime now = DateTime.Now;
                _nameFile = @"../" + GetDirectory() + "/" + now.ToString("hh.mm.ss dd.MM.yyyy") + ".txt";
            }

            using (StreamWriter writer = new StreamWriter(_nameFile, true))
            {
                writer.WriteLineAsync(logText);
            }
        }

        void CreateFile()
        {
            string path = @"../" + GetDirectory();

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            else
            {
                FileInfo[] fileInfos = new DirectoryInfo(path).GetFiles();
                if (fileInfos.Length > 3)
                {
                    while (fileInfos.Length > 3)
                    {
                        int numberToDelete = 0;
                        for (int i = 0; i < fileInfos.Length; i++)
                        {
                            int dateInt1 = int.Parse(fileInfos[i].CreationTime.ToString().Replace(".", string.Empty).Replace(" ", string.Empty).Replace(":", string.Empty).Remove(0, 7));

                            int dateInt2 = int.Parse(fileInfos[numberToDelete].CreationTime.ToString().Replace(".", string.Empty).Replace(" ", string.Empty).Replace(":", string.Empty).Remove(0, 7));

                            if (dateInt1 < dateInt2)
                            {
                                numberToDelete = i;
                            }
                        }

                        string pathDelete = fileInfos[numberToDelete].FullName.Replace(@"\", "/");

                        File.Delete(pathDelete);
                        fileInfos = new DirectoryInfo(path).GetFiles();
                    }
                }
            }
        }

        string GetDirectory()
        {
            string nameDirectory = "NoJsonFind";
            using (FileStream fs = new FileStream("PathDirectory.json", FileMode.OpenOrCreate))
            {
                nameDirectory = JsonSerializer.DeserializeAsync<string>(fs).Result;
            }

            return nameDirectory;
        }
    }
}
