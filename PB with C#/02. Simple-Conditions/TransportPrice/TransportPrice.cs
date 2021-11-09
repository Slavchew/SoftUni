using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportPrice
{
    class TransportPrice
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Колко километра ще пътувате");
            var distance = int.Parse(Console.ReadLine());
            if (distance >= 1 && distance <= 5000)
            {
                //Console.WriteLine("Кога ще пътувате през деня или през ноща");
                var dayOrNight = Console.ReadLine().ToLower();
                var price = 0.0;
                var taxiRate = 0.0;
                if (dayOrNight == "day")
                {
                    taxiRate = 0.79;
                }
                else if (dayOrNight == "night")
                {
                    taxiRate = 0.90;
                }
                if (distance < 20)
                {
                    price = 0.7 + taxiRate * distance;
                }
                else if (distance >= 20 && distance < 100) 
                {
                    price = 0.09 * distance;
                }
                else if (distance >= 100)
                {
                    price = 0.06 * distance;
                }

                Console.WriteLine($"{price:f2}");
            }
            else
            {
                Console.WriteLine("Грешен вход");
            } 
        }
    }
}
