using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarPark
{
    public class Car
    {
        private const double DefaultFuel = 100.00;
        private static int ordersCount = 0;

        private string manufacturer;
        private string model;
        private double loadCapacity;
        private List<Part> parts;
        private double fuel;

        public Car(string manufacturer, string model, double loadCapacity)
        {
            Manufacturer = manufacturer;
            Model = model;
            LoadCapacity = loadCapacity;
            this.parts = new List<Part>();
            this.fuel = DefaultFuel;
            ordersCount++;
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Invalid manufacturer name!");
                }
                this.manufacturer = value;
            }
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Invalid model name!");
                }
                this.model = value;
            }
        }
        public double LoadCapacity
        {
            get
            {
                return this.loadCapacity;
            }
            set
            {
                if (value < 0.0)
                {
                    throw new ArgumentException("Invalid load capacity!");
                }
                this.loadCapacity = value;
            }
        }
        public List<Part> Parts
        {
            get { return this.parts; }
            set { this.parts = value; }
        }
        public double Fuel
        {
            get { return this.fuel; }
            set { this.fuel = value; }
        }

        public static int OrdersCount
        {
            get { return ordersCount; }
        }

        public double GetCarPrice()
        {
            double price = 0.0;
            foreach (var part in parts)
            {
                price += part.Price;
            }
            return price;
        }

        public void AddPart(Part part)
        {
            this.parts.Add(part);
        }

        public void AddMultipleParts(List<Part> partsList)
        {
            this.parts.AddRange(partsList);
        }

        public void RemovePartByName(string name)
        {
            parts.Remove(this.parts.Where(x => x.Name == name).First());
        }

        public bool ContainsPart(string partName)
        {
            foreach (var part in this.parts)
            {
                if (part.Name == partName) 
                    return true;
            }
            return false;
        }

        public List<Part> GetPartsWithPriceAbove(double price)
        {
            List<Part> requestedParts = parts.Where(x => x.Price > price).ToList();
            return requestedParts;
        }

        public Part GetMostExpensivePart()
        {
            var part = this.parts.OrderByDescending(x => x.Price).First();
            return part;
        }

        public void Drive(double distance)
        {
            var fuelToDrive = this.LoadCapacity * 0.2 * distance;
            if (this.Fuel < fuelToDrive || distance < 0)
            {
                throw new ArgumentException("Drive not possible!");
            }
            this.Fuel -= fuelToDrive;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Model.ToUpper()} made by {this.Manufacturer}");
            sb.AppendLine("Available parts:");
            foreach (var part in this.parts)
            {
                sb.AppendLine(part.ToString());
            }
            sb.AppendLine($"With total price of: {GetCarPrice():f2} lv.");

            return sb.ToString().Trim();
        }
    }
}
