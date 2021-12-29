using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD_TO_BGN
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Въведете сума в долари");
            var usd = double.Parse(Console.ReadLine());
            var bgn = usd * 1.79549;
            Console.WriteLine("{0} лева",Math.Round(bgn,2));
        }
    }
}
