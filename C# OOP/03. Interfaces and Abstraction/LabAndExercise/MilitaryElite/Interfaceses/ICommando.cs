using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaceses
{
    public interface ICommando
    {
        ICollection<IMission> Missions { get; }
    }
}
