using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Tourist_Information
{
    class Tourist_Information
    {
        static void Main(string[] args)
        {
            string startType = Console.ReadLine().ToLower();
            string convertedType = string.Empty;
            double value = double.Parse(Console.ReadLine());

            if (startType == "miles")
            {
                convertedType = "kilometers";
                double km = value * 1.6;
                Console.WriteLine($"{value} {startType} = {km:f2} {convertedType}");
            }
            else if (startType == "inches")
            {
                convertedType = "centimeters";
                double cm = value * 2.54;
                Console.WriteLine($"{value} {startType} = {cm:f2} {convertedType}");
            }
            else if (startType == "feet")
            {
                convertedType = "centimeters";
                double cm = value * 30;
                Console.WriteLine($"{value} {startType} = {cm:f2} {convertedType}");
            }
            else if (startType == "yards")
            {
                convertedType = "meters";
                double m = value * 0.91;
                Console.WriteLine($"{value} {startType} = {m:f2} {convertedType}");
            }
            else if (startType == "gallons")
            {
                convertedType = "liters";
                double liters = value * 3.8;
                Console.WriteLine($"{value} {startType} = {liters:f2} {convertedType}");
            }
        }
    }
}
