using System;

namespace Balls
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());


            var redBalls = 0;
            var orangeBalls = 0;
            var yellowBalls = 0;
            var whiteBalls = 0;
            var otherBalls = 0;
            var blackBalls = 0;

            var totalPoints = 0.0;

            for (int i = 0; i < n; i++)
            {
                var color = Console.ReadLine();

                if (color == "red")
                {
                    totalPoints += 5;
                    redBalls++;
                }
                else if (color == "orange")
                {
                    totalPoints += 10;
                    orangeBalls++;
                }
                else if (color == "yellow")
                {
                    totalPoints += 15;
                    yellowBalls++;
                }
                else if (color == "white")
                {
                    totalPoints += 20;
                    whiteBalls++;
                }
                else if (color == "black")
                {
                    totalPoints = Math.Floor(totalPoints / 2.0);
                    blackBalls++;
                }
                else
                {
                    otherBalls++;
                }
            }

            Console.WriteLine($"Total points: {totalPoints}");
            Console.WriteLine($"Points from red balls: {redBalls}");
            Console.WriteLine($"Points from orange balls: {orangeBalls}");
            Console.WriteLine($"Points from yellow balls: {yellowBalls}");
            Console.WriteLine($"Points from white balls: {whiteBalls}");
            Console.WriteLine($"Other colors picked: {otherBalls}");
            Console.WriteLine($"Divides from black balls: {blackBalls}");
        }
    }
}
