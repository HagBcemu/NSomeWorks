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

            Console.WriteLine("Все работники в БД: \n");
            using (ApplicationContext db = new ApplicationContext(options))
            {
                var employees = db.Employees.ToList();
                foreach (Employee employee in employees)
                {
                    Console.WriteLine("TitleId " + employee.TitleId);
                    Console.WriteLine("FirstName " + employee.FirstName);
                    Console.WriteLine("LastName " + employee.LastName);
                    Console.WriteLine("HiredDate " + employee.HiredDate);
                    Console.WriteLine("DateOfBirth " + employee.DateOfBirth);
                    Console.WriteLine("OfficeId " + employee.OfficeId);
                    Console.WriteLine("TitleId " + employee.TitleId);
                }
            }

            Console.WriteLine("\nКонец программы");
            Console.ReadKey();
        }
    }
}