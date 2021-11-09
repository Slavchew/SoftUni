using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball
{
    class Volleyball
    {
        static void Main(string[] args)
        {
            var year = Console.ReadLine();
            var holidays = int.Parse(Console.ReadLine());
            var homeDays = int.Parse(Console.ReadLine());
            var sofiaGames = (48 - homeDays) * 0.75;
            var sofiaHolidayGames = holidays * (2.0 / 3.0);
            var allGames = sofiaGames + homeDays + sofiaHolidayGames;
            if (year == "leap")
            {
                var moreGames = allGames * 0.15;
                var allGamesWithBonus = moreGames + allGames;
                Console.WriteLine(Math.Floor(allGamesWithBonus));
            }
            else if (year == "normal")
            {
                Console.WriteLine(Math.Floor(allGames));
            }
            else
                Console.WriteLine("Грешен вход");
        }
    }
}
