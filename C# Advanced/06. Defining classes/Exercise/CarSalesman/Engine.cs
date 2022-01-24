using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{
    class Engine
    {
        public Engine()
        {

        }

        private string model;
        private int power;
        private string displacement = "n/a";
        private string efficiency = "n/a";

        public string Model { get => model; set => model = value; }
        public int Power { get => power; set => power = value; }
        public string Displacement { get => displacement; set => displacement = value; }
        public string Efficiency { get => efficiency; set => efficiency = value; }
    }
}
