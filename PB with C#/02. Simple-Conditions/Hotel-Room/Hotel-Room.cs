using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            var month = Console.ReadLine();
            var nights = int.Parse(Console.ReadLine());
            if (nights >=0 && nights <=200)
            {
                var studioPriceForNight = 0.0;
                var hotelPriceForNight = 0.0;
                if (month == "May" || month == "October")
                {
                    studioPriceForNight = 50.0;
                    hotelPriceForNight = 65.0;
                    if (nights > 7 && nights < 14)
                    {
                        studioPriceForNight = studioPriceForNight * 0.95;
                    }
                    else if (nights > 14)
                    {
                        studioPriceForNight = studioPriceForNight * 0.70;
                        hotelPriceForNight = hotelPriceForNight * 0.90;
                    }
                    Console.WriteLine($"Apartment: {(hotelPriceForNight * nights):f2} lv.");
                    Console.WriteLine($"Studio: {(studioPriceForNight * nights):f2} lv.");
                }
                else if (month == "June" || month == "September")
                {
                    studioPriceForNight = 75.20;
                    hotelPriceForNight = 68.70;
                    if (nights > 14)
                    {
                        studioPriceForNight = studioPriceForNight * 0.80;
                        hotelPriceForNight = hotelPriceForNight * 0.90;
                    }
                    Console.WriteLine($"Apartment: {(hotelPriceForNight * nights):f2} lv.");
                    Console.WriteLine($"Studio: {(studioPriceForNight * nights):f2} lv.");
                }
                else if (month == "July" || month == "August")
                {
                    studioPriceForNight = 76.00;
                    hotelPriceForNight = 77.00;
                    if (nights > 14)
                    {
                        hotelPriceForNight = hotelPriceForNight * 0.90;
                    }
                    Console.WriteLine($"Apartment: {(hotelPriceForNight * nights):f2} lv.");
                    Console.WriteLine($"Studio: {(studioPriceForNight * nights):f2} lv.");
                }
            }
            else
                Console.WriteLine("Грешен Вход");
        }
    }
}
