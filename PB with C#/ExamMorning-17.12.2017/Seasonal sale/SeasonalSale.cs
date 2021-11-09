using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seasonal_sale
{
    class SeasonalSale
    {
        // 03. Сезонна продажба
        static void Main(string[] args)
        {
            string model = Console.ReadLine();
            string type = Console.ReadLine().ToLower();
            string season = Console.ReadLine().ToLower();
            string condition = Console.ReadLine().ToLower();
            decimal carStartPrice = decimal.Parse(Console.ReadLine());
            decimal neededProfit = decimal.Parse(Console.ReadLine());

            decimal profit = 0.0m;

            if (type == "suv")
            {
                if (condition == "perfect")
                {
                    profit = carStartPrice * 0.30m;
                }
                else if (condition == "good")
                {
                    profit = carStartPrice * 0.20m;
                }
                else if (condition == "bad")
                {
                    profit = carStartPrice * 0.10m;
                }
            }
            else if (type == "sedan")
            {
                if (condition == "perfect")
                {
                    profit = carStartPrice * 0.25m;
                }
                else if (condition == "good")
                {
                    profit = carStartPrice * 0.15m;
                }
                else if (condition == "bad")
                {
                    profit = carStartPrice * 0.10m;
                }
            }

            if (season == "winter" || season == "summer")
            {
                if (season == "winter")
                {
                    profit -= 200;
                }
                if (profit >= neededProfit)
                {
                    Console.WriteLine($"The profit on {model} will be good - {profit:f2} BGN");
                }
                else
                {
                    Console.WriteLine("The car is not worth selling now");
                    Console.WriteLine("Need {0:f2} more profit", neededProfit - profit);
                }
            }
            else
                Console.WriteLine("Грешен месец");


        }
    }
}
