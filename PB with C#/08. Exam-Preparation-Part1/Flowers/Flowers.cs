using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowers
{
    class Flowers
    {
        static void Main(string[] args)
        {
            var chrysanthemums = int.Parse(Console.ReadLine());
            var roses = int.Parse(Console.ReadLine());
            var tulips = int.Parse(Console.ReadLine());
            var season = Console.ReadLine();
            var holiday = Console.ReadLine();

            var chrysanthemumsMoney = 0.0;
            var rosesMoney = 0.0;
            var tulipsMoney = 0.0;
            var sum = 0.0;
            var numberOfFlowers = chrysanthemums + roses + tulips;

            if (season == "Spring" || season == "Summer")
            {
                chrysanthemumsMoney = chrysanthemums * 2.00;
                rosesMoney = roses * 4.10;
                tulipsMoney = tulips * 2.50;
                sum = chrysanthemumsMoney + rosesMoney + tulipsMoney;
                if (holiday == "Y")
                {
                    sum = sum * 1.15;
                }
                if (tulips > 7 && season == "Spring")
                {
                    sum = sum * 0.95;
                }
                if (numberOfFlowers > 20)
                {
                    sum = sum * 0.8;
                }
            }
            else if (season == "Autumn" || season == "Winter")
            {
                chrysanthemumsMoney = chrysanthemums * 3.75;
                rosesMoney = roses * 4.50;
                tulipsMoney = tulips * 4.15;
                sum = chrysanthemumsMoney + rosesMoney + tulipsMoney;
                if (holiday == "Y")
                {
                    sum = sum * 1.15;
                }
                if (roses >= 10 && season == "Winter")
                {
                    sum = sum * 0.9;
                }
                if (numberOfFlowers > 20)
                {
                    sum = sum * 0.8;
                }
            }
            sum = sum + 2;
            Console.WriteLine("{0:f2}",sum);
        }
    }
}
