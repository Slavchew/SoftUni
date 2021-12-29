using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double DefaultFuelConsumption = 8.00;
        public RaceMotorcycle(int horsePower, double fuel) 
            : base(horsePower, fuel)
        {
        }
        public override double FuelConsumption
        {
            get
            {
                return DefaultFuelConsumption;
            }
        }
    }
}
