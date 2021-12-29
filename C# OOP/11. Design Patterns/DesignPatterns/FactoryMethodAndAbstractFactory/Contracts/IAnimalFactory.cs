namespace FactoryMethodAndAbstractFactory.Contracts
{
    public interface IAnimalFactory
    {
        public ICarnivore GetCarnivore();

        public IVegan GetVegan();

        public IInsectivorous GetInsectivorous();
    }
}
