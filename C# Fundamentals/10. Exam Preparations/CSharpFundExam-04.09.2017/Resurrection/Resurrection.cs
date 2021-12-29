using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resurrection
{
    class Resurrection
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                long bodyTotalLength = long.Parse(Console.ReadLine());
                decimal bodyWidth = decimal.Parse(Console.ReadLine());
                long wingLength = long.Parse(Console.ReadLine());

                decimal totalYears = (bodyTotalLength * bodyTotalLength) * (bodyWidth + (2 * wingLength));
                Console.WriteLine(totalYears);
            }
        }
    }
}
