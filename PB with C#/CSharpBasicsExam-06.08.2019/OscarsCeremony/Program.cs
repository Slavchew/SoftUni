using System;

namespace OscarsCeremony
{
    class Program
    {
        static void Main(string[] args)
        {
            var hallPrice = int.Parse(Console.ReadLine());

            var statuettesPrice = hallPrice * 0.70;
            var cateringPrice = statuettesPrice * 0.85;
            var soundPrice = cateringPrice * 0.50;

            var sum = hallPrice + statuettesPrice + cateringPrice + soundPrice;

            Console.WriteLine($"{sum:f2}");
        }
    }
}
