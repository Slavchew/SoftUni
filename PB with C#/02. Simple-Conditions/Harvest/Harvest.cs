using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest
{
    class Harvest
    {
        static void Main(string[] args)
        {
            var area = int.Parse(Console.ReadLine());
            if (area >= 10 && area <= 5000)
            {
                var grapesPerSquareMeter = double.Parse(Console.ReadLine());
                if (grapesPerSquareMeter >= 0 && grapesPerSquareMeter <= 10)
                {
                    var litersOfWine = int.Parse(Console.ReadLine());
                    if (litersOfWine >= 10 && litersOfWine <= 600)
                    {
                        var numberOfWorkers = int.Parse(Console.ReadLine());
                        if (numberOfWorkers >= 1 && numberOfWorkers <=20)
                        {
                            var harvestPerWine = area * grapesPerSquareMeter * 0.4;
                            var wine = harvestPerWine / 2.5;
                            if (wine < litersOfWine)
                            {
                                Console.WriteLine("It will be a tough winter! More {0} liters wine needed.",Math.Floor(litersOfWine - wine));
                            }
                            else
                            {
                                var moreWine = wine - litersOfWine;
                                Console.WriteLine("Good harvest this year! Total wine: {0} liters.",Math.Floor(wine));
                                Console.WriteLine("{0} liters left -> {1} liters per person.", Math.Ceiling(moreWine),Math.Ceiling(moreWine / numberOfWorkers));
                            }
                        }
                        else
                        {
                            Console.WriteLine("Грешен вход");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Грешен вход");
                    }
                }
                else
                {
                    Console.WriteLine("Грешен вход");
                }
            }
            else
            {
                Console.WriteLine("Грешен вход");
            }
        }
    }
}
