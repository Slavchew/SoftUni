using System;

namespace Transport
{
    public class Freight
    {
        private string name;
        private double weight;

        public Freight(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Weight cannot be negative");
                }
                this.weight = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
