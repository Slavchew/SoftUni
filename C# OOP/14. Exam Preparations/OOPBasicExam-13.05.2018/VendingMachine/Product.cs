using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public class Product
    {

        private string type;
        private string name;
        private double price;
        public static int OrdersCount { get; private set; }
        public Product(string type, string name, double price)
        {
            this.Type = type;
            this.Name = name;
            this.Price = price;
        }

        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                if (!string.Equals(value.ToUpper(), value))
                {
                    throw new ArgumentException("Invalid type!");
                }
                this.type = value;
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length <= 2)
                {
                    throw new ArgumentException("Invalid name!");
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
                if (value <= 0.0)
                {
                    throw new ArgumentException("Invalid price!");
                }
                this.price = value;
            }
        }

        public static void IncreaseOrdersCount() => ++OrdersCount;

        public override string ToString()
        {
            return $"Product with type - {this.Type} and name - {this.Name}";
        }
    }
}
