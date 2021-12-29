using FactoryMethodAndAbstractFactory.Contracts;
using FactoryMethodAndAbstractFactory.Models.Carnivores;

namespace FactoryMethodAndAbstractFactory.Factories
{
    public class AfricaFactory : IAnimalFactory
    {
        public ICarnivore GetCarnivore()
        {
            return new Lion();
        }


        public IVegan GetVegan()
        {
            throw new System.NotImplementedException();
        }

        public IInsectivorous GetInsectivorous()
        {
            throw new System.NotImplementedException();
        }
    }
}
