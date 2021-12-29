using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Store
{
    private string name;
    private string type;

    private List<Product> products;

    public Store(string name, string type)
    {
        this.products = new List<Product>();

        this.Name = name;
        this.Type = type;
    }

    public string Name
    {
        get { return this.name; }
        private set 
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Store name must not be null or empty!");
            }

            this.name = value; 
        }
    }

    public string Type
    {
        get { return this.type; }
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Store type must not be null or empty!");
            }
            this.type = value;
        }
    }

    public double Revenue { get; set; }

    public bool ReceiveProduct(Product product)
    {
        var productName = product.Name;
        if (this.products.Any(x => x.Name == productName))
        {
            return false;
        }

        this.products.Add(product);

        return true;
    }

    public bool SellProduct(string name, int quantity)
    {
        var product = this.products.FirstOrDefault(x => x.Name == name);

        if (product != null)
        {
            if (product.Quantity >= quantity)
            {
                product.Quantity -= quantity;

                if (product.Quantity == 0)
                {
                    this.products.Remove(product);
                }

                this.Revenue += quantity * product.FinalPrice;

                return true;
            }

            return false;
        }

        return false;
    }

    public Product GetProduct(string name)
    {
        var product = this.products.FirstOrDefault(x => x.Name == name);

        // return product;

        if (product != null)
        {
            return product;
        }

        return null;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"****Store: {this.Name} <{this.Type}>");
        sb.AppendLine($"****Available products: <{this.products.Count}>");

        foreach (var product in this.products)
        {
            sb.AppendLine($"****** {product.Name} ({product.Quantity})");
        }

        sb.AppendLine($"****Revenue: <{this.Revenue:f2}BGN>");

        return sb.ToString().TrimEnd();
    }
}
