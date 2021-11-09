using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TilesRepair
{
    class TilesRepair
    {
        static void Main(string[] args)
        {
            var landingSide = int.Parse(Console.ReadLine());
            if (landingSide >= 1 && landingSide <= 100)
            {
                var tileWidth = double.Parse(Console.ReadLine());
                if (tileWidth >= 0.1 && tileWidth <= 10)
                {
                    var tileLength = double.Parse(Console.ReadLine());
                    if (tileLength >= 0.1 && tileLength <= 10)
                    {
                        var benchWidth = int.Parse(Console.ReadLine());
                        if (benchWidth >= 0 && benchWidth <= 10)
                        {
                            var benchLength = int.Parse(Console.ReadLine());
                            if (benchLength >= 0 && benchLength <= 10)
                            {
                                var landingArea = landingSide * landingSide;
                                var benchArea = benchLength * benchWidth;
                                var tileArea = tileWidth * tileLength;
                                var areaForWork = landingArea - benchArea;
                                var numbersOfTiles = areaForWork / tileArea;
                                var time = numbersOfTiles * 0.2;
                                Console.WriteLine(numbersOfTiles);
                                Console.WriteLine(time);
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
