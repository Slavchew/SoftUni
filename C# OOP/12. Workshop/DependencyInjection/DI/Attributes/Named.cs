using System;
using System.Collections.Generic;
using System.Text;

namespace DI.Attributes
{
    [AttributeUsage(AttributeTargets.Parameter)]
    public class Named : Attribute
    {
        public Named(Type type)
        {
            TypeName = type;
        }

        public Type TypeName { get; set; }
    }
}
