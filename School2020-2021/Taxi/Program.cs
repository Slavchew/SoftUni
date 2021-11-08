using System;

namespace Taxi
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            string partOfDay = Console.ReadLine();
            double kilometers = int.Parse(Console.ReadLine());

            double price = 0.0;

            switch (month)
            {
                case "Jan":
                case "Feb":
                case "March":
                case "Apr":
                    if (partOfDay == "Day")
                    {
                        price = 0.81;
                    }
                    else if (partOfDay == "Night")
                    {
                        price = 1.00;
                    }
                    break;
                case "May":
                case "June":
                case "July":
                case "Aug":
                    if (partOfDay == "Day")
                    {
                        price = 0.91;
                    }
                    else if (partOfDay == "Night")
                    {
                        price = 1.05;
                    }
                    break;
                case "Sept":
                case "Oct":
                case "Nov":
                case "Dec":
                    if (partOfDay == "Day")
                    {
                        price = 0.85;
                    }
                    else if (partOfDay == "Night")
                    {
                        price = 1.03;
                    }
                    break;
                default:
                    break;
            }

            Console.WriteLine($"Total cost: {(price * kilometers):f2}lv.");


        }
    }
}
