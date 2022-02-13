using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P07.SumOfCoins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var coins = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderByDescending(x => x));

            var target = int.Parse(Console.ReadLine());
            var usedCoins = 0;
            var sb = new StringBuilder();

            while (target > 0 && coins.Count > 0)
            {
                var currentCoin = coins.Dequeue();
                if (target < currentCoin)
                {
                    continue;
                }

                var count = target / currentCoin;
                usedCoins += count;
                sb.AppendLine($"{count} coin(s) with value {currentCoin}");

                target -= count * currentCoin;
            }

            if (target == 0)
            {
                Console.WriteLine($"Number of coins to take: {usedCoins}");
                Console.WriteLine(sb.ToString());
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}
