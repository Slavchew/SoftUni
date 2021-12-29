using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Contracts
{
    public interface ITechnologyAbstractFactory
    {
        IMobilePhone CreatePhome();

        ITablet CreateTablet();
    }
}
