using StudentsORMTest.Models;
using System;
using System.Linq;

namespace StudentsORMTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dbContext = new StudentsDbContext();

            dbContext.Grades.Add(new Grade
            {
                Student = new Student { FirstName = "Stoyan", LastName = "Shopov"},
                Course = new Course { Name = "C# OOP"},
                Value = 6.00M
            });
            dbContext.SaveChanges();
        }
    }
}
