using AutoMapper;
using PetStore.Models;
using PetStore.Models.Enumerations;
using PetStore.ServiceModels.Products.Input;
using PetStore.ServiceModels.Products.Output;
using System;

namespace PetStore.Mapping
{
    public class PetStoreProfile : Profile
    {
        public PetStoreProfile()
        {
            // Products
            this.CreateMap<AddProductInputServiceModel, Product>()
                .ForMember(x => x.ProductType, y => y.MapFrom(x => Enum.Parse(typeof(ProductType), x.ProductType)));
            this.CreateMap<Product, GetAllProductsByTypeServiceModel>();
            this.CreateMap<Product, GetAllProductsServiceModel>()
                .ForMember(x => x.ProductType, y => y.MapFrom(x => x.ProductType.ToString()));
            this.CreateMap<Product, GetAllProductsByNameServiceModel>()
                .ForMember(x => x.ProductType, y => y.MapFrom(x => x.ProductType.ToString()));
            this.CreateMap<EditProductInputServiceModel, Product>()
                .ForMember(x => x.ProductType, y => y.MapFrom(x => Enum.Parse(typeof(ProductType), x.ProductType)));
        }
    }
}
