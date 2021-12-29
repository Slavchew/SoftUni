using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models.Contracts
{
    public interface IDriveable
    {
        public string Drive(double amount);
    }
}
