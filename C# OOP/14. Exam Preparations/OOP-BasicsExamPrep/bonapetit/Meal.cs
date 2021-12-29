using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bonapetit
{
    public class Meal
    {
        private string name;
        private string type;
        private List<Product> products = new List<Product>();
        private int ordered = 0;

        public Meal(string name, string type)
            : this(name, type, new List<Product>()) { }

        public Meal(string name, string type, List<Product> products)
        {
            this.Name = name;
            this.Type = type;
            this.Products = products;
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
                    throw new ArgumentException("Meal name cannot be less then 3 symbols");
                }
                this.name = value;
            }
        }
        public string Type
        {
            get
            {
                return this.type;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Meal type cannot be empty");
                }
                this.type = value;
            }
        }
        public List<Product> Products
        {
            get
            {
                return this.products;
            }
            private set
            {
                this.products = value;
            }
        }
        public int Ordered
        {
            get { return this.ordered; }
        }

        public double Price
        {
            get { return this.products.Sum(p => p.Price) * 1.3; }
        }

        public void AddProduct(Product p)
        {
            products.Add(p);
        }

        public bool ContainsProduct(string name)
        {
            return products.Exists(p => p.Name == name);
        }

        public void PrintRecipe()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(new string('-', 25));
            sb.AppendLine($"{this.name} RECIPE");
            sb.AppendLine(new string('-', 25));
            foreach (var product in this.products)
            {
                sb.AppendLine(product.ToString());
            }
            sb.AppendLine(new string('-', 25));

            Console.WriteLine(sb.ToString().Trim());
        }

        public void Order()
        {
            this.ordered++;
        }

        public static Meal GetSpecialty(Dictionary<string, Meal> meals)
        {
            return meals.Values.OrderByDescending(m => m.ordered).First();
        }

        public static Meal RecommendByPrice(double price, Dictionary<string, Meal> meals)
        {
            return meals.Values.Where(m => m.Price <= price).OrderByDescending(p => p.Price).First();
        }

        public static Meal RecommendByPriceAndType(double price, string type, Dictionary<string, Meal> meals)
        {
            return meals.Values.Where(m => m.Price <= price).OrderByDescending(p => p.Price).ThenBy(t => t.Type == type).First();
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Type}";
        }

    }
}
