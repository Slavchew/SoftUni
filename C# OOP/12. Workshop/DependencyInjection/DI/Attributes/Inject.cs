using System;
using System.Collections.Generic;
using System.Text;

namespace DI.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor,AllowMultiple = false)]
    public class Inject : Attribute
    {
    }
}
