using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCodes
{
    class GenerateCodes
    {
        static void Main(string[] args)
        {
            var pass = int.Parse(Console.ReadLine());
            var num = int.Parse(Console.ReadLine());

            bool stop = false;
            int count = 1;

            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    for (int k = 0; k <= 9; k++)
                    {
                        for (char l = 'a'; l <= 'z'; l++)
                        {
                            for (char m = 'a'; m <= 'z'; m++)
                            {
                                for (int n = 0; n <= 9; n++)
                                {
                                    if (i + j + k +(int)l + (int)m + n == pass)
                                    {
                                        if (count > num)
                                        {
                                            stop = true;
                                            break;
                                        }

                                        Console.Write($"{i}{j}{k}{l}{m}{n} ");
                                        count++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
