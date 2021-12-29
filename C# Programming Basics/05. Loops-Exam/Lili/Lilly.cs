using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lili
{
    class Program
    {
        static void Main(string[] args)
        {
            var age = int.Parse(Console.ReadLine());
            var WashPrice = double.Parse(Console.ReadLine());
            var toyPrice = int.Parse(Console.ReadLine());

            var evenBday = 0;
            var oddBday = 0;
            var sum = 0.0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    evenBday++;
                    sum = sum + (evenBday * 10);
                }
                else
                {
                    oddBday++;
                }
            }

            sum -= evenBday;

            var toys = oddBday;
            var priceFromToys = toys * toyPrice;
            sum = sum + priceFromToys;
            if (sum >= WashPrice)
            {
                var remainder = sum - WashPrice;
                Console.WriteLine("Yes! {0:f2}", remainder);
            }
            else
            {
                var lack = WashPrice - sum;
                Console.WriteLine("No! {0:f2}", lack);
            }

        }
    }
}
