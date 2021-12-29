using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaceses
{
    public interface IEngineer
    {
        ICollection<IRepair> Repairs { get; }
    }
}
