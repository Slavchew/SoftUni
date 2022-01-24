using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty
{
    class PredicateParty
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine()
                .Split()
                .ToList();

            Action<string> dabul = name => people.Add(name);
            Action<string> remove = name => people.Remove(name);

            Func<string, List<string>> contain = cont => 
            { 
                return people.Where(x => x.Contains(cont)).ToList(); 
            };
            Func<int, List<string>> lenght = len => 
            { 
                return people.Where(x => x.Length == len).ToList(); 
            };

            string[] command = Console.ReadLine().Split().ToArray();
            while (command[0] != "Party!")
            {
                string cmdType = command[0];

                if (cmdType == "Double")
                {
                    if (command[1] == "Length")
                        lenght(int.Parse(command[2])).ForEach(x => dabul(x));
                    else
                        contain(command[2]).ForEach(x => dabul(x));
                }
                else if (cmdType == "Remove")
                {
                    if (command[1] == "Length ")
                        lenght(int.Parse(command[2])).ForEach(x => remove(x));
                    else
                        contain(command[2]).ForEach(x => remove(x));
                }
                command = Console.ReadLine().Split().ToArray();
            }

            if (people.Count != 0)
                Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
            else
                Console.WriteLine("Nobody is going to the party!");


        }
    }
}
