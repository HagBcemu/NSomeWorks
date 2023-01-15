using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace NSomeWorks
{
    class QueryesLINQ
    {
        public QueryesLINQ()
        {
            Query1();
            Query2();
            Query3();
            Query4();
            Query5();
            Query6();
        }

        private void Query1()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("Query 1");

                var query = db.Employees.Include(e => e.EmployeeProject).ThenInclude(p => p.Project);

                var sql = query.ToString();

                Console.WriteLine(query.ToQueryString());
            }
        }

        private void Query2()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("Query 2");

                IQueryable<Employee> query = db.Employees;

                var query2 = from emploe in query
                             select new
                             {
                                 emploe.LastName,
                                 DateDifference = DateTime.Now - emploe.HiredDate
                             };
                Console.WriteLine(query2.ToQueryString());
            }
        }

        private void Query3()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var transaction = db.Database.BeginTransaction();
                Console.WriteLine("Query 3");
                try
                {
                    Project query = db.Projects.Find(1);
                    Project query2 = db.Projects.Find(2);
                    query.Budget = new Random().Next(10000, 150000);
                    query2.Budget = new Random().Next(10000, 150000);
                    db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }

        private void Query4()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("Query 4");

                Title title = new Title { Name = "Title №" + new Random().Next(1, 20) };

                Project project = new Project { Name = "Project № " + new Random().Next(1, 20), Budget = new Random().Next(10000, 1500000), StartedDate = DateTime.Now, ClientID = 2 };

                Employee employee = new Employee { FirstName = "FirstName1", LastName = "LastName2", HiredDate = DateTime.Now, OfficeId = 1, Title = title };

                db.Add(title);
                db.Add(project);
                db.Add(employee);

                db.SaveChanges();
            }
        }

        private void Query5()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("Query 5");

                var employees = db.Employees.ToList();
                if (employees.Count == 0)
                {
                    return;
                }

                Employee employeeRemove = employees[employees.Count - 1];
                db.Employees.Remove(employeeRemove);
                db.SaveChanges();
            }
        }

        private void Query6()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("Query 6");
                var query = from emploee in db.Employees
                            where !emploee.Title.Name.Contains("a")
                            group emploee by emploee.Title.Name into g
                            select new { g.Key };
                Console.WriteLine(query.ToQueryString());
            }
        }
    }
}
