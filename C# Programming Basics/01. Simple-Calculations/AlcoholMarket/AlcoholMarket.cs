using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcoholMarket
{
    class AlcoholMarket
    {
        static void Main(string[] args)
        {
            var whiskeyMoneyforLitter = double.Parse(Console.ReadLine());
            if (whiskeyMoneyforLitter > 0 && whiskeyMoneyforLitter <= 10000)
            {
                var beerQuantity = double.Parse(Console.ReadLine());
                if (beerQuantity >= 0 && beerQuantity <= 10000)
                {
                    var wineQuantity = double.Parse(Console.ReadLine());
                    if (wineQuantity >= 0 && wineQuantity <= 10000)
                    {
                        var brandyQuantity = double.Parse(Console.ReadLine());
                        if (brandyQuantity >= 0 && brandyQuantity <= 10000)
                        {
                            var whiskeyQuantity = double.Parse(Console.ReadLine());
                            if (whiskeyQuantity >= 0 && whiskeyQuantity <= 10000)
                            {
                                var brandyMoneyForLitter = whiskeyMoneyforLitter * 0.5;
                                var whiskeyAmount = whiskeyMoneyforLitter * whiskeyQuantity;
                                var brandyAmount = brandyMoneyForLitter * brandyQuantity;
                                var wineAmount = (0.60 * brandyMoneyForLitter) * wineQuantity;
                                var beerAmount = (0.20 * brandyMoneyForLitter) * beerQuantity;
                                var wholeSum = whiskeyAmount + brandyAmount + wineAmount + beerAmount;
                                Console.WriteLine(Math.Round(wholeSum,2));
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
            else
            {
                Console.WriteLine("Имате грешка в началните данни");
            }
        }
    }
}
