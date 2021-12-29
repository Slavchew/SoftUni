using AbstractFactory.Apple;
using AbstractFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Factories
{
    public class AppleFactory : ITechnologyAbstractFactory
    {
        public IMobilePhone CreatePhome()
        {
            return new ApplePhone();
        }

        public ITablet CreateTablet()
        {
            return new AppleTablet();
        }
    }
}
