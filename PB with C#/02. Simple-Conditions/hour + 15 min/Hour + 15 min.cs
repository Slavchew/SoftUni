using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hour___15_min
{
    class Program
    {
        static void Main(string[] args)
        {
            var hour = int.Parse(Console.ReadLine());
            var min = int.Parse(Console.ReadLine());

            min += 15;
            hour = (min / 60) + hour;
            min = min % 60;
            hour = hour % 24;

            if (min < 10)
            {
                Console.WriteLine(hour + ":0" + min);
            }
            else
            {
                Console.WriteLine(hour + ":" + min);
            }

            //int h = int.Parse(Console.ReadLine());
            //int m = int.Parse(Console.ReadLine());

            //DateTime hm = DateTime.ParseExact($"{h}:{m}", "H:m", null);

            //hm = hm.AddMinutes(15);

            //Console.WriteLine(hm.ToString("H:mm"));
        }
    }
}
