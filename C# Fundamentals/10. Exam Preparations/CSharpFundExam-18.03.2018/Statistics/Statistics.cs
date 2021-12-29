using System;

namespace Statistics
{
    class Statistics
    {
        static void Main(string[] args)
        {
            var agents = int.Parse(Console.ReadLine());
            var income = 0.0m;
            for (int i = 0; i < agents; i++)
            {
                var transactions = int.Parse(Console.ReadLine());
                for (int j = 0; j < transactions; j++)
                {
                    var area = long.Parse(Console.ReadLine());
                    var squarePrice = decimal.Parse(Console.ReadLine());

                    var sum = area * squarePrice;
                    income += sum;
                }
            }

            var averageIncome = income / agents;
            Console.WriteLine($"{averageIncome:f3}");
        }
    }
}
