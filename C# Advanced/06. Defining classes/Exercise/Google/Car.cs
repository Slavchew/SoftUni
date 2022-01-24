using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    public class Car
    {
        public Car(string carModel, int carSpeed)
        {
            CarModel = carModel;
            CarSpeed = carSpeed;
        }

        public string CarModel { get; set; }
        public int CarSpeed { get; set; }

        public override string ToString()
        {
            return $"{CarModel} {CarSpeed}";
        }
    }
}
