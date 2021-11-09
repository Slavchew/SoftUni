using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAds
{
    class OnlineAds
    {
        // 03. Онлайн обяви
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var gasolineCars = 0;
            var dieselCars = 0;

            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                string carType = Console.ReadLine().ToLower();
                string fuelType = Console.ReadLine().ToLower();
                string adType = Console.ReadLine().ToLower();
                decimal carPrice = decimal.Parse(Console.ReadLine());
                int carKms = int.Parse(Console.ReadLine());

                string category = "";
                if (carType == "coupe" && fuelType == "gasoline")
                {
                    if (carPrice > 100000)
                    {
                        category = "supersport";
                    }
                    else
                    {
                        category = "sport";
                    }
                }
                if (carType == "coupe" && fuelType == "diesel")
                {
                    category = "ecosport";
                }
                if (carType == "sedan" && fuelType == "gasoline")
                {
                    if (carPrice > 80000)
                    {
                        category = "limousine";
                    }
                    else
                    {
                        category = "executive";
                    }
                }
                if (carType == "sedan" && fuelType == "diesel")
                {
                    category = "economic";
                }

                if (fuelType == "gasoline")
                {
                    gasolineCars++;
                }
                else if (fuelType == "diesel")
                {
                    dieselCars++;
                }

                if (adType == "vip")
                {
                    carPrice += 200;
                }

                Console.WriteLine($"Car model - {model}");
                Console.WriteLine($"Category - {category}");
                Console.WriteLine($"Type - {carType}");
                Console.WriteLine($"Fuel - {fuelType}");
                Console.WriteLine($"Kilometers - {carKms}");
                Console.WriteLine($"Price - {carPrice:f2}");
            }


            Console.WriteLine("Gasoline cars: {0:f2}%",gasolineCars * 100.00 / n);
            Console.WriteLine("Diesel cars: {0:f2}%", dieselCars * 100.00 / n);
        }
    }
}
