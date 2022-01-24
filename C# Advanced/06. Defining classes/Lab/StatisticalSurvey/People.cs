using System;
using System.Collections.Generic;
using System.Linq;

namespace StatisticalSurvey
{
    class People
    {
        private List<Person> people = new List<Person>();
        public void AddMember(Person member)
        {
            people.Add(member);
        }
        public void Over30()
        {
            List<Person> over30 = new List<Person>();
            over30 = people.OrderBy(x => x.Name).Where(x => x.Age > 30).ToList();
            foreach (var person in over30)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }

    }
}
