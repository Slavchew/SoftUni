using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bonapetit
{
    public class Product
    {
        private string name;
        private double price;
        private int weight;
        public Product(string name, double price, int weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Product name cannot be less then 3 symbols");
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
            private set
            {
                if (value < 0.01)
                {
                    throw new ArgumentException("Product price cannot be less then 0.01 leva");
                }
                this.price = value;
            }
        }

        public int Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Product weight cannot be zero or negative number");
                }
                this.weight = value;
            }
        }

        public static Product GetCheapestProduct(Dictionary<string, Product> products)
        {
            return products.Values.OrderBy(p => p.Price).FirstOrDefault();
        }


        public override string ToString()
        {
            return $"{this.Name} - {this.Weight}";
        }
    }
}
