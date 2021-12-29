using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyProfit
{
    class DailyProfit
    {
        static void Main(string[] args)
        {
            var daysWorkMonth = int.Parse(Console.ReadLine());
            if (daysWorkMonth >= 5 && daysWorkMonth <= 30)
            {
                var moneyForDay = double.Parse(Console.ReadLine());
                if (moneyForDay >= 10 && moneyForDay <= 2000)
                {
                    var dollarExchangeRate = double.Parse(Console.ReadLine());
                    if (dollarExchangeRate >= 0.99 && dollarExchangeRate <= 1.99)
                    {
                        var monthMoney = daysWorkMonth * moneyForDay;
                        var yearMoney = (monthMoney * 12) + (monthMoney * 2.5);
                        var tax = 0.25 * yearMoney;
                        var yearRealMoney = yearMoney - tax;
                        var averageMoneyForDayUSD = yearRealMoney / 365;
                        var averageMoneyForDayBGN = averageMoneyForDayUSD * dollarExchangeRate;
                        Console.WriteLine("{0:f2}",averageMoneyForDayBGN);
                    }
                    else
                    {
                        Console.WriteLine("Имате грешка в началните данни");
                    }
                }
                else
                {
                    Console.WriteLine("Имате грешка в началните данни");
                }
            }
            else
            {
                Console.WriteLine("Имате грешка в началните данни");
            }
        }
    }
}
