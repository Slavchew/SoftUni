using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractMiddleElements
{
    class ExtractMiddleElements
    {
        static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var n = sequence.Length;
            if (n == 1)
            {
                Console.WriteLine("{ " + $"{sequence[0]}" + " }");
            }
            else if (n % 2 == 0)
            {
                int[] resultSeq = new int[2];
                var index = n / 2 - 1;
                for (int i = 0; i < 2; i++)
                {
                    resultSeq[i] = sequence[index];
                    index++;
                }
                Console.WriteLine("{ " + string.Join(", ", resultSeq) + " }");
            }
            else if (n % 2 == 1)
            {
                int[] resultSeq = new int[3];
                var index = n / 2 - 1;
                for (int i = 0; i < 3; i++)
                {
                    resultSeq[i] = sequence[index];
                    index++;
                }
                Console.WriteLine("{ " + string.Join(", ",resultSeq) + " }");
            }

        }
    }
}
