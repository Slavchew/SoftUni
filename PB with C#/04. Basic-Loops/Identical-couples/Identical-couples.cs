using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identical_couples
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            int currentSum = 0;
            var previousSum = 0;
            var difference = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    var firstNum = int.Parse(Console.ReadLine());
                    var secondNum = int.Parse(Console.ReadLine());
                    previousSum = firstNum + secondNum;
                }
                else
                {
                    var firstNum2 = int.Parse(Console.ReadLine());
                    var secondNum2 = int.Parse(Console.ReadLine());
                    currentSum = firstNum2 + secondNum2;
                    if ((Math.Abs(currentSum - previousSum)) > difference)
                    {
                        difference = Math.Abs(currentSum - previousSum);
                    }

                    previousSum = currentSum;
                }
            }
            if (difference > 0)
            {
                Console.WriteLine("No, maxdiff=" + difference);
            }
            else
            {
                Console.WriteLine("Yes, value=" + previousSum);
            }
        }
    }
}
