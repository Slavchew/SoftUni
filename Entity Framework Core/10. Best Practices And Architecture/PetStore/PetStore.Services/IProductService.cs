using PetStore.ServiceModels.Products.Input;
using PetStore.ServiceModels.Products.Output;
using System.Collections.Generic;

namespace PetStore.Services
{
    public interface IProductService
    {
        void AddProduct(AddProductInputServiceModel model);

        void EditProduct(string id, EditProductInputServiceModel model);

        ICollection<GetAllProductsServiceModel> GetAllProducts(string type);

        ICollection<GetAllProductsByTypeServiceModel> GetAllProductsByType(string type);

        ICollection<GetAllProductsByNameServiceModel> GetAllProductsByName(string name, bool caseSensitive);


        bool RemoveById(string id);

        bool RemoveByName(string name);
    }
}
