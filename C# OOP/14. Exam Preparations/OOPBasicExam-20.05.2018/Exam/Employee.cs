using System;
using System.Collections.Generic;
using System.Text;

namespace Exam
{
    public class Employee
    {
        private const double DefaultSalary = 500.0;

        private string id;
        private string firstName;
        private string lastName;
        private int age;
        private double salary;

        public Employee(string id, string firstName, string lastName, int age)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = DefaultSalary;
        }

        public Employee(string id, string firstName, string lastName, int age, double salary) : this(id, firstName, lastName, age)
        {
            Salary = salary;
        }

        public string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (value.Length <= 2 || value.Length > 8)
                {
                    throw new ArgumentException("Invalid employee name");
                }
                this.firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid employee age");
                }
                this.age = value;
            }
        }
        public double Salary
        {
            get
            {
                return this.salary;
            }
            set
            {
                this.salary = value;
            }
        }

        public override string ToString()
        {
            return $"Employee: {this.FirstName} {this.LastName} with id: {this.Id} and salary: {this.Salary:f2}";
        }
    }
}
