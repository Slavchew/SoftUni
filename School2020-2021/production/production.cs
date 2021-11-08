using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace production
{
    class production
    {
        static void Main(string[] args)
        {
            var x = 130.0;
            var g = 2010;
            while (x>=10)
            {
                x *= 0.8; //x = x * 0.8
                g += 1; // g = g + 1
            }
            Console.WriteLine(g);
        }
    }
}
