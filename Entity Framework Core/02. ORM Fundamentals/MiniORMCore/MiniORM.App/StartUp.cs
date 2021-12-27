using MiniORM.App.Data;
using MiniORM.App.Data.Entities;
using System;
using System.Linq;

namespace MiniORM.App
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string connectionString = "Server=.;Database=MiniORM;Integrated Security=true;TrustServerCertificate=true";

            SoftUniDbContext dbContext = new SoftUniDbContext(connectionString);

            dbContext.Employees.Add(new Employee
            {
                FirstName = "Gosho",
                LastName = "Inserted",
                DepartmentId = dbContext.Departments.First().Id,
                IsEmployed = true,
            });

            Employee employee = dbContext.Employees.Last();
            employee.FirstName = "Modified";

            dbContext.SaveChanges();
        }
    }
}
