using DI.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DI.Module
{
    public interface IModule
    {
        public void Configure();

        public Type GetMapping(Type interfaceType, Named namedAttribute = null);

        public void CreateMapping<TInterface, TImplementation>();
    }
}
