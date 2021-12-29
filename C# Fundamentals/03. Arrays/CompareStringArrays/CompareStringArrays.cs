using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareStringArrays
{
    class CompareStringArrays
    {
        static void Main(string[] args)
        {
            char[] sequence1 = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            char[] sequence2 = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            bool equal = false;

            int longer = Math.Max(sequence1.Length, sequence2.Length);

            for (int i = 0; i < longer; i++)
            {
                try
                {
                    if (i == sequence1.Length || sequence1[i] < sequence2[i])
                    {
                        Console.WriteLine(String.Join("", sequence1));
                        Console.WriteLine(String.Join("", sequence2));
                        equal = true;
                        break;
                    }
                }
                catch (Exception) { }

                try
                {
                    if (i == sequence2.Length || sequence2[i] < sequence1[i])
                    {
                        Console.WriteLine(String.Join("", sequence2));
                        Console.WriteLine(String.Join("", sequence1));
                        equal = true;
                        break;
                    }
                }
                catch (Exception) { }

                if (sequence1[i] == sequence2[i]) continue;
            }
            if (!equal)
            {
                Console.WriteLine(string.Join("", sequence1));
                Console.WriteLine(string.Join("", sequence2));
            }
        }
    }
}
