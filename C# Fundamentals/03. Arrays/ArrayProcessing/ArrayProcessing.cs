using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayProcessing
{
    class ArrayProcessing
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(' ');
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(string.Join(", ", ArrayActions(str, n)));
        }

        private static string[] ArrayActions(string[] str, int n)
        {
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(' ');

                if (command[0] == "Reverse")
                {
                    Array.Reverse(str);
                }

                else if (command[0] == "Distinct")
                {
                    str = str.Distinct().ToArray();
                }

                else if (command[0] == "Replace")
                {
                    str[int.Parse(command[1])] = command[2];
                }
            }

            return str;
        }
    }
}
