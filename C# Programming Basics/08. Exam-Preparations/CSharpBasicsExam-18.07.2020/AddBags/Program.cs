using System;

namespace AddBags
{
    class Program
    {
        static void Main(string[] args)
        {
            var cargoPrice = decimal.Parse(Console.ReadLine());
            var cargoKg = double.Parse(Console.ReadLine());
            var daysToTrip = int.Parse(Console.ReadLine());
            var cargoCounts = int.Parse(Console.ReadLine());

            if (cargoKg > 0 && cargoKg < 10)
            {
                cargoPrice *= 0.20m;
            }
            else if (cargoKg >= 10 && cargoKg <= 20)
            {
                cargoPrice *= 0.50m;
            }

            if (daysToTrip > 0 && daysToTrip < 7)
            {
                cargoPrice *= 1.40m;
            }
            else if (daysToTrip >= 7 && daysToTrip <= 30)
            {
                cargoPrice *= 1.15m;
            }
            else if (daysToTrip > 30)
            {
                cargoPrice *= 1.10m;
            }

            var sum = cargoPrice * cargoCounts;

            Console.WriteLine($"The total price of bags is: {sum:f2} lv.");
        }
    }
}
