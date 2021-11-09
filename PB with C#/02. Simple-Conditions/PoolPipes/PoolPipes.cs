using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoolPipes
{
    class PoolPipes
    {
        static void Main(string[] args)
        {
            var volume = int.Parse(Console.ReadLine());
            if (volume >= 1 && volume <= 10000)
            {
                var pipe1 = int.Parse(Console.ReadLine());
                if (pipe1 >= 1 && pipe1 <= 5000)
                {
                    var pipe2 = int.Parse(Console.ReadLine());
                    if (pipe2 >= 1 && pipe2 <= 5000)
                    {
                        var hours = double.Parse(Console.ReadLine());
                        if (hours >= 1 && hours <= 24)
                        {
                            double water = (pipe1 + pipe2) * hours;
                            if (water <= volume)
                            {
                                Console.WriteLine("The pool is {0}% full. Pipe 1: {1}%. Pipe 2: {2}%.",
                                    Math.Truncate(water / volume * 100),
                                    Math.Truncate(pipe1 * hours / water * 100),
                                    Math.Truncate(pipe2 * hours / water * 100));
                            }
                            else
                            {
                                Console.WriteLine("For {0} hours the pool overflows with {1} liters.", hours, water - volume);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Грешен вход");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Грешен вход");
                    }
                }
                else
                {
                    Console.WriteLine("Грешен вход");
                }
            }
            else
            {
                Console.WriteLine("Грешен вход");
            }
        }
    }
}
