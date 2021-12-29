using AbstractFactory.Contracts;
using AbstractFactory.Samsung;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Factories
{
    public class SamsungFactory : ITechnologyAbstractFactory
    {
        public IMobilePhone CreatePhome()
        {
            return new SamsungPhone();
        }

        public ITablet CreateTablet()
        {
            return new SamsungTablet();
        }
    }
}
