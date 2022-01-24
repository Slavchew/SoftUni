using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{
    class Car
    {
        public Car()
        {

        }

        private string model;
        private Engine engine;
        private string weight = "n/a";
        private string color = "n/a";

        public string Model { get => model; set => model = value; }
        public Engine Engine { get => engine; set => engine = value; }
        public string Weight { get => weight; set => weight = value; }
        public string Color { get => color; set => color = value; }

        public override string ToString()
        {
            var text =$"{Model}:\n  {Engine.Model}:\n    Power: {Engine.Power}\n    Displacement: {Engine.Displacement}\n    Efficiency: {Engine.Efficiency}\n  Weight: {Weight}\n  Color: {Color}";
            return text;

        }

    }
}
