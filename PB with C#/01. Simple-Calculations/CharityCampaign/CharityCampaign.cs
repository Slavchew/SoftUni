using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityCampaign
{
    class CharityCampaign
    {
        static void Main(string[] args)
        {

            var days = int.Parse(Console.ReadLine());
            if (days > 0 && days <= 365)
            {
                var participants = int.Parse(Console.ReadLine());
                if (participants > 0 && participants <= 1000)
                {
                    var cake = int.Parse(Console.ReadLine());
                    if (cake > 0 && cake <= 2000)
                    {
                        var waffles = int.Parse(Console.ReadLine());
                        if (waffles > 0 && waffles <= 2000)
                        {
                            var pancakes = int.Parse(Console.ReadLine());
                            if (pancakes > 0 && pancakes <= 2000)
                            {
                                var cakePrice = cake * 45;
                                var wafflesPrice = waffles * 5.80;
                                var pancakesPrice = pancakes * 3.20;
                                var wholeSumForDay = (cakePrice + wafflesPrice + pancakesPrice) * participants;
                                var wholeSumForAllDays = wholeSumForDay * days;
                                var moneyFromCampaign = wholeSumForAllDays - (0.125 * wholeSumForAllDays);
                                Console.WriteLine($"{moneyFromCampaign:f2}");
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
