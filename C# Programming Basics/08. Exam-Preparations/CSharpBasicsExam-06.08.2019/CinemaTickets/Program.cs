using System;

namespace CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            var film = Console.ReadLine();

            var totalTickets = 0;

            var studentTickets = 0;
            var standartTickets = 0;
            var kidTicekts = 0;

            while (film != "Finish")
            {
                var places = int.Parse(Console.ReadLine());
                var type = Console.ReadLine();
                var takenSeats = 0;
                while (type != "End")
                {
                    if (type == "student")
                    {
                        studentTickets++;
                    }
                    else if (type == "standard")
                    {
                        standartTickets++;
                    }
                    else if (type == "kid")
                    {
                        kidTicekts++;
                    }
                    takenSeats++;
                    if (takenSeats == places)
                    {
                        break;
                    }
                    type = Console.ReadLine();
                }

                totalTickets += takenSeats;

                var procentage = (takenSeats / (double)places) * 100;
                Console.WriteLine($"{film} - {procentage:f2}% full.");

                film = Console.ReadLine();
            }

            Console.WriteLine($"Total tickets: {totalTickets}");
            var studentProcentage = (studentTickets / (double)totalTickets) * 100;
            Console.WriteLine($"{studentProcentage:f2}% student tickets.");
            var standartProcentage = (standartTickets / (double)totalTickets) * 100;
            Console.WriteLine($"{standartProcentage:f2}% standard tickets.");
            var kidProcentage = (kidTicekts / (double)totalTickets) * 100;
            Console.WriteLine($"{kidProcentage:f2}% kids tickets.");
        }
    }
}
