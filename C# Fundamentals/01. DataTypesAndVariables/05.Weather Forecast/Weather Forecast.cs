using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Weather_Forecast
{
    class Weather_Forecast
    {
        static void Main(string[] args)
        {
            var num = double.Parse(Console.ReadLine());


            if (Math.Ceiling(num) > num)
            {
                Console.WriteLine("Rainy");
            }
            else if (num >= sbyte.MinValue && num <= sbyte.MaxValue)
            {
                Console.WriteLine("Sunny");
            }
            else if (num >= int.MinValue && num <= int.MaxValue)
            {
                Console.WriteLine("Cloudy");
            }
            else if (num >= long.MinValue && num <= long.MaxValue)
            {
                Console.WriteLine("Windy");
            }
        }
    }
}
