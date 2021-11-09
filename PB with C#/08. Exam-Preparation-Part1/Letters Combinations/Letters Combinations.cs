using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letters_Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            var startLetter = char.Parse(Console.ReadLine());
            var endLetter = char.Parse(Console.ReadLine());
            var exceptLetter = char.Parse(Console.ReadLine());

            var suma = 0;

            for (char i = startLetter; i <= endLetter; i++)
            {
                for (char j = startLetter; j <= endLetter; j++)
                {
                    for (char k = startLetter; k <= endLetter; k++)
                    {
                        if (i != exceptLetter && j != exceptLetter && k != exceptLetter)
                        {
                            Console.Write($"{i}{j}{k} ");
                            suma++;
                        }
                    }
                }
            }
            Console.WriteLine(suma);
        }
    }
}
