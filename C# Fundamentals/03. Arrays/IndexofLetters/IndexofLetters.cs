using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexofLetters
{
    class IndexofLetters
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            foreach (var item in line)
            {
                Console.WriteLine("{0} -> {1}", item, (int)item - 97);
            }
        }
    }
}
