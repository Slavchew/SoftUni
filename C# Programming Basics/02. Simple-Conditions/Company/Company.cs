using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    class Company
    {
        static void Main(string[] args)
        {
            var hours = int.Parse(Console.ReadLine());
            if (hours >= 10 && hours <= 200000)
            {
                var days = int.Parse(Console.ReadLine());
                if (days >= 0 && days <= 20000)
                {
                    var workers = int.Parse(Console.ReadLine());
                    if (workers >= 0 && workers <= 200)
                    {
                        var workDays = days * 0.9;
                        var workHours = workDays * 8;
                        var bonusWork = workDays * workers * 2;
                        var totalHours = Math.Floor(bonusWork + workHours);
                        if (totalHours > hours)
                        {
                            Console.WriteLine("Yes!{0} hours left.", totalHours - hours);
                        }
                        else
                        {
                            Console.WriteLine("Not enough time! {0} hours needed.", hours - totalHours);
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
