using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange
{
    class CurrencyExchange
    {
        static void Main(string[] args)
        {
            string cryptoCurr = Console.ReadLine();
            decimal sumToInvest = decimal.Parse(Console.ReadLine());

            if (sumToInvest > 1000)
            {
                sumToInvest *= 1.10m;
            }

            if (cryptoCurr == "XRP")
            {
                var coinXRP = sumToInvest / 0.22m;
                if (coinXRP > 80)
                {
                    if (coinXRP > 1000 && coinXRP < 2500)
                    {
                        coinXRP *= 1.05m;
                    }
                    else if (coinXRP >= 2500)
                    {
                        coinXRP *= 1.10m;
                    }
                    Console.WriteLine($"Successfully purchased {coinXRP:f3} {cryptoCurr}");
                }
                else
                    Console.WriteLine("Insufficient funds");

            }
            else if (cryptoCurr == "BTC")
            {
                var coinBTC = sumToInvest / 6400;
                if (coinBTC > 0.001m)
                {
                    if (coinBTC > 10)
                    {
                        coinBTC *= 1.02m;
                    }
                    Console.WriteLine($"Successfully purchased {coinBTC:f3} {cryptoCurr}");
                }
                else
                    Console.WriteLine("Insufficient funds");
            }
            else if (cryptoCurr == "ETH")
            {
                var coinETH = sumToInvest / 250;
                if (coinETH > 0.0099m)
                    Console.WriteLine($"Successfully purchased {coinETH:f3} {cryptoCurr}");
                else
                    Console.WriteLine("Insufficient funds");
            }
            else
                Console.WriteLine($"EUR to {cryptoCurr} is not supported.");
        }
    }
}
