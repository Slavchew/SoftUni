using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaceses
{
    public interface ILieutenantGeneral
    {
        ICollection<IPrivate> Privates { get; }
    }
}
