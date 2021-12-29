using System;
using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
    class SoftUniBarIncome
    {
        static void Main(string[] args)
        {
            string pattern = @"%([A-Z][a-z]+)%[^|$%.]*<(\w+)>[^|$%.]*\|(\d+)\|[^|$%.]*?(\d+\.?\d+)\$";
            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();
            decimal totalIncome = 0.0m;

            while (input != "end of shift")
            {
                Match match = regex.Match(input);

                if (match.Success)
                {
                    //customer, product, count and a price.
                    string customer = match.Groups[1].Value;
                    string product = match.Groups[2].Value;
                    int count = int.Parse(match.Groups[3].Value);
                    decimal price = decimal.Parse(match.Groups[4].Value);

                    var totalPrice = count * price;
                    totalIncome += totalPrice;

                    Console.WriteLine($"{customer}: {product} - {totalPrice:f2}");
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
