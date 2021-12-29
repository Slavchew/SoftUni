using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public class DesktopComputer : Computer
    {
        private const int desktopComputerOverallPerformance = 15;
        public DesktopComputer(int id, string manufacturer, string model, decimal price) 
            : base(id, manufacturer, model, price, desktopComputerOverallPerformance)
        {
        }
    }
}
