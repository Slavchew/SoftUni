using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly List<IComputer> computers;
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            IComputer computer = null;
            if (computerType == "Laptop")
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else if (computerType == "DesktopComputer")
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            this.computers.Add(computer);

            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            DoesComputerExist(computerId);

            if (this.components.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            IComponent component = null;
            if (componentType == "CentralProcessingUnit")
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "Motherboard")
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "PowerSupply")
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "RandomAccessMemory")
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "SolidStateDrive")
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "VideoCard")
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            this.components.Add(component);

            this.computers.FirstOrDefault(x => x.Id == computerId)
                .AddComponent(component);

            return string.Format(SuccessMessages.AddedComponent,
                componentType,
                id,
                computerId);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            DoesComputerExist(computerId);
            if (this.peripherals.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            IPeripheral peripheral = null;

            if (peripheralType == "Headset")
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Keyboard")
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Monitor")
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Mouse")
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            this.peripherals.Add(peripheral);

            this.computers.FirstOrDefault(x => x.Id == computerId)
                .AddPeripheral(peripheral);

            return string.Format(SuccessMessages.AddedPeripheral,
                peripheralType,
                id,
                computerId);

        }

        public string BuyBest(decimal budget)
        {
            IComputer computer = computers
                .Where(x => x.Price <= budget)
                .OrderByDescending(x => x.OverallPerformance)
                .FirstOrDefault();

            if (computer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer,
                    budget));
            }

            this.computers.Remove(computer);

            return computer.ToString().TrimEnd();

        }

        public string BuyComputer(int id)
        {
            DoesComputerExist(id);

            IComputer computer = computers.FirstOrDefault(x => x.Id == id);
            computers.Remove(computer);

            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            DoesComputerExist(id);

            IComputer computer = computers.FirstOrDefault(x => x.Id == id);

            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            DoesComputerExist(computerId);

            IComponent component = this.computers.FirstOrDefault(x => x.Id == computerId)
                .RemoveComponent(componentType);

            this.components.Remove(component);

            return string.Format(SuccessMessages.RemovedComponent,
                    componentType,
                    component.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            DoesComputerExist(computerId);

            IPeripheral peripheral = this.computers.FirstOrDefault(x => x.Id == computerId)
                .RemovePeripheral(peripheralType);

            this.peripherals.Remove(peripheral);

            return string.Format(SuccessMessages.RemovedPeripheral,
                    peripheralType,
                    peripheral.Id);
        }

        private void DoesComputerExist(int id)
        {
            if (!this.computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }
    }
}
