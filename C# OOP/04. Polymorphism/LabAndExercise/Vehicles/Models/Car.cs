namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double FUEL_CONSUMPTION_INCR = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, int tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + FUEL_CONSUMPTION_INCR;
    }
}
