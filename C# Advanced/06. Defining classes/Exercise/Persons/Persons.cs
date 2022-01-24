using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons
{
    class Persons
    {
        static void Main(string[] args)
        {
            Person human1 = new Person();
            Person human2 = new Person();
            Person human3 = new Person();

            human1.Name = "Pesho";
            human1.Age = 20;

            human2.Name = "Gosho";
            human2.Age = 18;

            human3.Name = "Stamat";
            human3.Age = 43;

            Console.WriteLine($"{human1.Name} {human1.Age}");
            Console.WriteLine($"{human2.Name} {human2.Age}");
            Console.WriteLine($"{human3.Name} {human3.Age}");
        }
    }
}
