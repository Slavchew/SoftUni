using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO.Export;
using CarDealer.DTO.Import;
using CarDealer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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

            var suppliersJson = File.ReadAllText("../../../Datasets/suppliers.json");
            var partsJson = File.ReadAllText("../../../Datasets/parts.json");
            var carsJson = File.ReadAllText("../../../Datasets/cars.json");
            var customersJson = File.ReadAllText("../../../Datasets/customers.json");
            var salesJson = File.ReadAllText("../../../Datasets/sales.json");

            Console.WriteLine(ImportSuppliers(db, suppliersJson));
            Console.WriteLine(ImportParts(db, partsJson));
            Console.WriteLine(ImportCars(db, carsJson));
            Console.WriteLine(ImportCustomers(db, customersJson));
            Console.WriteLine(ImportSales(db, salesJson));
            */

            // Export

            Console.WriteLine(GetSalesWithAppliedDiscount(db));
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
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            InitliazeMapper();

            var supplierDTOs = JsonConvert
                .DeserializeObject<IEnumerable<SupplierInputModel>>(inputJson);

            var suppliers = mapper.Map<IEnumerable<Supplier>>(supplierDTOs);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }

        // Problem 10
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            InitliazeMapper();

            var partsDTOs = JsonConvert
                .DeserializeObject<IEnumerable<PartInputModel>>(inputJson)
                .Where(x => context.Suppliers.Any(y => y.Id == x.SupplierId));

            var parts = mapper.Map<IEnumerable<Part>>(partsDTOs);

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }

        // Problem 11
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            InitliazeMapper();

            var carsDTOs = JsonConvert
                .DeserializeObject<IEnumerable<CarInputModel>>(inputJson);

            foreach (var carDto in carsDTOs)
            {
                var car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                context.Cars.Add(car);

                foreach (var partId in carDto.PartsId)
                {
                    var partCar = new PartCar
                    {
                        CarId = car.Id,
                        PartId = partId
                    };

                    if (car.PartCars.FirstOrDefault(pc => pc.PartId == partId) == null)
                    {
                        context.PartCars.Add(partCar);
                    }
                }
            }

            context.SaveChanges();

            return $"Successfully imported {carsDTOs.Count()}.";
        }

        // Problem 12
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            InitliazeMapper();

            var customersDTOs = JsonConvert
                .DeserializeObject<IEnumerable<CustomerInputModel>>(inputJson);

            var customers = mapper.Map<IEnumerable<Customer>>(customersDTOs);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }

        // Problem 13
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            InitliazeMapper();

            var salesDTOs = JsonConvert
                .DeserializeObject<IEnumerable<SaleInputModel>>(inputJson);

            var sales = mapper.Map<IEnumerable<Sale>>(salesDTOs);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }

        // Problem 14
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(x => new
                {
                    x.Name,
                    BirthDate = x.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    x.IsYoungDriver
                }).ToList();

            string json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }

        // Problem 15
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make == "Toyota")
                .Select(x => new
                {
                    x.Id,
                    x.Make,
                    x.Model,
                    x.TravelledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToList();

            string json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }

        // Problem 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    PartsCount = x.Parts.Count
                }).ToList();

            string json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return json;
        }

        // Problem 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new CarPartsDto
                {
                    Car = new ExportCarDto
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance,
                    },
                    Parts = c.PartCars
                            .Select(p => new ExportPartDto
                            {
                                Name = p.Part.Name,
                                Price = $"{p.Part.Price:F2}"
                            }).ToList()

                }).ToList();

            string json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }

        // Problem 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(x => x.Sales.Any(s => s.Car != null))
                .Select(x => new
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count(c => c.Car != null),
                    SpentMoney = x.Sales
                                .SelectMany(s => s.Car.PartCars)
                                .Sum(p => p.Part.Price)
                })
                .OrderByDescending(x => x.SpentMoney)
                .ThenByDescending(x => x.BoughtCars)
                .ToList();

            var setting = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented,
            };

            string json = JsonConvert.SerializeObject(customers, setting);

            return json;
        }

        // Problem 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(x => new ExportSaleDiscountDto
                {
                    Car = new ExportCarDto
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance,
                    },
                    CustomerName = x.Customer.Name,
                    Discount = $"{x.Discount:f2}",
                    Price = $"{x.Car.PartCars.Sum(p => p.Part.Price):F2}",
                    PriceWithDiscount = (x.Car.PartCars.Sum(p => p.Part.Price)
                    - x.Car.PartCars.Sum(p => p.Part.Price) * x.Discount / 100).ToString("F2")

                }).Take(10).ToList();

            var json = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return json;
        }
    }
}