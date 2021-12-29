using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_of_two_digit_numbers_in_a_number_system
{
/* Задача.4.	
   Колко са двуцифрените числа в p-ична бройна система. 
   Едноцифрените да не се броят като двуцифрени с първа цифра 0!
*/
    class Number_of_two_digit_numbers_in_a_number_system
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var nums = n * n - (n + 1);

            Console.WriteLine($"COUNT = {nums}");
        }
    }
}
