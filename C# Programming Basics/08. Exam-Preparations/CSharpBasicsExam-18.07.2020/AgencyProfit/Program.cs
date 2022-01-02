using System;

namespace AgencyProfit
{
    class Program
    {
        static void Main(string[] args)
        {
            var airlineName = Console.ReadLine();
            var adultTickets = int.Parse(Console.ReadLine());
            var childTickets = int.Parse(Console.ReadLine());
            var adultTicketPrice = decimal.Parse(Console.ReadLine());
            var childTicketPrice = adultTicketPrice * 0.30m;
            var tax = decimal.Parse(Console.ReadLine());

            adultTicketPrice += tax;
            childTicketPrice += tax;

            var allTicketSum = (adultTicketPrice * adultTickets) + (childTicketPrice * childTickets);
            var income = allTicketSum * 0.20m;


            Console.WriteLine($"The profit of your agency from {airlineName} tickets is {income:f2} lv.");
        }
    }
}
