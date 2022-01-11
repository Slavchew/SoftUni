namespace PetStore.ServiceModels.Products.Output
{
    public class GetAllProductsByNameServiceModel
    {
        public string Name { get; set; }

        public string ProductType { get; set; }

        public decimal Price { get; set; }
    }
}
