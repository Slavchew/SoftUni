using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InchesToCm
{
    class InchesToCm
    {
        static void Main(string[] args)
        {
            Console.Write("Инчове = ");
            var inch = double.Parse(Console.ReadLine());
            var cm = inch * 2.54;
            Console.WriteLine("Са {0} сантиметра", cm);
        }
    }
}
