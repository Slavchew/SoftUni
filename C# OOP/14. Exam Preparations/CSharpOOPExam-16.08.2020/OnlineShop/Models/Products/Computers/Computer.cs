using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public override decimal Price =>
            this.Peripherals.Sum(x => x.Price)
            + this.Components.Sum(x => x.Price)
            + base.Price;

        public override double OverallPerformance => CalculateOverallPerformance();


        public IReadOnlyCollection<IComponent> Components
            => components;

        public IReadOnlyCollection<IPeripheral> Peripherals
            => peripherals;

        public void AddComponent(IComponent component)
        {
            if (this.components.Any(x => x.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingComponent,
                    component.GetType().Name,
                    this.GetType().Name,
                    this.Id));
            }

            components.Add(component);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (!this.components.Any(x => x.GetType().Name == componentType))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingComponent,
                    componentType,
                    this.GetType().Name,
                    this.Id));
            }

            IComponent component = this.components.FirstOrDefault(x => x.GetType().Name == componentType);

            components.Remove(component);

            return component;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.peripherals.Any(x => x.GetType() == peripheral.GetType()))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingPeripheral,
                    peripheral.GetType().Name,
                    this.GetType().Name,
                    this.Id));
            }

            peripherals.Add(peripheral);
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (!this.peripherals.Any(x => x.GetType().Name == peripheralType))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingPeripheral,
                    peripheralType,
                    this.GetType().Name,
                    this.Id));
            }

            IPeripheral peripheral = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            peripherals.Remove(peripheral);

            return peripheral;
        }

        private double CalculateOverallPerformance()
        {
            if (this.Components.Count == 0)
            {
                return base.OverallPerformance;
            }

            var result = base.OverallPerformance + this.Components.Average(x => x.OverallPerformance);
            return result;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());

            sb.AppendLine(string.Format(SuccessMessages.ComputerComponentsToString,
                this.Components.Count));

            foreach (var component in components)
            {
                sb.AppendLine($"  {component}");
            }

            double averageResult = this.Peripherals.Count == 0
                ? 0
                : this.Peripherals.Average(x => x.OverallPerformance);

            sb.AppendLine(string.Format(SuccessMessages.ComputerPeripheralsToString,
                this.Peripherals.Count,
                averageResult));

            foreach (var peripheral in peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
