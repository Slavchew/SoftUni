using System;
using System.Collections.Generic;
using System.Linq;

namespace Google
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> people = new Dictionary<string, Person>();

            var input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "End")
            {
                string name = input[0];
                if (!people.ContainsKey(name))
                {
                    people[name] = new Person(name);
                }

                switch (input[1])
                {
                    case "company":
                        string companyName = input[2];
                        string companySection = input[3];
                        decimal salary = decimal.Parse(input[4]);
                        Company company = new Company(companyName, companySection, salary);
                        people[name].Company = company;
                        break;

                    case "pokemon":
                        string pokemonName = input[2];
                        string pokemonType = input[3];
                        Pokemon pokemon = new Pokemon(pokemonName, pokemonType);
                        people[name].Pokemons.Add(pokemon);
                        break;

                    case "parents":
                        string parentsName = input[2];
                        string parentsBday = input[3];
                        Parent parent = new Parent(parentsName, parentsBday);
                        people[name].Parents.Add(parent);
                        break;

                    case "children":
                        string childName = input[2];
                        string childBday = input[3];
                        Child child = new Child(childName, childBday);
                        people[name].Children.Add(child);
                        break;

                    case "car":
                        string carModel = input[2];
                        int carSpeed = int.Parse(input[3]);
                        Car car = new Car(carModel, carSpeed);
                        people[name].Car = car;
                        break;
                }

                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            var searchedName = Console.ReadLine();
            Person person = people.Values.FirstOrDefault(p => p.Name == searchedName);
            Console.WriteLine(person.ToString());
        }
    }
}
