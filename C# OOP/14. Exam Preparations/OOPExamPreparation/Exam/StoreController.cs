using System.Collections.Generic;
using System.Linq;
using System.Text;

public class StoreController
{
    private List<Store> stores;

    public StoreController()
    {
        this.stores = new List<Store>();
    }

    public string CreateStore(List<string> args)
    {
        string name = args[0];
        string type = args[1];

        Store store = new Store(name, type);

        if (this.stores.Any(x => x.Name == name))
        {
            return $"Store {name} is already registered!";
        }

        this.stores.Add(store);

        return $"Store {name} was successfully registerd in the system!";
    }

    public string ReceiveProduct(List<string> args)
    {
        string type = args[0];
        string name = args[1];
        int quantity = int.Parse(args[2]);
        double price = double.Parse(args[3]);
        double percentageMarkup = double.Parse(args[4]);
        string storeName = args[5];

        if (!this.stores.Any(x => x.Name == storeName))
        {
            return $"Invalid Store: {storeName}. Cannot find it in system!";
        }

        Product product = null;
        if (type == "Food")
        {
            product = new Food(name, quantity, price, percentageMarkup);
        }
        else if (type == "Drink")
        {
            product = new Drink(name, quantity, price, percentageMarkup);
        }
        else
        {
            return $"Product {type} is invalid!";
        }

        bool isAdded = this.stores.FirstOrDefault(x => x.Name == storeName)
            .ReceiveProduct(product);

        if (!isAdded)
        {
            return $"Product {name} was already delivered to {storeName}!";
        }

        return $"Product {name} was successfully delivered to {storeName}!";
    }

    public string SellProduct(List<string> args)
    {
        string name = args[0];
        int quantity = int.Parse(args[1]);
        string storeName = args[2];

        if (!this.stores.Any(x => x.Name == storeName))
        {
            return $"Invalid Store: {storeName}. Cannot find it in system!";
        }

        bool isSold = this.stores.FirstOrDefault(x => x.Name == storeName)
            .SellProduct(name, quantity);

        if (!isSold)
        {
            return $"Product {name} was already sold out!";
        }

        return $"Product {name} was successfully bought from {storeName}!";
    }

    public string StoreInfo(List<string> args)
    {
        string storeName = args[0];

        if (!this.stores.Any(x => x.Name == storeName))
        {
            return $"Invalid Store: {storeName}. Cannot find it in system!";
        }

        Store store = this.stores.FirstOrDefault(x => x.Name == storeName);

        return store.ToString();
    }

    public string Shutdown()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Stores: {this.stores.Count}");
        foreach (var store in this.stores.OrderByDescending(x => x.Revenue).ThenBy(x => x.Name))
        {
            sb.AppendLine(store.ToString());
        }
        sb.AppendLine($"System Store Revenues: {this.stores.Sum(x => x.Revenue):f2}BGN");

        return sb.ToString().TrimEnd();
    }
}