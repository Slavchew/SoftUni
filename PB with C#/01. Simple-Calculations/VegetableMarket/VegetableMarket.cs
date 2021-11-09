using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableMarket
{
    class VegetableMarket
    {
        static void Main(string[] args)
        {
            var vegMoneyKg = double.Parse(Console.ReadLine());
            if (vegMoneyKg >= 0 && vegMoneyKg <= 1000)
            {
                var fruitMoneyKg = double.Parse(Console.ReadLine());
                if (fruitMoneyKg >= 0 && fruitMoneyKg <= 1000)
                {
                    var totalVegKg = int.Parse(Console.ReadLine());
                    if (totalVegKg >= 0 && totalVegKg <= 1000)
                    {
                        var totalFruitKg = int.Parse(Console.ReadLine());
                        if (totalFruitKg >= 0 && totalFruitKg <= 1000)
                        {
                            var vegSum = vegMoneyKg * totalVegKg;
                            var fruitSum = fruitMoneyKg * totalFruitKg;
                            var sumBgn = vegSum + fruitSum;
                            var sumEur = sumBgn / 1.94;
                            Console.WriteLine(Math.Round(sumEur,2) + " EUR");
                        }
                        else
                        {
                            Console.WriteLine("Имате грешка в началните данни");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Имате грешка в началните данни");
                    }
                }
                else
                {
                    Console.WriteLine("Имате грешка в началните данни");
                }
            }
            else
            {
                Console.WriteLine("Имате грешка в началните данни");
            }

        }
    }
}
