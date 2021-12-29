using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam
{
    public class Company
    {
        private string name;
        private List<Employee> employees = new List<Employee>();
        private string city;

        public Company(string name, string city)
        {
            Name = name;
            City = city;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length <= 2)
                {
                    throw new ArgumentException("Invalid company name");
                }
                this.name = value;
            }
        }
        public string City
        {
            get
            {
                return this.city;
            }
            set
            {
                if (value.Length <= 4 || !value[0].ToString().Equals(value[0].ToString().ToUpper()))
                {
                    throw new ArgumentException("Invalid city");
                }
                this.city = value;
            }
        }
        public List<Employee> Employees
        {
            get
            {
                return this.employees;
            }
            set
            {
                this.employees = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Company {this.Name} from {this.City} has the following employees:");
            foreach (var employee in Employees)
            {
                sb.AppendLine($"--->Employee: {employee.FirstName} {employee.LastName} with id: {employee.Id} and salary: {employee.Salary:f2}");
            }
            return sb.ToString().Trim();
        }

        public void HireEmployee(Employee emp)
        {
            this.Employees.Add(emp);
        }

        public void FireEmployee(string employeeId)
        {
            var emp = Employees.Where(x => x.Id == employeeId).FirstOrDefault();
            this.Employees.Remove(emp);
        }

        public void IncreaseSalaries(double amount)
        {
            foreach (var emp in Employees)
            {
                emp.Salary += amount;
            }
        }

        public void DecreaseSalaries(double amount)
        {
            foreach (var emp in Employees)
            {
                if (emp.Salary > amount)
                {
                    emp.Salary -= amount;
                }
            }
        }

        public Employee GetMostHighPaidEmployee()
        {
            var employee = this.Employees.OrderByDescending(x => x.Salary).FirstOrDefault();
            return employee;
        }

        public List<Employee> GetTopThreeMostHighPaidEmployees()
        {
            var tempEmployees = this.Employees.OrderByDescending(x => x.Salary).ToList();
            var employees = new List<Employee>();
            var index = 0;
            while (index < 3)
            {
                var emp = tempEmployees[0];
                employees.Add(emp);
                tempEmployees.RemoveAt(0);
                index++;
            }

            return employees;

        }

        public bool CheckEmployeeIsPresent(string employeeId)
        {
            var isExist = false;
            foreach (var emp in Employees)
            {
                if (emp.Id == employeeId)
                {
                    isExist = true;
                }
            }
            return isExist;
        }

        public double GetAverageEmployeeSalary()
        {
            var average = this.Employees.Select(x => x.Salary).Average();
            return average;
        }
    }
}
