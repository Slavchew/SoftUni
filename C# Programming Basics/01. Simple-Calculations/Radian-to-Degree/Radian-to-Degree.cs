using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radian_to_Degree
{
    class Program
    {
        static void Main(string[] args)
        {
            var Radian = double.Parse(Console.ReadLine());
            var Degree = (Radian * 180) / Math.PI;
            Console.WriteLine(Math.Round(Degree,0) + "°");
        }
    }
}
