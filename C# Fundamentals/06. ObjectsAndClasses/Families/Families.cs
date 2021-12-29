using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Families
{
    class Families
    {
        static void Main(string[] args)
        {
            Family family = new Family();
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split().ToArray();

                family.Persons.Add
                (
                    new Person()
                    {
                        Name = line[0],
                        Age = int.Parse(line[1])
                    }
                );
            }

            family.Persons = family.Persons.OrderBy(p => p.Name).ToList();
            Console.WriteLine(new string('-',30));
            family.Print();
        }
    }
}
