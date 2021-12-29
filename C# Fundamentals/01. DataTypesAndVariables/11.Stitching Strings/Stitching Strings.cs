using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Stitching_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            char separator = char.Parse(Console.ReadLine());
            string evenOrOdd = Console.ReadLine();
            var n = int.Parse(Console.ReadLine());
            string result = string.Empty;
            for (int i = 1; i <= n; i++)
            {
                string text = Console.ReadLine();
                if (i % 2 == 0 && evenOrOdd == "even")
                {
                    result += $"{text}{separator}";
                }
                if (i % 2 == 1 && evenOrOdd == "odd")
                {
                    result += $"{text}{separator}";
                }
            }
            Console.WriteLine("{0}", result.Remove(result.Length - 1));
        }
    }
}
