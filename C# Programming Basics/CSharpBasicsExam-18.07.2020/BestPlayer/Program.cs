using System;

namespace BestPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var bestPlayerName = String.Empty;
            var bestPlayerGoals = 0;
            while (input != "END")
            {
                var playerGoals = int.Parse(Console.ReadLine());
                if (bestPlayerGoals < playerGoals)
                {
                    bestPlayerGoals = playerGoals;
                    bestPlayerName = input;
                }

                if (playerGoals >= 10)
                {
                    break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{bestPlayerName} is the best player!");
            if (bestPlayerGoals >= 3)
            {
                Console.WriteLine($"He has scored {bestPlayerGoals} goals and made a hat-trick !!!");
            }
            else
            {
                Console.WriteLine($"He has scored {bestPlayerGoals} goals.");
            }
        }
    }
}
