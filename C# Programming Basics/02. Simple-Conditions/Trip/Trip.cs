using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip
{
    class Trip
    {
        static void Main(string[] args)
        {
            var n = double.Parse(Console.ReadLine());
            if (n>= 10 && n<=5000)
            {
                var price = 0.0;
                var season = Console.ReadLine().ToLower();
                if (season == "summer" || season == "winter")
                {
                    if (n<=100 && season == "summer")
                    {
                        price = n * 0.30;
                        Console.WriteLine("Somewhere in Bulgaria");
                        Console.WriteLine($"Camp - {price:f2}");
                    }
                    else if (n <= 100 && season == "winter")
                    {
                        price = n * 0.70;
                        Console.WriteLine("Somewhere in Bulgaria");
                        Console.WriteLine($"Hotel - {price:f2}");
                    }
                    else if (n <= 1000 && season == "summer")
                    {
                        price = n * 0.40;
                        Console.WriteLine("Somewhere in Balkans");
                        Console.WriteLine($"Camp - {price:f2}");
                    }
                    else if (n <= 1000 && season == "winter")
                    {
                        price = n * 0.80;
                        Console.WriteLine("Somewhere in Balkans");
                        Console.WriteLine($"Hotel - {price:f2}");
                    }
                    else if (n > 1000 && season == "summer")
                    {
                        price = n * 0.90;
                        Console.WriteLine("Somewhere in Europe");
                        Console.WriteLine($"Hotel - {price:f2}");
                    }
                    else if (n > 1000 && season == "winter")
                    {
                        price = n * 0.90;
                        Console.WriteLine("Somewhere in Europe");
                        Console.WriteLine($"Hotel - {price:f2}");
                    }

                }
                else
                    Console.WriteLine("Грешен Вход");
            }
            else
                Console.WriteLine("Грешен Вход");
        }
    }
}
