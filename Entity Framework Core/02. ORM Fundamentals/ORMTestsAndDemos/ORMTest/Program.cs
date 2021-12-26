using ORMTest.Models;
using System;
using System.Linq;

namespace ORMTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();
            var employees = dbContext.Employees.Where(x => x.Department.Manager.Department.Name == "Sales")
                .Select(x => new
                {
                    Name = x.FirstName + " " + x.LastName,
                    DepartmentName = x.Department.Name,
                    Manager = x.Manager.FirstName + " " + x.Manager.LastName
                });

            foreach (var employee in employees)
            {
                Console.WriteLine(employee.Name + " => " + employee.DepartmentName + " => " + employee.Manager);
            }
        }
    }
}
