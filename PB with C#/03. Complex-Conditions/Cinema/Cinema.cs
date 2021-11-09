using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    class Cinema
    {
        static void Main(string[] args)
        {
            var type = Console.ReadLine();
            var row = int.Parse(Console.ReadLine());
            var col = int.Parse(Console.ReadLine());
            var seats = row * col;
            var money = 0.00;
            if (type == "Premiere")
            {
                money = seats * 12.00;
                Console.WriteLine($"{money:f2} leva");
            }
            else if (type == "Normal")
            {
                money = seats * 7.50;
                Console.WriteLine($"{money:f2} leva");
            }
            else if (type == "Discount")
            {
                money = seats * 5.00;
                Console.WriteLine($"{money:f2} leva");
            }
            else
                Console.WriteLine("Грешен Вход");
        }
    }
}
