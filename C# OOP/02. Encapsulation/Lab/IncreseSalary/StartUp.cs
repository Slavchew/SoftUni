using System;
using System.Collections.Generic;

namespace IncreseSalary
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
            for (int i = 0; i < lines; i++)
            {
                try
                {
                    var cmdArgs = Console.ReadLine().Split();
                    var person = new Person(cmdArgs[0],
                                            cmdArgs[1],
                                            int.Parse(cmdArgs[2]),
                                            double.Parse(cmdArgs[3]));

                    persons.Add(person);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
            var bonus = double.Parse(Console.ReadLine());

            foreach (var person in persons)
            {
                person.IncreaseSalary(bonus);
                Console.WriteLine(person);
            }

        }
    }
}
