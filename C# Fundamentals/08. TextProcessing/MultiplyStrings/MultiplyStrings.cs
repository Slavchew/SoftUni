using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplyStrings
{
    class MultiplyStrings
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine().Split(' ').ToArray();
            var str1 = text[0];
            var str2 = text[1];
            var str1Len = str1.Length;
            var str2Len = str2.Length;
            var longer = Math.Max(str1Len, str2Len);
            var shorter = Math.Min(str1Len, str2Len);
            var sum = 0;
            for (int i = 0; i < longer; i++)
            {
                if (shorter <= i)
                {
                    if (str1Len < str2Len)
                    {
                        sum += (int)str2[i];
                    }
                    else
                    {
                        sum += (int)str1[i];
                    }
                }
                else
                {
                    sum += (int)str1[i] * (int)str2[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
