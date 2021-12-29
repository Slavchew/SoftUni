using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistics
{
    class Statistics
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split().ToArray();
                persons.Add(new Person(line[0], int.Parse(line[1])));
            }
            persons = persons.Where(p => p.Age > 30).ToList();
            persons = persons.OrderBy(p => p.Name).ToList();
            Console.WriteLine("-------------------------------------------------------------");
            foreach (var person in persons)
            {
                Console.WriteLine("{0} {1}",person.Name,person.Age);
            }
        }
    }
}
