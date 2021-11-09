using System;

namespace AluminumJoinery
{
    class Program
    {
        static void Main(string[] args)
        {
            var joineryCount = int.Parse(Console.ReadLine());
            var joineryType = Console.ReadLine();
            var deliveryType = Console.ReadLine();


            var joineriesSum = 0.0m;
            if (joineryCount < 10)
            {
                Console.WriteLine("Invalid order");
            }
            else
            {
                if (joineryType == "90X130")
                {
                    joineriesSum = joineryCount * 110.00m;
                    if (joineryCount > 30 && joineryCount <= 60)
                    {
                        joineriesSum *= 0.95m;
                    }
                    else if (joineryCount > 60)
                    {
                        joineriesSum *= 0.92m;
                    }
                }
                else if (joineryType == "100X150")
                {
                    joineriesSum = joineryCount * 140.00m;
                    if (joineryCount > 40 && joineryCount <= 80)
                    {
                        joineriesSum *= 0.94m;
                    }
                    else if (joineryCount > 80)
                    {
                        joineriesSum *= 0.90m;
                    }
                }
                else if (joineryType == "130X180")
                {
                    joineriesSum = joineryCount * 190.00m;
                    if (joineryCount > 20 && joineryCount <= 50)
                    {
                        joineriesSum *= 0.93m;
                    }
                    else if (joineryCount > 50)
                    {
                        joineriesSum *= 0.88m;
                    }
                }
                else if (joineryType == "200X300")
                {
                    joineriesSum = joineryCount * 250.00m;
                    if (joineryCount > 25 && joineryCount <= 50)
                    {
                        joineriesSum *= 0.91m;
                    }
                    else if (joineryCount > 50)
                    {
                        joineriesSum *= 0.86m;
                    }
                }


                if (deliveryType == "With delivery")
                {
                    joineriesSum += 60.00m;
                }

                if (joineryCount > 99)
                {
                    joineriesSum *= 0.96m;
                }

                Console.WriteLine($"{joineriesSum:f2} BGN");
            }
        }
    }
}
