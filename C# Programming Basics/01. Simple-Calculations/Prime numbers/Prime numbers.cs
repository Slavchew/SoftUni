using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var n =  int.Parse(Console.ReadLine());
            var prime = true;
            for (int i = 2; i < Math.Sqrt(n); i++)
            {
                if (n % i ==0)
                {
                    prime = false;
                    break;
                }
            }
            if(prime)
            {
                Console.WriteLine("Просто");
            }
            else
            {
                Console.WriteLine("Не е просто");
            }

        }
    }
}
