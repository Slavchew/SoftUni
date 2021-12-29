using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_to_100_with_text
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type Number betwen 1 and 1000");
            var n = int.Parse(Console.ReadLine());
            var strOnes = "";
            var strTens = "";
            var strHundreds = "";
            if (n >= 0 && n <= 999)
            {
                if (n >= 0 && n <= 19)
                {
                    if (n == 0)
                    {
                        Console.WriteLine("zero");
                    }
                    else if (n == 1)
                    {
                        Console.WriteLine("one");
                    }
                    else if (n == 2)
                    {
                        Console.WriteLine("two");
                    }
                    else if (n == 3)
                    {
                        Console.WriteLine("three");
                    }
                    else if (n == 4)
                    {
                        Console.WriteLine("four");
                    }
                    else if (n == 5)
                    {
                        Console.WriteLine("five");
                    }
                    else if (n == 6)
                    {
                        Console.WriteLine("six");
                    }
                    else if (n == 7)
                    {
                        Console.WriteLine("seven");
                    }
                    else if (n == 8)
                    {
                        Console.WriteLine("eight");
                    }
                    else if (n == 9)
                    {
                        Console.WriteLine("nine");
                    }
                    else if (n == 10)
                    {
                        Console.WriteLine("ten");
                    }
                    else if (n == 11)
                    {
                        Console.WriteLine("eleven");
                    }
                    else if (n == 12)
                    {
                        Console.WriteLine("twelve");
                    }
                    else if (n == 13)
                    {
                        Console.WriteLine("thirteen");
                    }
                    else if (n == 14)
                    {
                        Console.WriteLine("fourteen");
                    }
                    else if (n == 15)
                    {
                        Console.WriteLine("fifteen");
                    }
                    else if (n == 16)
                    {
                        Console.WriteLine("sixteen");
                    }
                    else if (n == 17)
                    {
                        Console.WriteLine("seventeen");
                    }
                    else if (n == 18)
                    {
                        Console.WriteLine("eighteen");
                    }
                    else if (n == 19)
                    {
                        Console.WriteLine("nineteen");
                    }
                }
                if (n >= 20 && n <= 999)
                {
                    var ones = n % 10;
                    if (ones == 1)
                    {
                        strOnes = " one";
                    }
                    else if (ones == 2)
                    {
                        strOnes = " two";
                    }
                    else if (ones == 3)
                    {
                        strOnes = " three";
                    }
                    else if (ones == 4)
                    {
                        strOnes = " four";
                    }
                    else if (ones == 5)
                    {
                        strOnes = " five";
                    }
                    else if (ones == 6)
                    {
                        strOnes = " six";
                    }
                    else if (ones == 7)
                    {
                        strOnes = " seven";
                    }
                    else if (ones == 8)
                    {
                        strOnes = " eight";
                    }
                    else if (ones == 9)
                    {
                        strOnes = " nine";
                    }
                    else if (ones == 0)
                    {
                        strOnes = "";
                    }

                    var tens = (n / 10) % 10;
                    if (tens == 2)
                    {
                        strTens = "twenty";
                    }
                    else if (tens == 3)
                    {
                        strTens = "thirty";
                    }
                    else if (tens == 4)
                    {
                        strTens = "forty";
                    }
                    else if (tens == 5)
                    {
                        strTens = "fifty";
                    }
                    else if (tens == 6)
                    {
                        strTens = "sixty";
                    }
                    else if (tens == 7)
                    {
                        strTens = "seventy";
                    }
                    else if (tens == 8)
                    {
                        strTens = "eighty";
                    }
                    else if (tens == 9)
                    {
                        strTens = "ninety";
                    }
                    else
                    {
                        strTens = "";
                    }

                    var hundreds = n / 100;
                    if (hundreds == 1)
                    {
                        strHundreds = "one hundred ";
                    }
                    else if (hundreds == 2)
                    {
                        strHundreds = "two hundred ";
                    }
                    else if (hundreds == 3)
                    {
                        strHundreds = "three hundred ";
                    }
                    else if (hundreds == 4)
                    {
                        strHundreds = "four hundred ";
                    }
                    else if (hundreds == 5)
                    {
                        strHundreds = "five hundred ";
                    }
                    else if (hundreds == 6)
                    {
                        strHundreds = "six hundred ";
                    }
                    else if (hundreds == 7)
                    {
                        strHundreds = "seven hundred ";
                    }
                    else if (hundreds == 8)
                    {
                        strHundreds = "eight hundred ";
                    }
                    else if (hundreds == 9)
                    {
                        strHundreds = "nine hundred ";
                    }

                    Console.WriteLine(strHundreds + strTens + strOnes);
                }
            }
            else if (n == 1000)
            {
                Console.WriteLine("one thousand");
            }
            else
            {
                Console.WriteLine("invalid number");
            }
        }
    }
}
