using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const int cubicCantimeters = 3000;
        private const int minHorsePower = 250;
        private const int maxHorsePower = 450;

        public SportsCar(string model, int horsePower)
            : base(model, horsePower, cubicCantimeters, minHorsePower, maxHorsePower)
        {
        }
    }
}
