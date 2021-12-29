using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_on_Segment
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = int.Parse(Console.ReadLine());
            var second = int.Parse(Console.ReadLine());
            var point = int.Parse(Console.ReadLine());

            var left = Math.Min(first, second);
            var right = Math.Max(first, second);

            var pointOnSegment =
                (point >= left) && (point <= right);

            var leftDistances = Math.Abs(point - left);
            var rightDistances = Math.Abs(point - right);

            var dis = Math.Min(leftDistances, rightDistances);

            if (pointOnSegment)
            {
                Console.WriteLine("in");
                Console.WriteLine(dis);
            }
            else
            {
                Console.WriteLine("out");
                Console.WriteLine(dis);
            }
        }
    }
}
