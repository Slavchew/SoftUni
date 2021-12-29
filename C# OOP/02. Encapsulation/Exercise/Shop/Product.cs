using System;
using System.Collections.Generic;
using System.Text;

namespace Shop
{
    class Product
    {
        private string name;
        private string barcode;
        private double price;

        public Product(string name, string barcode, double price)
        {
            this.Name = name;
            this.Barcode = barcode;
            this.Price = price;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name must be not empty.");
                }
                this.name = value;
            }
        }

        public string Barcode
        {
            get
            {
                return this.barcode;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Barcode must not be empty.");
                }
                this.barcode = value;
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
                if (value < 0)
                {
                    throw new ArgumentException("Price must be positive.");
                }
                this.price = value;
            }
        }
    }
}
