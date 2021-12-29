using System;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            CarBuilder carBuilder = new CarBuilder();

            carBuilder.BuildEngine(car)
                .BuildSpeedBox(car)
                .BuildTyres(car);
        }
    }
}
