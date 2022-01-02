using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resale
{
    class Resale
    {
        // 01. Препродажба
        static void Main(string[] args)
        {
            string model = Console.ReadLine();
            decimal price = decimal.Parse(Console.ReadLine());
            var days = int.Parse(Console.ReadLine());

            var afterCountrytTaxes = (price * 1.20m) + 275;
            var sumForDays = days * 20;
            var afterAllTaxes = afterCountrytTaxes + sumForDays;

            var profit = afterAllTaxes * 0.15m;
            var sellingPrice = profit + afterAllTaxes;

            Console.WriteLine($"The {model} with initial price of {price:f2} BGN will sell for {sellingPrice:f2} BGN");
            Console.WriteLine($"Profit: {profit:f2} BGN");
        }
    }
}
