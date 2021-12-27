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
            var employeesGroups = dbContext.Employees
                .GroupBy(x => x.Department.Name)
                .Where(x => x.Count() > 8)
                .Select(x => new
                {
                    DepartmentName = x.Key,
                    CountEmployees = x.Count()
                });

            foreach (var employeesGroup in employeesGroups)
            {
                Console.WriteLine(employeesGroup.DepartmentName + " => " + employeesGroup.CountEmployees);
            }
        }
    }
}
