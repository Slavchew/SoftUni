using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeManipulation
{
    class SafeManipulation
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(' ');

            while (true)
            {
                string[] command = Console.ReadLine().Split(' ');
                if (command[0] == "END")
                {
                    break;
                }
                else
                {
                    str = ArrayActions(str, command);
                }
            }
            Console.WriteLine(string.Join(", ",str));
        }

        private static string[] ArrayActions(string[] str, string[] command)
        {
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
                if (int.Parse(command[1]) >= 0 && int.Parse(command[1]) <= str.Length - 1)
                {
                    str[int.Parse(command[1])] = command[2];
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }

            return str;
        }
    }
}
