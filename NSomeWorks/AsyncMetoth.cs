using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NSomeWorks
{
    class AsyncMetoth
    {
        public async Task<string> ReadHello()
        {
            byte[] result;
            using (FileStream sourceStream = File.Open("Hello.txt", FileMode.Open))
            {
                result = new byte[sourceStream.Length];
                await sourceStream.ReadAsync(result, 0, (int)sourceStream.Length);
            }

            return Encoding.ASCII.GetString(result);
        }

        public async Task<string> ReadWorld()
        {
            byte[] result;
            using (FileStream sourceStream = File.Open("World.txt", FileMode.Open))
            {
                result = new byte[sourceStream.Length];
                await sourceStream.ReadAsync(result, 0, (int)sourceStream.Length);
            }

            return Encoding.ASCII.GetString(result);
        }

        public string ReadAllConcad()
        {
            List<Task<string>> list = new List<Task<string>>();
            list.Add(Task.Run(async () => await ReadHello()));
            list.Add(Task.Run(async () => await ReadWorld()));
            string[] stringResult = Task.WhenAll(list).GetAwaiter().GetResult();

            return stringResult[0] + " " + stringResult[1];
        }

        public string ReadAllConcadSynch()
        {
            string hello = ReadHello().Result;
            string world = ReadWorld().Result;

            return hello + " " + world;
        }
    }
}
