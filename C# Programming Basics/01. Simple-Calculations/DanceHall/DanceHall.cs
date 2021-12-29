using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceHall
{
    class DanceHall
    {
        static void Main(string[] args)
        {
            var lenght = double.Parse(Console.ReadLine());
            if (lenght >= 10 && lenght <= 100)
            {
                var width = double.Parse(Console.ReadLine());
                if (width >= 10 && width <= 100)
                {
                    var a = double.Parse(Console.ReadLine());
                    if (a >= 2 && a <= 20)
                    {
                        var hallArea = (lenght*100)*(width*100);
                        var wardrobe = (a*100) * (a*100);
                        var bench = hallArea / 10;
                        var freeArea = hallArea - wardrobe - bench;
                        var dancers = freeArea / 7040; 
                        Console.WriteLine("Танцьорите са: " + Math.Truncate(dancers));
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
