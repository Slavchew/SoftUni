using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat_Tom
{
    class Program
    {
        static void Main(string[] args)
        {
            var offWorkDays = int.Parse(Console.ReadLine());
            if (offWorkDays >= 0 && offWorkDays <= 365)
            {
                var workDays = 365 - offWorkDays;
                var realTimetoPlay = (workDays * 63) + (offWorkDays * 127);
                var diffFromNormal = Math.Abs(30000 - realTimetoPlay);
                var hours = diffFromNormal / 60;
                var minutes = diffFromNormal % 60;
                if (realTimetoPlay > 30000)
                {
                    Console.WriteLine("Tom will run away");
                    Console.WriteLine("{0} hours and {1} minutes more for play" , hours , minutes );
                }
                else
                {
                    Console.WriteLine("Tom sleeps well");
                    Console.WriteLine("{0} hours and {1} minutes less for play", hours, minutes);
                }
            }
            else
            {
                Console.WriteLine("Грешен вход");
            }
        }
    }
}
