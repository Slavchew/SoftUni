using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var students = new List<Student>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ");
                var firstName = input[0];
                var lastName = input[1];
                var grade = double.Parse(input[2]);
                Student student = new Student(firstName, lastName, grade);
                students.Add(student);
            }

            students = students.OrderByDescending(s => s.Grade).ToList();

            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }
    }

    class Student
    {
        public Student(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}";
        }
    }
}
