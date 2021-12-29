using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleSums
{
    class MultipleSums
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            long[] sequence = new long[n];
            sequence[0] = 1;
            long sum = 0L;
            for (int i = 1; i < n; i++)
            {
                sum = 0;
                for (int j = i- k; j <= i - 1; j++)
                {
                    if (j >= 0)
                    {
                        sum = sum + sequence[j];
                    }
                }
                sequence[i] = sum;
            }
            Console.WriteLine(string.Join(" ", sequence));
        }
    }
}
