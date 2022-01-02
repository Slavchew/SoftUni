using System;

namespace OscarsWeekInCinema
{
    class Program
    {
        static void Main(string[] args)
        {
            var film = Console.ReadLine();
            var hall = Console.ReadLine();
            var tickets = int.Parse(Console.ReadLine());

            var income = 0.0m;
            if (film == "A Star Is Born")
            {
                if (hall == "normal")
                {
                    income = tickets * 7.50m;
                }
                else if (hall == "luxury")
                {
                    income = tickets * 10.50m;
                }
                else if (hall == "ultra luxury")
                {
                    income = tickets * 13.50m;
                }
            }
            else if (film == "Bohemian Rhapsody")
            {
                if (hall == "normal")
                {
                    income = tickets * 7.35m;
                }
                else if (hall == "luxury")
                {
                    income = tickets * 9.45m;
                }
                else if (hall == "ultra luxury")
                {
                    income = tickets * 12.75m;
                }
            }
            else if (film == "Green Book")
            {
                if (hall == "normal")
                {
                    income = tickets * 8.15m;
                }
                else if (hall == "luxury")
                {
                    income = tickets * 10.25m;
                }
                else if (hall == "ultra luxury")
                {
                    income = tickets * 13.25m;
                }
            }
            else if (film == "The Favourite")
            {
                if (hall == "normal")
                {
                    income = tickets * 8.75m;
                }
                else if (hall == "luxury")
                {
                    income = tickets * 11.55m;
                }
                else if (hall == "ultra luxury")
                {
                    income = tickets * 13.95m;
                }
            }

            Console.WriteLine($"{film} -> {income:f2} lv.");
        }
    }
}
