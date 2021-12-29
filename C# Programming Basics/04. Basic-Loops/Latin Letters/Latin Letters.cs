using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Английската азбука е :");
            for (var letter = 'a'; letter <= 'z'; letter++)
            {
                Console.Write(" " + letter);
            }
            Console.WriteLine();

        }
    }
}
