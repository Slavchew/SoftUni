using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExchange
{
    class MoneyExchange
    {
        static void Main(string[] args)
        {
            decimal moneyToInvest = decimal.Parse(Console.ReadLine());
            decimal bitcoinInDollars = decimal.Parse(Console.ReadLine());
            decimal satoshiPerByte = int.Parse(Console.ReadLine());

            decimal bitcoin = moneyToInvest / bitcoinInDollars;
            decimal buyingTaxesInBTC = bitcoin * (satoshiPerByte * 1024) / 100000000;
            bitcoin -= buyingTaxesInBTC;

            decimal programmerSalary = bitcoin * 0.10m;
            decimal taxesInUSD = buyingTaxesInBTC * bitcoinInDollars;
            bitcoin -= programmerSalary;

            Console.WriteLine($"Total bitcoin after expenses: {bitcoin:f5} BTC");
            Console.WriteLine($"Tax payed: {taxesInUSD:f2} USD");
            Console.WriteLine($"Programmer`s payment: {programmerSalary:f5} BTC");

        }
    }
}
