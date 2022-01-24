using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListofEmployees
{
    class ListofEmployees
    {
        static void Main(string[] args)
        {
            var employees = new List<Employee>();

            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(' ');

                int age = -1;
                string email = "n/a";
                if (line.Length == 6)
                {
                    email = line[4];
                    age = int.Parse(line[5]);
                }
                else if (line.Length > 4)
                {
                    if (!int.TryParse(line[4],out age))
                    {
                        age = -1;
                        if (!string.IsNullOrEmpty(line[4]))
                        {
                            email = line[4];
                        }
                    }
                }

                employees.Add(new Employee
                {
                    Name = line[0],
                    Salary = decimal.Parse(line[1]),
                    Position = line[2],
                    Section = line[3],
                    Mail = email,
                    Age = age
                });              
            }
            var departaments = new Dictionary<string, List<decimal>>();
            foreach (var employee in employees)
            {
                if (!departaments.ContainsKey(employee.Section))
                {
                    departaments[employee.Section] = new List<decimal>();
                }
                departaments[employee.Section].Add(employee.Salary);
            }
            var averageSalaryByDepartments = new Dictionary<string, decimal>();
            foreach (var item in departaments.Keys)
            {
                averageSalaryByDepartments[item] = departaments[item].Average();
            }
            var maxAverageSalaryDepartment = averageSalaryByDepartments.OrderByDescending(item => item.Value).First();
            Console.WriteLine("Highest Average Salary: {0}", maxAverageSalaryDepartment.Key);

            employees = employees.OrderByDescending(x => x.Salary).ToList();

            foreach (var employ in employees)
            {
                if (employ.Section == maxAverageSalaryDepartment.Key)
                {
                    Console.WriteLine($"{employ.Name} {employ.Salary} {employ.Mail} {employ.Age}");
                }
            }
        }
    }
}
