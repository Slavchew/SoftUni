using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine
{
    public class VendingMachine
    {
        private const double DefaultBattery = 100d;

        private string id;
        private List<Product> products = new List<Product>();
        private double totalSalesAmount = 0;
        public double Battery { get; private set; } = DefaultBattery;

        public VendingMachine(string id) : this(id, new List<Product>())
        {
        }
        public VendingMachine(string id, List<Product> products)
        {
            this.products = products;
            Id = id;
        }

        public string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (value.Length <= 3 || !string.Equals(value.ToLower(), value))
                {
                    throw new ArgumentException("Invalid machine id!");
                }
                this.id = value;
            }
        }
        public List<Product> Products
        {
            get { return products; }
            set { products = value; }
        }
        public double TotalSalesAmount
        {
            get
            {
                return this.totalSalesAmount;
            }
            set
            {
                this.totalSalesAmount = value;
            }
        }

        public override string ToString()
        {
            /*
            Machine: <ID> has the following available products:
            Product with type - <ProductType> and name - <ProductName>
            Product with type - <ProductType> and name - <ProductName>
            …/всички налични продукти, в реда, в който са постъпили в машината/
            ---- With total sales amount: <TotalSalesAmount>.
            */

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Machine: {this.Id} has the following available products:");
            foreach (var product in products)
            {
                sb.AppendLine(product.ToString());
            }
            sb.AppendLine($"---- With total sales amount: {totalSalesAmount:f2}.");

            return sb.ToString().Trim();
        }

        public void Recharge()
        {
            this.Battery = DefaultBattery;
        }

        public void ClearSales()
        {
            this.totalSalesAmount = 0;
        }

        public void AddProduct(Product product)
        {
            this.products.Add(product);
        }

        public int CheckProductQuantityOfGivenType(string type)
        {
            var quantity = this.products.Where(x => x.Type == type).Count();
            return quantity;
        }

        public void RemoveProduct(string name)
        {
            products.Remove(this.products.Where(x => x.Name == name).FirstOrDefault());
        }

        public Product GetMostExpensiveProduct()
        {
            var product = this.products.OrderByDescending(x => x.Price).FirstOrDefault();
            return product;
        }

        public string SellProduct(string name)
        {
            Product.IncreaseOrdersCount();
            var product = this.products.Where(x => x.Name == name).FirstOrDefault();
            var batteryNeeded = product.Price * 0.8 + 2d;
            if (Battery < batteryNeeded)
            {
                throw new ArgumentException("Out of battery!");
            }
            this.Battery -= batteryNeeded;
            TotalSalesAmount += product.Price;
            this.products.Remove(product);

            return $"{product.Name} for {product.Price:f2}lv.";
        }

        public void RemoveAllProductsOfGivenType(string type)
        {
            var productRange = this.products.Where(x => x.Type == type).ToList();
            foreach (var product in productRange)
            {
                this.products.Remove(product);
            }
        }

        public string GetInfoAboutAllProductsByType()
        {
            Dictionary<string, int> counts = new Dictionary<string, int>();
            foreach (var types in products.Select(x => x.Type).Distinct())
            {
                counts.Add(types, products.Where(y => y.Type == types).ToList().Count);
            }
            foreach (var key in counts.OrderBy(x => x.Value))
            {
                Console.WriteLine($"Type: {key.Key} has total of - {key.Value} products.");
            }
            return "";
        }
    }
}
