using System;
using System.Collections.Generic;

namespace BarcodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = int.Parse(Console.ReadLine());
            var end = int.Parse(Console.ReadLine());

            var startOnes = start % 10;
            var endOnes = end % 10;

            var startTens = (start / 10) % 10;
            var endTens = (end / 10) % 10;

            var startHundreds = (start / 100) % 10;
            var endHundreds = (end / 100) % 10;

            var startThousends = start / 1000;
            var endThousends = end / 1000;



            for (int i = startThousends; i <= endThousends; i++)
            {
                for (int j = startHundreds; j <= endHundreds; j++)
                {
                    for (int k = startTens; k <= endTens; k++)
                    {
                        for (int l = startOnes; l <= endOnes; l++)
                        {
                            if (i % 2 != 0 && j % 2 != 0 && k % 2 != 0 && l % 2 != 0)
                            {
                                Console.Write($"{i}{j}{k}{l} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
