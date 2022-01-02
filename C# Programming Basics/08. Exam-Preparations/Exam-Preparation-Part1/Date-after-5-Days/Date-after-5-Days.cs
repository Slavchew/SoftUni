using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Date_after_5_Days
{
    class Program
    {
        static void Main(string[] args)
        {
            var day = int.Parse(Console.ReadLine());
            var month = int.Parse(Console.ReadLine());

            var daysInMonth = 31;
            if (month == 4 || month == 6 || month == 9 || month == 11)
                daysInMonth = 30;
            else if (month == 2)
                daysInMonth = 28;

            day += 5;
            if (day > daysInMonth)
            {
                day = day - daysInMonth;
                month++;
                if (month == 13)
                    month = 1;
            }
            if (month < 10)
                Console.WriteLine($"{day}.0{month}");
            else
                Console.WriteLine($"{day}.{month}");
        }
    }
}
