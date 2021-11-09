using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarNumbers
{
    class CarNumbers
    {
        // 06. Номера
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            string lastLetters = Console.ReadLine();
            var n = int.Parse(Console.ReadLine());

            int count = 1;
            string number = "";
            bool hasToEnd = false;

            for (int j = 0; j <= 9; j++)
            {
                for (int k = 0; k <= 9; k++)
                {
                    for (int l = 0; l <= 9; l++)
                    {
                        for (int m = 0; m <= 9; m++)
                        {
                            var numbers = $"{j}{k}{l}{m}";
                            if (j + k + l + m == (j * l) - n)
                            {
                                if (count > n)
                                {
                                    hasToEnd = true;
                                    break;
                                }
                                number = $"{town}{numbers}{lastLetters}";
                                Console.Write($"{number} ");
                                count++;
                            }
                        }
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
