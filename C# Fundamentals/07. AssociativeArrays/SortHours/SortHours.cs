using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortHours
{
    class SortHours
    {
        static void Main(string[] args)
        {
            var hours = Console.ReadLine().Split(' ').ToArray();
            var result = hours.OrderBy(h => h);
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
