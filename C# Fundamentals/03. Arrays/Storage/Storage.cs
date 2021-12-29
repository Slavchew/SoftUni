using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    class Storage
    {
        static void Main(string[] args)
        {
            string[] products = Console.ReadLine().Split(' ');
            long[] quantity = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            decimal[] prices = Console.ReadLine().Split(' ').Select(decimal.Parse).ToArray();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "done")
                {
                    break;
                }
                else
                {
                    var index = Array.IndexOf(products, command);
                    Console.WriteLine($"{products[index]} costs: {prices[index]}; Available quantity: {quantity[index]}");
                }
            }
        }
    }
}
