using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigerStorage
{
    class BigerStorage
    {
        static void Main(string[] args)
        {
            string[] products = Console.ReadLine().Split(' ');
            string inputqty = Console.ReadLine();
            long[] qty = new long[1];
            try
            {
                qty = inputqty.Split(' ').Select(long.Parse).ToArray();
            }
            catch 
            {
                qty[0] = 0;
            }
            decimal[] prices = Console.ReadLine().Split(' ').Select(decimal.Parse).ToArray();
            long[] qtyUpdated = new long[products.Length];

            for (int i = 0; i < qty.Length; i++)
            {
                qtyUpdated[i] = qty[i];
            }

            while (true)
            {
                string[] command = Console.ReadLine().Split(' ');
                if (command[0] == "done")
                {
                    break;
                }
                else
                {
                    var index = Array.IndexOf(products, command[0]);
                    if (qtyUpdated[index] < long.Parse(command[1]) )
                    {
                        Console.WriteLine($"We do not have enough {products[index]}");
                    }
                    else
                    {
                        var sum = long.Parse(command[1]) * prices[index];
                        Console.WriteLine($"{products[index]} x {command[1]} costs {sum:f2}");
                        qtyUpdated[index] -= long.Parse(command[1]);
                    }
                }
            }
        }
    }
}
