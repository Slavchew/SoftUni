using System;
using FactoryMethodAndAbstractFactory.Contracts;
using FactoryMethodAndAbstractFactory.Models.Carnivores;

namespace FactoryMethodAndAbstractFactory.Factories
{
    public class EuroFactory : IAnimalFactory
    {
        public ICarnivore GetCarnivore()
        {
            return new EnglishMan();
        }

        public IVegan GetVegan()
        {
            throw new NotImplementedException();
        }

        public IInsectivorous GetInsectivorous()
        {
            throw new NotImplementedException();
        }
    }
}
