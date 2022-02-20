namespace Collection_of_Persons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PersonCollectionSlow : IPersonCollection
    {
        // TODO: define the underlying data structures here ...
        private List<Person> people = new List<Person>();

        public bool AddPerson(string email, string name, int age, string town)
        {
            if (people.FirstOrDefault(x => x.Email == email) != null)
            {
                return false;
            }

            var person = new Person()
            {
                Email = email,
                Name = name,
                Age = age,
                Town = town,
            };

            people.Add(person);
            return true;
        }

        public int Count { get => this.people.Count; }
        public Person FindPerson(string email)
        {
            var person = people.FirstOrDefault(x => x.Email == email);
            return person;
        }

        public bool DeletePerson(string email)
        {
            var person = people.FirstOrDefault(x => x.Email == email);
            if (person == null)
            {
                return false;
            }

            people.Remove(person);
            return true;
        }

        public IEnumerable<Person> FindPersons(string emailDomain)
        {
            return people.Where(x => x.Email.EndsWith("@" + emailDomain))
                .OrderBy(x => x.Email);
        }

        public IEnumerable<Person> FindPersons(string name, string town)
        {
            return people.Where(x => x.Name == name && x.Town == town)
                .OrderBy(x => x.Email);
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge)
        {
            return people.Where(x => x.Age >= startAge && x.Age <= endAge)
                .OrderBy(x => x.Age)
                .ThenBy(x => x.Email);
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge, string town)
        {
            return people.Where(x => x.Age >= startAge && x.Age <= endAge && x.Town == town)
                .OrderBy(x => x.Age)
                .ThenBy(x => x.Email);
        }
    }
}
