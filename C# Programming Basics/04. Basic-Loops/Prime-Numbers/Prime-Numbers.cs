using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var prime = true;
            if (n < 2)
            {
                prime = false;
            }
            for (int i = 2; i < n - 1; i++)
            {
                if (n % i == 0)
                {
                    prime = false;
                    break;
                }
            }
            if (prime == false)
            {
                Console.WriteLine("Не е просто");
            }
            else
            {
                Console.WriteLine("Просто");
            }
        }
    }
}
