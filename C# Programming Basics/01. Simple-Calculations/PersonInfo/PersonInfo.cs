using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonInfo
{
    class PersonInfo
    {
        static void Main(string[] args)
        {
            Console.Write("Въведи име: ");
            var name = Console.ReadLine();
            Console.Write("Въведи фамилия: ");
            var lastName = Console.ReadLine();
            Console.Write("Въведи години: ");
            var age = int.Parse(Console.ReadLine());
            Console.Write("Въведи Град: ");
            var town = Console.ReadLine();
            Console.WriteLine("{0} {1} е на {2} години и е от град {3}", name, lastName, age, town);
        }
    }
}
