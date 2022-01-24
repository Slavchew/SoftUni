using System;
using System.Collections.Generic;
using System.Text;

namespace FamilyTree
{
    class Person
    {
        public Person()
        {
            Parents = new List<Person>();
            Children = new List<Person>();
        }
        public Person(string name, string birthday)
        {
            Name = name;
            Birthday = birthday;
            Parents = new List<Person>();
            Children = new List<Person>();
        }

        public string Name { get; set; }
        public string Birthday { get; set; }
        public List<Person> Parents { get; set; }
        public List<Person> Children { get; set; }
    }
}
