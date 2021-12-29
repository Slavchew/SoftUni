using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarateStrings
{
    class KarateStrings
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder result = new StringBuilder(input);
            var indexOfHit = 0;
            var nextPower = 0;
            for (int i = 0; i < result.Length; i++)
            {
                indexOfHit = result.ToString().IndexOf('>', indexOfHit);
                var indexOfPower = indexOfHit + 1;
                int power = (int)result[indexOfPower] - 48 + nextPower;
                int indexOfNextHit = result.ToString().IndexOf('>', indexOfHit + 1);

                if (indexOfNextHit == -1)
                    indexOfNextHit = result.Length;

                if (indexOfHit == -1) break;

                var hitLen = indexOfNextHit - indexOfHit - 1;
                if (power > hitLen)
                {
                    result = result.Remove(indexOfPower, hitLen);
                    nextPower = power - hitLen;
                }
                else
                    result = result.Remove(indexOfPower, power);

                indexOfHit++;
            }
            Console.WriteLine(result);
        }
    }
}
