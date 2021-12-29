using System;
using System.Collections.Generic;
using System.Linq;

namespace OldestMember
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var family = new Family();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ");
                var name = input[0];
                var age = int.Parse(input[1]);
                Person person = new Person(name, age);
                family.AddMember(person);
            }
            Person oldestPerson = family.GetOldestMember();
            Console.WriteLine(oldestPerson.ToString());
        }
    }

    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }

    class Family
    {
        public Family()
        {
            Persons = new List<Person>();
        }
        public List<Person> Persons { get; set; }

        public void AddMember(Person person)
        {
            Persons.Add(person);
        }

        public Person GetOldestMember()
        {
            return Persons.OrderByDescending(p => p.Age).FirstOrDefault();
        }
    }
}
