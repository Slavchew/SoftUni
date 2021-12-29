using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speed_​​Conversion
{
    class Speed_​​Conversion
    {
        static void Main(string[] args)
        {
            var distance = float.Parse(Console.ReadLine());
            var hours = float.Parse(Console.ReadLine());
            var minutes = float.Parse(Console.ReadLine());
            var seconds = float.Parse(Console.ReadLine());

            float timeInSec = (hours * 3600) + (minutes * 60) + seconds;

            float mps = distance / timeInSec;
            float kph = (distance / 1000.0f) / (timeInSec / 3600.0f);
            float mph = kph / 1.609f;

            Console.WriteLine(mps);
            Console.WriteLine(kph);
            Console.WriteLine(mph);
        }
    }
}
