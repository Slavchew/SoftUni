using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendMeEmail
{
    class SendMeEmail
    {
        static void Main(string[] args)
        {
            string girlEmail = Console.ReadLine();

            string[] sides = girlEmail.Split('@').ToArray();
            string leftSide = sides[0];
            string rightSide = sides[1];

            int leftSideSum = 0, rightSideSum = 0;
            foreach (var item in leftSide) leftSideSum += (int)item;
            foreach (var item in rightSide) rightSideSum += (int)item;

            int result = leftSideSum - rightSideSum;
            if (result >= 0)
            {
                Console.WriteLine("Call her!");
            }
            else
            {
                Console.WriteLine("She is not the one.");
            }

        }
    }
}