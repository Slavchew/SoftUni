using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            long sbyteSum = 0L;
            long intSum = 0L;
            if (num1 == (sbyte)num1)
            {
                sbyteSum = 4 * num1;
                intSum = 10 * num2;
                Console.WriteLine("{0}", sbyteSum + intSum);
                
            }
            else 
            {
                sbyteSum = 4L * num2;
                intSum = 10L * num1;
                Console.WriteLine("{0}", sbyteSum + intSum);
            }
            
        }
    }
}
