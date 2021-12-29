using FizzBuzz.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FizzBuzz
{
    public class FizzBuzz
    {
        private IWriter writer;
        public FizzBuzz(IWriter writer)
        {
            this.writer = writer;
        }

        public void PrintNumbers(int start, int end)
        {
            if (start < 0)
            {
                start = 1;
            }
            for (int i = start; i <= end; i++)
            {
                if (i % 5 == 0 && i % 3 == 0)
                {
                    writer.WriteLine("fizzbuzz");
                }
                else if (i % 3 == 0)
                {
                    writer.WriteLine("fizz");
                }
                else if (i % 5 == 0)
                {
                    writer.WriteLine("buzz");
                }
                else
                {
                    writer.WriteLine(i.ToString());
                }
            }
        }
    }
}
