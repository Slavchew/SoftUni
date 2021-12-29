using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachine
{
    public class StartUp
    {
        private static Dictionary<string, Product> products = new Dictionary<string, Product>();
        private static Dictionary<string, VendingMachine> machines = new Dictionary<string, VendingMachine>();

        public static void Main(string[] args)
        {
            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split(' ').ToArray();

                switch (commandArgs[0])
                {
                    case "CreateProduct": // OK
                        CreateProduct(commandArgs.Skip(1).ToArray());
                        break;
                    case "CreateVendingMachine": // OK
                        CreateVendingMachine(commandArgs.Skip(1).ToArray());
                        break;
                    case "RechargeMachine": // OK
                        RechargeMachine(commandArgs.Skip(1).ToArray());
                        break;
                    case "ClearMachineSales": // OK
                        ClearMachineSales(commandArgs.Skip(1).ToArray());
                        break;
                    case "AddProductToMachine": // OK
                        AddProductToMachine(commandArgs.Skip(1).ToArray());
                        break;
                    case "CheckProductQuantity": //OK
                        CheckProductQuantity(commandArgs.Skip(1).ToArray());
                        break;
                    case "RemoveProduct": // OK
                        RemoveProductByName(commandArgs.Skip(1).ToArray());
                        break;
                    case "GetMostExpensiveProduct": // OK 
                        GetMostExpensiveProduct(commandArgs.Skip(1).ToArray());
                        break;
                    case "SellProduct": // OK
                        SellProduct(commandArgs.Skip(1).ToArray());
                        break;
                    case "PrintMachineInfo": // OK
                        PrintMachineInfo(commandArgs.Skip(1).ToArray());
                        break;
                    case "PrintProductInfo": // OK
                        PrintProductInfo(commandArgs.Skip(1).ToArray());
                        break;
                    case "GetBatteryLevelOfMachine": // OK
                        GetBatteryLevelOfMachine(commandArgs.Skip(1).ToArray());
                        break;
                    case "GetMachineTotalSalesAmount": // OK
                        GetMachineTotalSalesAmount(commandArgs.Skip(1).ToArray());
                        break;
                    case "GetTotalProductSales": // OK
                        GetTotalProductSales(commandArgs.Skip(1).ToArray());
                        break;
                    case "RemoveAllProductsOfGivenType": // OK
                        RemoveAllProductsOfGivenType(commandArgs.Skip(1).ToArray());
                        break;
                    case "PrintInfoAboutAllProductsByType": // OK
                        PrintInfoAboutAllProductsByType(commandArgs.Skip(1).ToArray());
                        break;
                }
            }
        }

        private static void CreateProduct(string[] args)
        {
            try
            {
                Product product = new Product(args[0], args[1], double.Parse(args[2]));
                products.Add(product.Name, product);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void CreateVendingMachine(string[] args)
        {
            VendingMachine vendingMachine = null;
            if (args.Length == 1)
            {
                try
                {
                    vendingMachine = new VendingMachine(args[0]);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                List<Product> currentProducts = new List<Product>();
                foreach (var p in args.Skip(1))
                {
                    currentProducts.Add(products[p]);
                }
                try
                {
                    vendingMachine = new VendingMachine(args[0], currentProducts);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            if (vendingMachine != null)
            {
                machines.Add(vendingMachine.Id, vendingMachine);
            }
        }

        private static void RechargeMachine(string[] args)
        {
            machines[args[0]].Recharge();
        }

        private static void ClearMachineSales(string[] args)
        {
            machines[args[0]].ClearSales();
        }

        private static void AddProductToMachine(string[] args)
        {
            machines[args[0]].AddProduct(products[args[1]]);
        }

        private static void CheckProductQuantity(string[] args)
        {
            Console.WriteLine(machines[args[0]].CheckProductQuantityOfGivenType(args[1]));
        }

        private static void RemoveProductByName(string[] args)
        {
            machines[args[0]].RemoveProduct(args[1]);
        }

        private static void GetMostExpensiveProduct(string[] args)
        {
            Product product = machines[args[0]].GetMostExpensiveProduct();
            Console.WriteLine($"Machine's with ID = {machines[args[0]].Id} most expensive product is: {product}");
        }

        private static void SellProduct(string[] args)
        {
            try
            {
                Console.WriteLine($"Machine's with ID = {machines[args[0]].Id} sold {machines[args[0]].SellProduct(args[1])}");

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void PrintMachineInfo(string[] args)
        {
            Console.WriteLine(machines[args[0]]);
        }

        private static void PrintProductInfo(string[] args)
        {
            Console.WriteLine(products[args[0]]);
        }

        private static void GetBatteryLevelOfMachine(string[] args)
        {
            Console.WriteLine($"Machine's with ID = {machines[args[0]].Id} has battery level = {machines[args[0]].Battery:F2}");
        }

        private static void GetMachineTotalSalesAmount(string[] args)
        {
            Console.WriteLine($"{machines[args[0]].TotalSalesAmount:F2}");
        }

        private static void GetTotalProductSales(string[] args)
        {
            Console.WriteLine(Product.OrdersCount);
        }

        //Bonus
        private static void RemoveAllProductsOfGivenType(string[] args)
        {
            machines[args[0]].RemoveAllProductsOfGivenType(args[1]);
        }

        // Bonus
        private static void PrintInfoAboutAllProductsByType(string[] args)
        {
            Console.Write(machines[args[0]].GetInfoAboutAllProductsByType());
        }
    }
}
