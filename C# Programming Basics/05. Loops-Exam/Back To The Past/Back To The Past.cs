using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_To_The_Past
{
    class Program
    {
        static void Main(string[] args)
        {
            var money = double.Parse(Console.ReadLine());
            var yearToLive = int.Parse(Console.ReadLine());

            var years = 18;

            for (int currYear = 1800; currYear <= yearToLive ; currYear++)
            {
                if (currYear % 2 == 0)
                {
                    money -= 12000;
                }
                else
                {
                    money -= (12000 + years * 50);
                }
                years++;
            }

            if (money >= 0)
            {
                Console.WriteLine("Yes! He will live a carefree life and will have {0:f2} dollars left.",money);
            }
            else
                Console.WriteLine("He will need {0:f2} dollars to survive.",Math.Abs(money));
        }
    }
}
