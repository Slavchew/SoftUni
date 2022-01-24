using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            for (int i = 0; i < n; i++)
            {
                var currEngine = new Engine();
                string[] engineInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var engineModel = engineInfo[0];
                var enginePower = int.Parse(engineInfo[1]);

                currEngine.Model = engineModel;
                currEngine.Power = enginePower;

                if (engineInfo.Length == 3)
                {
                    string thirdParam = engineInfo[2];
                    if (Char.IsDigit(thirdParam, 0))
                    {
                        string displacement = thirdParam;
                        currEngine.Displacement = displacement;
                    }
                    else
                    {
                        string efficiency = thirdParam;
                        currEngine.Efficiency = efficiency;
                    }
                }
                else if (engineInfo.Length == 4)
                {
                    string displacement = engineInfo[2];
                    string efficiency = engineInfo[3];
                    currEngine.Displacement = displacement;
                    currEngine.Efficiency = efficiency;
                }

                engines.Add(currEngine);
            }

            var m = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < m; i++)
            {
                Car currCar = new Car();
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var carModel = carInfo[0];
                var carEngine = engines.Where(x => x.Model == carInfo[1]).FirstOrDefault();

                currCar.Model = carModel;
                currCar.Engine = carEngine;

                if (carInfo.Length == 3)
                {
                    string thirdParam = carInfo[2];
                    if (Char.IsDigit(thirdParam,0))
                    {
                        string weigth = thirdParam;
                        currCar.Weight = weigth;
                    }
                    else
                    {
                        string color = thirdParam;
                        currCar.Color = color;
                    }
                }
                else if (carInfo.Length == 4)
                {
                    string weigth = carInfo[2];
                    string color = carInfo[3];
                    currCar.Weight = weigth;
                    currCar.Color = color;
                }

                cars.Add(currCar);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
