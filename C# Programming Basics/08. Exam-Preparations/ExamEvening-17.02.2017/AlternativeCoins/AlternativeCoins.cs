using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlternativeCoins
{
    class AlternativeCoins
    {
        static void Main(string[] args)
        {
            decimal bitcoins = decimal.Parse(Console.ReadLine());
            decimal bitcoinStartPrice = decimal.Parse(Console.ReadLine());
            decimal bitcoinNewPrice = decimal.Parse(Console.ReadLine());
            decimal ethereum = decimal.Parse(Console.ReadLine());
            decimal neo = decimal.Parse(Console.ReadLine());

            decimal diff = Math.Abs((bitcoins * bitcoinNewPrice) - (bitcoins * bitcoinStartPrice));
            decimal priceETH = bitcoinNewPrice * 0.075m;
            decimal priceNeo = priceETH * 0.40m;
            decimal priceToInvest = (priceETH * ethereum) + (priceNeo * neo);

            if (diff >= priceToInvest)
            {
                Console.WriteLine($"Stefcho bought {ethereum:f4} Ethereum at a price of {priceETH:f4}");
                Console.WriteLine($"Stefcho bought {neo:f4} Neo at a price of {priceNeo:f4}");
                Console.WriteLine("Stefcho has {0:f2} profits left to spend.",diff - priceToInvest);
            }
            else
            {
                Console.WriteLine("Stefcho does not have enough money to make this investment.");
                Console.WriteLine("He needs {0:f2} more in profits.",priceToInvest - diff);
            }
        }
    }
}
