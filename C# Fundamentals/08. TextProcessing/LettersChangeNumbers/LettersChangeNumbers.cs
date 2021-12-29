using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LettersChangeNumbers
{
    class LettersChangeNumbers
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] {' ' , '\t'}, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (input.Count > 10)
            {
                return;
            }

            double sum = 0.0;
            var sumOfAll = 0.0;

            for (int i = 0; i < input.Count; i++)
            {

                string text = input[i];

                var firstLetter = text[0];
                var secondLetter = text[text.Length - 1];


                text = text.Remove(0,1);
                text = text.Remove(text.Length - 1 , 1);
                int num = int.Parse(text);

                if (firstLetter >= 'A' && firstLetter <= 'Z')
                {
                    sum += (double)num / ((int)firstLetter - 64);  //sum = sum + num / ((int)firstLetter - 64)
                }
                else if (firstLetter >= 'a' && firstLetter <= 'z')
                {
                    sum += (double)num * ((int)firstLetter - 96);        //sum = sum + num * ((int)firstLetter - 96)
                }

                if (secondLetter >= 'A' && secondLetter <= 'Z')
                {
                    sum -= ((int)secondLetter - 64);       //sum = sum - ((int)secondLetter - 64)
                }
                else if (secondLetter >= 'a' && secondLetter <= 'z')
                {
                    sum += ((int)secondLetter - 96);          //sum = sum + ((int)secondLetter - 96)
                }

                sumOfAll += sum;
                sum = 0;
            }
            Console.WriteLine("{0:f2}",sumOfAll);
        }
    }
}
