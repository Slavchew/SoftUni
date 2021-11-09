using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount
{
    class Discount
    {
        // 02. Отстъпка
        static void Main(string[] args)
        {
            string model = Console.ReadLine();
            int vinNumber = int.Parse(Console.ReadLine());
            string condition = Console.ReadLine().ToLower();
            decimal carPrice = decimal.Parse(Console.ReadLine());


            var notValidVinNumber = vinNumber > 90000 || vinNumber % 2 == 1;

            bool badCondition = condition == "bad";

            var profit = carPrice * 0.15m;

            if (!notValidVinNumber && !badCondition && profit > 400)
            {
                Console.WriteLine($"yes - {model}");
                Console.WriteLine($"profit - {profit:f2}");
            }
            else if (notValidVinNumber || badCondition || profit <= 400)
            {
                Console.WriteLine("no");
                if (badCondition)
                {
                    Console.WriteLine("The car is in bad condition");
                }
                if (notValidVinNumber)
                {
                    Console.WriteLine($"VIN {vinNumber} is not valid");
                }
                if (profit <= 400)
                {
                    Console.WriteLine($"Cannot make discount, profit too low - {profit:f2}");
                }
            }
        }

    }
}
