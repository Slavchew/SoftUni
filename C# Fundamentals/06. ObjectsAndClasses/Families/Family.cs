using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Families
{
    class Family
    {
        private List<Person> persons = new List<Person>();

        public List<Person> Persons
        {
            get { return persons; }
            set { persons = value; }
        }

        public void Print()
        {
            foreach (var person in Persons)
            {
                Console.WriteLine("{0} {1}", person.Name, person.Age);
            }
        }
    }
}
