using System;
using System.Collections.Generic;
using System.Linq;

using ShopingSpree.Models;

namespace ShopingSpree.Core
{
    public class Engine
    {
        private readonly ICollection<Person> people;
        private readonly ICollection<Product> products;
        public Engine()
        {
            this.people = new List<Person>();
            this.products = new List<Product>();
        }

        public void Run()
        {
            try
            {
                this.ParsePeopleInput();

                this.ParseProductsInput();

                string command;
                while((command = Console.ReadLine()) != "END")
                {
                    string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                    string personName = cmdArgs[0];
                    string productName = cmdArgs[1];

                    Person person = this.people.FirstOrDefault(p => p.Name == personName);
                    Product product = this.products.FirstOrDefault(p => p.Name == productName);

                    if (person != null && product != null)
                    {
                        string result = person.BuyProduct(product);

                        Console.WriteLine(result);
                    }
                }

                foreach (Person person in this.people)
                {
                    Console.WriteLine(person);
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        private void ParsePeopleInput()
        {
            string[] peopleArgs = Console.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (var personStr in peopleArgs)
            {
                var personArgs = personStr.Split("=", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string personName = personArgs[0];
                decimal personMoney = decimal.Parse(personArgs[1]);

                Person person = new Person(personName, personMoney);

                this.people.Add(person);
            }
        }

        private void ParseProductsInput()
        {
            string[] productsArgs = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (var productStr in productsArgs)
            {
                var productArgs = productStr.Split("=", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string productName = productArgs[0];
                decimal productCost = decimal.Parse(productArgs[1]);

                Product product = new Product(productName, productCost);

                this.products.Add(product);
            }
        }
    }
}
