using System;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using CsvHelper;
using System.Text;

namespace CSVDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // From CSV to List
            using CsvReader reader = new CsvReader(new StreamReader("Cars.csv"), CultureInfo.InvariantCulture);
            List<Car> cars = reader.GetRecords<Car>().ToList();

            // from List to CSV
            var carsList = new List<Car>
            {
                new Car { Year = 2006, Model = "320", Make = "BMW", Description = "Biva kolata", Price = 8500M },
                new Car { Year = 2020, Model = "Model X", Make = "Tesla", Description = "AI Car", Price = 500000M },
                new Car { Year = 2004, Model = "Golf 3", Make = "VW", Description = "Best car", Price = 100000M }
            };

            using CsvWriter writer = new CsvWriter(new StreamWriter("MyCars.csv"), CultureInfo.InvariantCulture);
            writer.WriteRecords(carsList);
        }
    }

    class Car
    {
        public int Year { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
