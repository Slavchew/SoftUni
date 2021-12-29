using System;
using System.Collections.Generic;

using ShopingSpree.Common;

namespace ShopingSpree.Models
{
    public class Person
    {
        private const string NotEnoughMoneyMsg = "{0} can't afford {1}";
        private const string SuccBoughtProductMsg = "{0} bought {1}";

        private string name;
        private decimal money;
        private readonly ICollection<Product> bag;

        public Person(string name, decimal money)
        {
            this.bag = new List<Product>();

            this.Name = name;
            this.Money = money;
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
                    throw new ArgumentException(GlobalConstants.NameExcMsg);
                }
                this.name = value;
            }
        }
        public decimal Money
        {
            get
            {
                return this.money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(GlobalConstants.MoneyExcMsg);
                }
                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> Bag
        {
            get
            {
                return (IReadOnlyCollection<Product>)this.bag;
            }
        }

        public string BuyProduct(Product product)
        {
            if (this.Money < product.Cost)
            {
                return String.Format(NotEnoughMoneyMsg, this.Name, product.Name);
            }

            this.Money -= product.Cost;
            this.bag.Add(product);

            return String.Format(SuccBoughtProductMsg, this.Name, product.Name);
        }

        public override string ToString()
        {
            string productsOutput = this.Bag.Count > 0 ? String.Join(", ", this.Bag) : "Nothing bought";
            return $"{this.Name} - {productsOutput}";
        }
    }
}
