using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class House
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var stars = 1;
            if (n % 2 == 0)
            {
                stars = 2;
            }
            for (int row = 0; row < (n+1) / 2; row++)
            {
                var dashs = (n - stars) / 2;
                Console.Write(new string('-', dashs));
                Console.Write(new string('*',stars));
                Console.Write(new string('-', dashs));
                Console.WriteLine();
                stars += 2;
            }
            for (int i = 0; i < n/2; i++)
            {
                Console.Write("|");
                Console.Write(new string('*',n-2));
                Console.WriteLine("|");
            }
        }
    }
}
