using System;
using System.Collections.Generic;
using System.Text;

namespace Transport
{
    public class Truck
    {
        private string name;
        private double capacity;
        private readonly ICollection<Freight> freights;

        public Truck(string name, double capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.freights = new List<Freight>();
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
        public double Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Weight cannot be negative");
                }
                this.capacity = value;
            }
        }

        public IReadOnlyCollection<Freight> Freights
        {
            get
            {
                return (IReadOnlyCollection<Freight>)this.freights;
            }
        }
        public void AddFreight(Freight freight)
        {
            if (this.Capacity >= freight.Weight)
            {
                this.freights.Add(freight);
                this.Capacity -= freight.Weight;
                Console.WriteLine($"{this.Name} loaded {freight.Name}");
            }
            else
            {
                Console.WriteLine($"{this.Name} can not load {freight.Name}");
            }
        }

        public override string ToString()
        {
            string productsOutput = this.freights.Count > 0 ? String.Join(", ",this.Freights) : "Nothing bought";
            return $"{this.Name} - {productsOutput}";
        }
    }
}
