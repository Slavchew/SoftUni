using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonusPoints
{
    class BonusPoints
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            var bonus = 0.0;
            if (num <= 100) // <= 100
            {
                bonus += 5;
            }
            else if(num <=1000) // [101 ..... 1000]
            {
                bonus = bonus + 0.2 * num;
            }
            else // > 1000
            {
                bonus = bonus + 0.1 * num;
            }
            if(num % 2 == 0)
            {
                bonus += 1;
            }
            else if(num % 10 == 5)
            {
                bonus += 2;
            }
            Console.WriteLine("Бонус точки:"+bonus);
            Console.WriteLine("Общо брой точки:" + (num + bonus));
        }
    }
}
