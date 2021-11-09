using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {

            var n = 2;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 2*n; j++)
                {
                    for (int k = 0; k < 3*n; k++)
                    {
                        for (int l = 0; l < 4*n; l++)
                        {
                            for (int m = 0; m < 5*n; m++)
                            {
                                Console.Write("*");
                            }
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
