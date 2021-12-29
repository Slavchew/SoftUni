using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ").ToArray();
                var model = new Model(input[0], int.Parse(input[1]), int.Parse(input[2]));
                var cargo = new Cargo(int.Parse(input[3]), input[4]);
                Tires[] tires = new Tires[4];
                tires[0] = new Tires(double.Parse(input[5]), int.Parse(input[6]));
                tires[1] = new Tires(double.Parse(input[7]), int.Parse(input[8]));
                tires[2] = new Tires(double.Parse(input[9]), int.Parse(input[10]));
                tires[3] = new Tires(double.Parse(input[11]), int.Parse(input[12]));
                cars.Add(new Car(model, cargo, tires));
            }

            var type = Console.ReadLine();
            foreach (var car in cars)
            {
                bool isCarTiresBellow1Pressure = car.CarTyres[0].Pressure < 1 ||
                                                 car.CarTyres[1].Pressure < 1 ||
                                                 car.CarTyres[2].Pressure < 1 ||
                                                 car.CarTyres[3].Pressure < 1;
                if (car.Cargo.Type == type && isCarTiresBellow1Pressure)
                {
                    Console.WriteLine(car.CarModel.CarModel);
                }
                else if (car.Cargo.Type == type && car.CarModel.EnginePower > 250)
                {
                    Console.WriteLine(car.CarModel.CarModel);
                }
            }
        }
    }
}
