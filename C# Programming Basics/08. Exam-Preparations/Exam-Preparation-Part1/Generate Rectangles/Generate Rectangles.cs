using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generate_Rectangles
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var minArea = int.Parse(Console.ReadLine());

            var printNo = true;
            for (var left = -n; left <= n; left++)
            {
                for (var top = -n; top <= n; top++)
                {
                    for (var right = left + 1; right <= n; right++)
                    {
                        for (var bottom = top + 1; bottom <= n; bottom++)
                        {
                            var width = right - left;
                            var height = bottom - top;
                            var area = width * height;
                            if (area >= minArea)
                            {
                                Console.WriteLine($"({left}, {top}) ({right}, {bottom}) -> {area}");
                                printNo = false;
                            }
                        }
                    }
                }
            }
            if (printNo)
            {
                Console.WriteLine("No");
            }
        }
    }
}
