using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine().Split().ToArray();
            while (line[0] != "Close")
            {
                try
                {
                    switch (line[0])
                    {
                        case "Add":
                            Order.Add(line[1], line[2], double.Parse(line[3]), double.Parse(line[4]));
                            break;
                        case "Sell":
                            Order.Sell(line[1], double.Parse(line[2]));
                            break;
                        case "Update":
                            Order.Update(line[1], double.Parse(line[2]));
                            break;
                        case "PrintA":
                            Order.PrintA();
                            break;
                        case "PrintU":
                            Order.PrintU();
                            break;
                        case "PrintD":
                            Order.PrintD();
                            break;
                        case "Calculate":
                            Console.WriteLine("{0:f2}", Order.Calculate());
                            break;
                    }
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }

                line = Console.ReadLine().Split().ToArray();
            }

        }
    }
}
