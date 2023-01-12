using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace NSomeWorks
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder
               .UseSqlServer(connectionString)
              .Options;

            Console.WriteLine("Все клиенты в БД: \n");
            using (ApplicationContext db = new ApplicationContext(options))
            {
                var clients = db.Clients.ToList();
                foreach (Client client in clients)
                {
                    Console.WriteLine("\nTitleId: " + client.ClientId);
                    Console.WriteLine("FirstName: " + client.FirstName);
                    Console.WriteLine("LastName: " + client.LastName);
                    Console.WriteLine("NameCompany: " + client.NameCompany);
                    Console.WriteLine("Email: " + client.Email);
                    Console.WriteLine("PhoneNumber: " + client.PhoneNumber);
                }
            }

            Console.WriteLine("\nКонец программы");
            Console.ReadKey();
        }
    }
}