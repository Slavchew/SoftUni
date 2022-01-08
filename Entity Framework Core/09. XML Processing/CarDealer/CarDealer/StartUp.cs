using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using CarDealer.XMLHelper;

namespace CarDealer
{
    public class StartUp
    {
        static IMapper mapper;

        public static void Main(string[] args)
        {
            CarDealerContext db = new CarDealerContext();

            /* Import
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            string suppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            string partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            string carsXml = File.ReadAllText("../../../Datasets/cars.xml");
            string customersXml = File.ReadAllText("../../../Datasets/customers.xml");
            string salesXml = File.ReadAllText("../../../Datasets/sales.xml");

            Console.WriteLine(ImportSuppliers(db, suppliersXml));
            Console.WriteLine(ImportParts(db, partsXml));
            Console.WriteLine(ImportCars(db, carsXml));
            Console.WriteLine(ImportCustomers(db, customersXml));
            Console.WriteLine(ImportSales(db, salesXml));
            */

            //var cars = GetCarsWithDistance(db);
            //File.WriteAllText("../../../results/cars.xml", cars);

            //var cars = GetCarsFromMakeBmw(db);
            //File.WriteAllText("../../../results/bmw-cars.xml", cars);

            //var suppliers = GetLocalSuppliers(db);
            //File.WriteAllText("../../../results/local-suppliers.xml", suppliers);

            //var carsWithTheirParts = GetCarsWithTheirListOfParts(db);
            //File.WriteAllText("../../../results/cars-and-parts.xml", carsWithTheirParts);

            var customers = GetTotalSalesByCustomer(db);
            File.WriteAllText("../../../results/customers-total-sales.xml", customers);

            //var sales = GetSalesWithAppliedDiscount(db);
            //File.WriteAllText("../../../results/sales-discounts.xml", sales);

        }

        private static void InitliazeMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });
            mapper = config.CreateMapper();
        }

        // Problem 9
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            InitliazeMapper();

            const string rootElement = "Suppliers";

            var supplierDTOs = XMLConverter.Deserializer<ImportSupplierDto>(inputXml, rootElement);

            var suppliers = mapper.Map<IEnumerable<Supplier>>(supplierDTOs);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}";
        }

        // Problem 10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            InitliazeMapper();

            const string rootElement = "Parts";

            var partDTOs = XMLConverter.Deserializer<ImportPartDto>(inputXml, rootElement)
                .Where(x => context.Suppliers.Any(s => s.Id == x.SupplierId));

            var parts = mapper.Map<IEnumerable<Part>>(partDTOs);

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}";
        }

        // Problem 11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            const string rootElement = "Cars";

            var carDTOs = XMLConverter.Deserializer<ImportCarDto>(inputXml, rootElement);

            List<Car> cars = new List<Car>();

            foreach (var carDTO in carDTOs)
            {
                var uniqueParts = carDTO.Parts.Select(x => x.Id).Distinct().ToArray();
                var realParts = uniqueParts.Where(id => context.Parts.Any(p => p.Id == id));

                var car = new Car
                {
                    Make = carDTO.Make,
                    Model = carDTO.Model,
                    TravelledDistance = carDTO.TravelledDistance,
                    PartCars = realParts.Select(id => new PartCar
                    {
                        PartId = id
                    })
                    .ToArray()
                };

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}";
        }

        // Problem 12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            InitliazeMapper();

            const string rootElement = "Customers";

            var customerDTOs = XMLConverter.Deserializer<ImportCustomerDto>(inputXml, rootElement);

            var customers = mapper.Map<IEnumerable<Customer>>(customerDTOs);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}";
        }

        // Problem 13
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            InitliazeMapper();

            const string rootElement = "Sales";

            var saleDTOs = XMLConverter.Deserializer<ImportSaleDto>(inputXml, rootElement)
                .Where(x => context.Cars.Any(y => y.Id == x.CarId));

            var sales = mapper.Map<IEnumerable<Sale>>(saleDTOs);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}";
        }

        // Problem 14
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            const string rootElement = "cars";

            var cars = context.Cars
                .Where(x => x.TravelledDistance > 2000000)
                .Select(x => new ExportCarDto
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ToList();

            string xml = XMLConverter.Serialize(cars, rootElement);

            return xml;
        }

        // Problem 15
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            const string rootElement = "cars";

            var cars = context.Cars
                .Where(x => x.Make == "BMW")
                .Select(x => new ExportCarWithIdDto
                {
                    Id = x.Id,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToList();

            string xml = XMLConverter.Serialize(cars, rootElement);

            return xml;
        }

        // Problem 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            const string rootElement = "suppliers";


            var suppliers = context.Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new ExportSupplierDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count
                })
                .ToList();

            string xml = XMLConverter.Serialize(suppliers, rootElement);

            return xml;

        }

        // Problem 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            const string rootElement = "cars";

            var cars = context.Cars
                .Select(x => new ExportCarsWithPartsDto
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                    Parts = x.PartCars.Select(p => new ExportCarPartsDto
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price
                    })
                    .OrderByDescending(p => p.Price)
                    .ToList()
                })
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .ToList();

            string xml = XMLConverter.Serialize(cars, rootElement);

            return xml;
        }

        // Problem 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            const string rootElement = "customers";

            var customers = context.Customers
                .Where(x => x.Sales.Any(s => s.Car != null))
                .Select(x => new ExportCustomerDto
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count(),
                    SpentMoney = x.Sales
                                .SelectMany(s => s.Car.PartCars)
                                .Sum(p => p.Part.Price)
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToList();

            string xml = XMLConverter.Serialize(customers, rootElement);

            return xml;
        }

        // Problem 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            const string rootElement = "sales";

            var sales = context.Sales
                .Select(x => new ExportSaleDto
                {
                    Car = new ExportSaleCarDto
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance,
                    },
                    Discount = x.Discount,
                    CustomerName = x.Customer.Name,
                    Price = x.Car.PartCars.Sum(p => p.Part.Price),
                    PriceWithDiscount = x.Car.PartCars.Sum(p => p.Part.Price)
                    - x.Car.PartCars.Sum(p => p.Part.Price) * x.Discount / 100
                })
                .ToList();

            string xml = XMLConverter.Serialize(sales, rootElement);

            return xml;
        }
    }
}