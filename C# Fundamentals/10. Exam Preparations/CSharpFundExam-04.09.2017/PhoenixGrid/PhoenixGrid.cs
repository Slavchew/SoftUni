using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoenixGrid
{
    class PhoenixGrid
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            while (input != "ReadMe")
            {
                bool result = true;
                for (int i = 3; i <= input.Length - 1; i += 4)
                    if (input[i] != '.')
                        result = false;

                if (input.Contains(' ') || input.Contains('_') || input.Contains('\t'))
                    result = false;

                var reversed = new string(input.ToCharArray().Reverse().ToArray());
                if (reversed != input)
                    result = false;


                if (result)
                    Console.WriteLine("YES");
                else
                    Console.WriteLine("NO");
                input = Console.ReadLine();
            }
        }
    }
}
