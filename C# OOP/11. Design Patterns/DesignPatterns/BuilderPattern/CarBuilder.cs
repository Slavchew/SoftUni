using BuilderPattern.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    class CarBuilder : ICarBuilder
    {
        public ICarBuilder BuildEngine(Car car)
        {
            car.Engine = "Best engine";
            return this;
        }

        public ICarBuilder BuildSpeedBox(Car car)
        {
            car.SpeedBox = "Best box";
            return this;
        }

        public ICarBuilder BuildTyres(Car car)
        {
            car.Tyres = "Michelin";
            return this;
        }
    }
}
