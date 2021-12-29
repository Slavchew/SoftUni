using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfNames_II
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(new[] { ',',' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            for (int i = 0; i < names.Count; i+= 2)
            {
                Console.WriteLine($"{names[i + 1]} {names[i]}");
            }
        }
    }
}
