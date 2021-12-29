using System;

namespace Crypto
{
    class Crypto
    {
        static void Main(string[] args)
        {
            var bitcoinPrice = decimal.Parse(Console.ReadLine());
            var ethereumPrice = decimal.Parse(Console.ReadLine());
            var litecoinPrice = decimal.Parse(Console.ReadLine());
            var transactions = int.Parse(Console.ReadLine());

            var cryptoWallet = 0.0m;
            var commissionPrice = 0.073456764216789345m;

            for (int i = 0; i < transactions; i++)
            {
                var assets = ulong.Parse(Console.ReadLine());
                var coinType = Console.ReadLine();
                var command = Console.ReadLine();

                var sum = 0.0m;
                var commission = 0.0m;
                if (command == "Buy")
                {
                    if (coinType == "Bitcoin")
                    {
                        sum = assets * bitcoinPrice;
                    }
                    else if (coinType == "Ethereum")
                    {
                        sum = assets * ethereumPrice;
                    }
                    else if (coinType == "Litecoin")
                    {
                        sum = assets * litecoinPrice;
                    }
                    commission = sum * commissionPrice;

                    cryptoWallet += sum;
                    cryptoWallet -= commission;

                }
                else if (command == "Sell")
                {
                    if (coinType == "Bitcoin")
                    {
                        sum = assets * bitcoinPrice;
                    }
                    else if (coinType == "Ethereum")
                    {
                        sum = assets * ethereumPrice;
                    }
                    else if (coinType == "Litecoin")
                    {
                        sum = assets * litecoinPrice;
                    }
                    commission = sum * commissionPrice;

                    cryptoWallet -= sum;
                    cryptoWallet -= commission;
                }
            }

            Console.WriteLine($"{cryptoWallet:f16}");
        }
    }
}
