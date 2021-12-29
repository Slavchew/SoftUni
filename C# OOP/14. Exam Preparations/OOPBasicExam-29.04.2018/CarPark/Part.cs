using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark
{
    public class Part
    {
        private string name;
        private double price;

        public Part(string name)
        {
            this.Name = name;
            this.Price = 25.00;
        }

        public Part(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length < 5)
                {
                    throw new ArgumentException("Invalid part name!");
                }
                this.name = value;
            }
        }
        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0.0)
                {
                    throw new ArgumentException("Price should be positive!");
                }
                this.price = value;
            }
        }


        public override string ToString()
        {
            return $"-> {this.Name} - {this.Price:f2}";
        }
    }
}
