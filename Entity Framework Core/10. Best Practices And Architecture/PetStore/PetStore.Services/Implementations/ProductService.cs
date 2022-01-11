using System;
using System.Linq;
using System.Collections.Generic;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using PetStore.Common;
using PetStore.Data;
using PetStore.Models;
using PetStore.Models.Enumerations;
using PetStore.ServiceModels.Products.Input;
using PetStore.ServiceModels.Products.Output;

namespace PetStore.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly PetStoreDbContext dbContext;
        private readonly IMapper mapper;

        public ProductService(PetStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void AddProduct(AddProductInputServiceModel model)
        {
            try
            {
                Product product = this.mapper.Map<Product>(model);

                this.dbContext.Products.Add(product);
                this.dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new ArgumentException(ExceptionMessages.InvalidProductType);
            }
        }

        public void EditProduct(string id, EditProductInputServiceModel model)
        {
            try
            {
                Product product = this.mapper.Map<Product>(model);

                Product productToUpdate = this.dbContext.Products
                    .Where(x => x.Id == id)
                    .FirstOrDefault();

                if (productToUpdate == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidProductId);
                }

                productToUpdate.Name = product.Name;
                productToUpdate.ProductType = product.ProductType;
                productToUpdate.Price = product.Price;

                dbContext.SaveChanges();
            }
            catch (ArgumentException ae)
            {
                throw ae;
            }
            catch (Exception)
            {
                throw new ArgumentException(ExceptionMessages.InvalidProductType);
            }
        }

        public ICollection<GetAllProductsServiceModel> GetAllProducts(string type)
        {
            var products = this.dbContext.Products
                .ProjectTo<GetAllProductsServiceModel>(this.mapper.ConfigurationProvider)
                .ToList();

            return products;
        }

        public ICollection<GetAllProductsByNameServiceModel> GetAllProductsByName(string name, bool caseSensitive)
        {
            ICollection<GetAllProductsByNameServiceModel> products;

            if (caseSensitive)
            {
                products = this.dbContext.Products
                    .Where(x => x.Name == name)
                    .ProjectTo<GetAllProductsByNameServiceModel>(this.mapper.ConfigurationProvider)
                    .ToList();
            }
            else
            {
                products = this.dbContext.Products
                    .Where(x => x.Name.ToLower() == name.ToLower())
                    .ProjectTo<GetAllProductsByNameServiceModel>(this.mapper.ConfigurationProvider)
                    .ToList();
            }

            return products;
        }

        public ICollection<GetAllProductsByTypeServiceModel> GetAllProductsByType(string type)
        {
            ProductType productType;

            bool hasParsed = Enum.TryParse(type, true, out productType);


            if (!hasParsed)
            {
                throw new ArgumentException(ExceptionMessages.InvalidProductType);
            }

            var productsServiceModels = this.dbContext.Products
                .Where(x => x.ProductType == productType)
                .ProjectTo<GetAllProductsByTypeServiceModel>(this.mapper.ConfigurationProvider)
                .ToList();

            return productsServiceModels;
        }

        public bool RemoveById(string id)
        {
            Product productToRemove = this.dbContext.Products
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (productToRemove == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidProductId);
            }

            this.dbContext.Products.Remove(productToRemove);
            int rowsAffected = this.dbContext.SaveChanges();

            bool wasDeleted = rowsAffected == 1;

            return wasDeleted;
        }

        public bool RemoveByName(string name)
        {
            Product productToRemove = this.dbContext.Products
                .Where(x => x.Name == name)
                .FirstOrDefault();

            if (productToRemove == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidProductName);
            }

            this.dbContext.Products.Remove(productToRemove);
            int rowsAffected = this.dbContext.SaveChanges();

            bool wasDeleted = rowsAffected == 1;

            return wasDeleted;
        }
    }
}
