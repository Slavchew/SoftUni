using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiningTask
{
    class MiningTask
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var dict = new Dictionary<string, long>();
            while (input != "stop")
            {
                long quantity = long.Parse(Console.ReadLine());
                if (dict.ContainsKey(input))
                {
                    dict[input] += quantity;
                }
                else
                {
                    dict[input] = quantity;
                }

                input = Console.ReadLine();
            }

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
