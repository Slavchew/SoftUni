using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            var budget = double.Parse(Console.ReadLine());
            if (budget >= 1000 && budget<=1000000)
            {
                var type = Console.ReadLine();
                var people = int.Parse(Console.ReadLine());
                var trasportPrice = 0.00;
                var ticketsSum = 0.00;
                var remainder = 0.00;
                if (people >= 1 && people<=200)
                {
                    if (people >= 1 && people <= 4)
                    {
                        trasportPrice = budget * 0.75;
                        budget = budget - trasportPrice;
                        if (type == "VIP")
                        {
                           ticketsSum = people * 499.99;
                            if (ticketsSum <= budget)
                            {
                                remainder = budget - ticketsSum;
                                Console.WriteLine($"Yes! You have {remainder:f2} leva left.");
                            }
                            else
                            {
                                remainder = ticketsSum - budget;
                                Console.WriteLine($"Not enough money! You need {remainder:f2} leva.");
                            }
                        }
                        else if (type == "Normal")
                        {
                            ticketsSum = people * 249.99;
                            if (ticketsSum <= budget)
                            {
                                remainder = budget - ticketsSum;
                                Console.WriteLine($"Yes! You have {remainder:f2} leva left.");
                            }
                            else
                            {
                                remainder = ticketsSum - budget;
                                Console.WriteLine($"Not enough money! You need {remainder:f2} leva.");
                            }
                        }                      
                    }
                    else if (people >= 5 && people <= 9)
                    {
                        trasportPrice = budget * 0.60;
                        budget = budget - trasportPrice;
                        if (type == "VIP")
                        {
                            ticketsSum = people * 499.99;
                            if (ticketsSum <= budget)
                            {
                                remainder = budget - ticketsSum;
                                Console.WriteLine($"Yes! You have {remainder:f2} leva left.");
                            }
                            else
                            {
                                remainder = ticketsSum - budget;
                                Console.WriteLine($"Not enough money! You need {remainder:f2} leva.");
                            }
                        }
                        else if (type == "Normal")
                        {
                            ticketsSum = people * 249.99;
                            if (ticketsSum <= budget)
                            {
                                remainder = budget - ticketsSum;
                                Console.WriteLine($"Yes! You have {remainder:f2} leva left.");
                            }
                            else
                            {
                                remainder = ticketsSum - budget;
                                Console.WriteLine($"Not enough money! You need {remainder:f2} leva.");
                            }
                        }
                    }
                    else if (people >= 10 && people <= 24)
                    {
                        trasportPrice = budget * 0.50;
                        budget = budget - trasportPrice;
                        if (type == "VIP")
                        {
                            ticketsSum = people * 499.99;
                            if (ticketsSum <= budget)
                            {
                                remainder = budget - ticketsSum;
                                Console.WriteLine($"Yes! You have {remainder:f2} leva left.");
                            }
                            else
                            {
                                remainder = ticketsSum - budget;
                                Console.WriteLine($"Not enough money! You need {remainder:f2} leva.");
                            }
                        }
                        else if (type == "Normal")
                        {
                            ticketsSum = people * 249.99;
                            if (ticketsSum <= budget)
                            {
                                remainder = budget - ticketsSum;
                                Console.WriteLine($"Yes! You have {remainder:f2} leva left.");
                            }
                            else
                            {
                                remainder = ticketsSum - budget;
                                Console.WriteLine($"Not enough money! You need {remainder:f2} leva.");
                            }
                        }
                    }
                    else if (people >= 25 && people <= 49)
                    {
                        trasportPrice = budget * 0.40;
                        budget = budget - trasportPrice;
                        if (type == "VIP")
                        {
                            ticketsSum = people * 499.99;
                            if (ticketsSum <= budget)
                            {
                                remainder = budget - ticketsSum;
                                Console.WriteLine($"Yes! You have {remainder:f2} leva left.");
                            }
                            else
                            {
                                remainder = ticketsSum - budget;
                                Console.WriteLine($"Not enough money! You need {remainder:f2} leva.");
                            }
                        }
                        else if (type == "Normal")
                        {
                            ticketsSum = people * 249.99;
                            if (ticketsSum <= budget)
                            {
                                remainder = budget - ticketsSum;
                                Console.WriteLine($"Yes! You have {remainder:f2} leva left.");
                            }
                            else
                            {
                                remainder = ticketsSum - budget;
                                Console.WriteLine($"Not enough money! You need {remainder:f2} leva.");
                            }
                        }
                    }
                    else
                    {
                        trasportPrice = budget * 0.25;
                        budget = budget - trasportPrice;
                        if (type == "VIP")
                        {
                            ticketsSum = people * 499.99;
                            if (ticketsSum <= budget)
                            {
                                remainder = budget - ticketsSum;
                                Console.WriteLine($"Yes! You have {remainder:f2} leva left.");
                            }
                            else
                            {
                                remainder = ticketsSum - budget;
                                Console.WriteLine($"Not enough money! You need {remainder:f2} leva.");
                            }
                        }
                        else if (type == "Normal")
                        {
                            ticketsSum = people * 249.99;
                            if (ticketsSum <= budget)
                            {
                                remainder = budget - ticketsSum;
                                Console.WriteLine($"Yes! You have {remainder:f2} leva left.");
                            }
                            else
                            {
                                remainder = ticketsSum - budget;
                                Console.WriteLine($"Not enough money! You need {remainder:f2} leva.");
                            }
                        }
                    }
                }
            }
            else
                Console.WriteLine("Грешен Вход");
        }
    }
}
