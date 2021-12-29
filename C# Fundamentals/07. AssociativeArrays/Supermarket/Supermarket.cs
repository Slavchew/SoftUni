using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    class Supermarket
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine().Split(' ');
            var stocksPrices = new Dictionary<string, double>();
            var stocksQty = new Dictionary<string, int>();
            var total = 0.0;

            while (command[0] != "stocked")
            {
                if (!stocksQty.ContainsKey(command[0]))
                {
                    stocksQty[command[0]] = 0;
                }

                stocksPrices[command[0]] = double.Parse(command[1]);
                stocksQty[command[0]] += int.Parse(command[2]);

                command = Console.ReadLine().Split(' ');
            }

            foreach (var product in stocksPrices)
            {
                total += product.Value * stocksQty[product.Key];
                Console.WriteLine($"{product.Key}: ${product.Value:F2} * {stocksQty[product.Key]} = ${product.Value * stocksQty[product.Key]:F2}");
            }
            Console.WriteLine(new string('-', 30));
            Console.WriteLine($"Grand Total: ${ total:F2}");
        }
    }
}
