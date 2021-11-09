using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Between_Currency_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            var amount = double.Parse(Console.ReadLine());
            var firstCurrency = Console.ReadLine().ToUpper();
            var secondCurrency = Console.ReadLine().ToUpper();

            if (firstCurrency == "BGN" )
            {
                if (secondCurrency == "USD")
                {
                    Console.WriteLine(Math.Round(amount / 1.79549,2) + " USD");
                }
                else if (secondCurrency == "EUR")
                {
                    Console.WriteLine(Math.Round(amount / 1.95583,2) + " EUR");
                }
                else if (secondCurrency == "GBP")
                {
                    Console.WriteLine(Math.Round(amount / 2.53405,2) + " GBP");
                }
            }
            if (firstCurrency == "USD")
            {
                if (secondCurrency == "BGN")
                {
                    Console.WriteLine(Math.Round(amount * 1.79549, 2) + " BGN");
                }
                else if (secondCurrency == "EUR")
                {
                    Console.WriteLine(Math.Round((amount * 1.79549) / 1.95583, 2) + " EUR");
                }
                else if (secondCurrency == "GBP")
                {
                    Console.WriteLine(Math.Round((amount * 1.79549) / 2.53405, 2) + " GBP");
                }
            }
            if (firstCurrency == "EUR")
            {
                if (secondCurrency == "BGN")
                {
                    Console.WriteLine(Math.Round(amount * 1.95583, 2) + " BGN");
                }
                else if (secondCurrency == "USD")
                {
                    Console.WriteLine(Math.Round((amount * 1.955839) / 1.79549, 2) + " USD");
                }
                else if (secondCurrency == "GBP")
                {
                    Console.WriteLine(Math.Round((amount * 1.95583) / 2.53405, 2) + " GBP");
                }
            }
            if (firstCurrency == "GBP")
            {
                if (secondCurrency == "BGN")
                {
                    Console.WriteLine(Math.Round(amount * 2.53405, 2) + " BGN");
                }
                else if (secondCurrency == "USD")
                {
                    Console.WriteLine(Math.Round((amount * 2.53405) / 1.79549, 2) + " USD");
                }
                else if (secondCurrency == "EUR")
                {
                    Console.WriteLine(Math.Round((amount * 2.53405) / 1.95583, 2) + " EUR");
                }
            }
        }
    }
}
