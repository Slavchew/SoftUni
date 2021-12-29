using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tablecloths
{
    class Tablecloths
    {
        static void Main(string[] args)
        {
            var tables = int.Parse(Console.ReadLine());
            if (tables > 0 && tables <= 500)
            {
                var tableLenght = double.Parse(Console.ReadLine());
                if (tableLenght > 0 && tableLenght <= 3)
                {
                    var tableWidth = double.Parse(Console.ReadLine());
                    if (tableWidth > 0 && tableWidth <= 3)
                    {
                        var wholeTableArea = tables * (tableLenght + 2 * 0.30) * (tableWidth + 2 * 0.30);
                        var wholeSquareArea = tables * (tableLenght / 2) * (tableLenght / 2);
                        var priceInDollars = wholeTableArea * 7 + wholeSquareArea * 9;
                        var priceInLev = priceInDollars * 1.85;
                        Console.WriteLine(Math.Round(priceInDollars, 2) + " USD");
                        Console.WriteLine(Math.Round(priceInLev, 2) + " BGN");
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

