using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayAquarium
{
    class BirthdayAquarium
    {
        static void Main(string[] args)
        {
            var length = int.Parse(Console.ReadLine());
            if (length >= 10 && length <= 500)
            {
                var width = int.Parse(Console.ReadLine());
                if (width >= 10 && width <= 300)
                {
                    var height = int.Parse(Console.ReadLine());
                    if (height >= 10 && height <= 200)
                    {
                        double percentage = double.Parse(Console.ReadLine());
                        if (percentage >= 0 && percentage <= 100)
                        {
                            var volume = length * width * height;
                            var totalLiters = volume * 0.001;
                            var realPercentage = percentage * 0.01;
                            var realLitersForArea = totalLiters * (1 - realPercentage);
                            Console.WriteLine(Math.Round(realLitersForArea, 3));
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
