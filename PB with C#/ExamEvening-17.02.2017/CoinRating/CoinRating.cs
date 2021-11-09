using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinRating
{
    class CoinRating
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            decimal sum = 0.0m;
            int dogeCount = 0;
            decimal dogeSum = 0.0m;
            int iotaCount = 0;
            decimal iotaSum = 0.0m;
            int neoCount = 0;
            decimal neoSum = 0.0m;
            int estdCount = 0;
            decimal estdSum = 0.0m;


            for (int i = 0; i < n; i++)
            {
                string coinType = Console.ReadLine().ToUpper();
                decimal coins = decimal.Parse(Console.ReadLine());

                if (coinType == "DOGE")
                {
                    dogeCount++;
                    dogeSum = dogeSum + (coins * 0.07m);
                }
                else if (coinType == "IOTA")
                {
                    iotaCount++;
                    iotaSum = iotaSum + (coins * 1.44m);
                }
                else if (coinType == "NEO")
                {
                    neoCount++;
                    neoSum = neoSum + (coins * 28.50m);
                }
                else if (coinType == "ESTD")
                {
                    estdCount++;
                    estdSum = estdSum + (coins * 25.0m);
                }
            }

            sum = dogeSum + iotaSum + neoSum + estdSum;
            decimal dogeRate = (dogeSum / sum) * 100;
            decimal iotaRate = (iotaSum / sum) * 100;
            decimal neoRate = (neoSum / sum) * 100;
            decimal estdRate = (estdSum / sum) * 100;

            Console.WriteLine($"Total votes = {n}, Money in market = {sum:f2} EUR");
            Console.WriteLine($"DOGE's contribution: {dogeRate:f2}%; People who use DOGE: {dogeCount}");
            Console.WriteLine($"IOTA's contribution: {iotaRate:f2}%; People who use IOTA: {iotaCount}");
            Console.WriteLine($"NEO's contribution: {neoRate:f2}%; People who use NEO: {neoCount}");
            Console.WriteLine($"ESTD's contribution: {estdRate:f2}%; People who use ESTD: {estdCount}");
        }
    }
}
