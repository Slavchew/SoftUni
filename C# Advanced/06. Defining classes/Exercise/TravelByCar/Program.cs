using System;
using System.Collections.Generic;

namespace TravelByCar
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ");
                var carModel = input[0];
                var fuelAmount = int.Parse(input[1]);
                var fuelConsumption = double.Parse(input[2]);
                cars.Add(new Car(carModel, fuelAmount, fuelConsumption));
            }
            var command = Console.ReadLine().Split(" ");
            while (command[0] != "End")
            {
                var carModel = command[1];
                var km = int.Parse(command[2]);
                foreach (var car in cars)
                {
                    if (car.Model == carModel)
                    {
                        car.Drive(km);
                    }
                }

                command = Console.ReadLine().Split(" ");
            }

            foreach (var car in cars)
            {
                Console.WriteLine("{0} {1:f2} {2}", car.Model, car.Fuel, car.Kilometers);
            }
        }
    }
}
