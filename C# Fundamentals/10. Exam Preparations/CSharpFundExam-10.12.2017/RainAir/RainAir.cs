using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RainAir
{
    class RainAir
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var customers = new Dictionary<string, List<int>>();

            while (input != "I believe I can fly!")
            {
                if (input.Contains("="))
                {
                    var names = input.Split('=').ToList();
                    var customer1 = names[0].Trim();
                    var customer2 = names[1].Trim();

                    var customer2Flights = customers[customer2];
                    customers[customer1].Clear();
                    customers[customer1].AddRange(customer2Flights);
                }
                else
                {
                    var flights = input.Split(' ').ToList();
                    var customer = flights[0];
                    if (customers.ContainsKey(customer))
                    {
                        for (int i = 1; i < flights.Count; i++)
                        {
                            var flight = int.Parse(flights[i]);
                            customers[customer].Add(flight);
                        }
                    }
                    else
                    {
                        customers[customer] = new List<int>();
                        for (int i = 1; i < flights.Count; i++)
                        {
                            var flight = int.Parse(flights[i]);
                            customers[customer].Add(flight);
                        }
                    }
                }
                input = Console.ReadLine();
            }


            var sortedCustomers = customers.OrderByDescending(x => x.Value.Count).ThenBy(a => a.Key);

            foreach (var customer in sortedCustomers)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"#{customer.Key} ::: ");
                sb.Append(string.Join(", ", customer.Value.OrderBy(x => x)));
                Console.WriteLine(sb);
            }
        }
    }
}
