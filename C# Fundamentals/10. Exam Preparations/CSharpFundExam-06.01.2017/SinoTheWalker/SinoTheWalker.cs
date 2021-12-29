using System;
using System.Globalization;

namespace SinoTheWalker
{
    class SinoTheWalker
    {
        static void Main(string[] args)
        {
            var startTime = DateTime.ParseExact(Console.ReadLine(), "HH:mm:ss", CultureInfo.InvariantCulture);
            var steps = int.Parse(Console.ReadLine());
            var stepSeconds = int.Parse(Console.ReadLine());
            startTime = startTime.AddSeconds(steps * stepSeconds);
            Console.WriteLine("Time Arrival: {0}", startTime.ToString("HH:mm:ss"));
        }
    }
}
