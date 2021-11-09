using System;

namespace GodzillaVSKong
{
    class Program
    {
        static void Main(string[] args)
        {
            var filmBudget = decimal.Parse(Console.ReadLine());
            var extras = int.Parse(Console.ReadLine());
            var extrasPrice = decimal.Parse(Console.ReadLine());

            var decor = filmBudget * 0.10m;
            var extrasSum = extras * extrasPrice;
            if (extras > 150)
            {
                extrasSum *= 0.90m;
            }

            filmBudget -= decor;
            filmBudget -= extrasSum;

            if (filmBudget >= 0)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {filmBudget:f2} leva left.");
            }
            else
            {
                filmBudget = -filmBudget;
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {filmBudget:f2} leva more.");
            }
        }
    }
}
