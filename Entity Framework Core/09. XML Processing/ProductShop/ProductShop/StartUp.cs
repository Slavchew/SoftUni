using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;

        public static void Main(string[] args)
        {
            ProductShopContext db = new ProductShopContext();

            /* Import
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            string usersXml = File.ReadAllText("../../../Datasets/users.xml");
            string productsXml = File.ReadAllText("../../../Datasets/products.xml");
            string categoriesXml = File.ReadAllText("../../../Datasets/categories.xml");
            string categoryProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");
            Console.WriteLine(ImportUsers(db, usersXml));
            Console.WriteLine(ImportProducts(db, productsXml));
            Console.WriteLine(ImportCategories(db, categoriesXml));
            Console.WriteLine(ImportCategoryProducts(db, categoryProductsXml));
            */

            // Export
            //var productsInRange = GetProductsInRange(db);
            //File.WriteAllText("../../../results/products-in-range.xml", productsInRange);

            //var usersSoldProducts = GetSoldProducts(db);
            //File.WriteAllText("../../../results/users-sold-products.xml", usersSoldProducts);

            //var categories = GetCategoriesByProductsCount(db);
            //File.WriteAllText("../../../results/categories-by-products.xml", categories);

            var users = GetUsersWithProducts(db);
            File.WriteAllText("../../../results/users-and-products.xml", users);

        }

        private static void InitliazeMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
            mapper = config.CreateMapper();
        }

        // Problem 1
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            InitliazeMapper();

            const string rootElement = "Users";

            var userDTOs = XMLConverter.Deserializer<ImportUserDto>(inputXml, rootElement);

            var users = mapper.Map<IEnumerable<User>>(userDTOs);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        // Problem 2
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            InitliazeMapper();

            const string rootElement = "Products";

            var productDTOs = XMLConverter.Deserializer<ImportProductDto>(inputXml, rootElement);

            var products = mapper.Map<IEnumerable<Product>>(productDTOs);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        // Problem 3
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            InitliazeMapper();

            const string rootElement = "Categories";

            var catrgoryDTOs = XMLConverter.Deserializer<ImportCategoryDto>(inputXml, rootElement)
                .Where(x => x.Name != null);

            var categories = mapper.Map<IEnumerable<Category>>(catrgoryDTOs);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        // Problem 4
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            InitliazeMapper();

            const string rootElement = "CategoryProducts";

            var categoryProductDTOs = XMLConverter.Deserializer<ImportCategoryProductDto>(inputXml, rootElement)
                .Where(x => context.Categories.Any(c => c.Id == x.CategoryId)
                        && context.Products.Any(p => p.Id == x.ProductId));

            var categoryProducts = mapper.Map<IEnumerable<CategoryProduct>>(categoryProductDTOs);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";
        }

        // Problem 5
        public static string GetProductsInRange(ProductShopContext context)
        {
            const string rootElement = "Products";

            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ExportProductsInRangeDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .OrderBy(p => p.Price)
                .Take(10)
                .ToList();

            var xml = XMLConverter.Serialize(products, rootElement);

            return xml;
        }

        // Problem 6
        public static string GetSoldProducts(ProductShopContext context)
        {
            const string rootElement = "Users";

            var users = context.Users
                .Where(x => x.ProductsSold.Any(p => p.BuyerId != null))
                .Select(x => new ExportUserSoldProductsDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold
                        .Where(p => p.BuyerId != null)
                        .Select(p => new ExportSoldProductsDto
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .ToArray()
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ToArray();

            var xml = XMLConverter.Serialize(users, rootElement);

            return xml;

        }

        // Problem 7
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            const string rootElement = "Categories";

            var categories = context.Categories
                .Select(x => new ExportCategoryDto
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count(),
                    AveragePrice = x.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = x.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToList();

            var xml = XMLConverter.Serialize(categories, rootElement);

            return xml;
        }

        // Problem 8
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            const string rootElement = "Users";

            var users = context.Users
                .Include(x => x.ProductsSold)
                .ToArray()
                .Where(x => x.ProductsSold.Any(p => p.BuyerId != null))
                .Select(x => new ExportUserDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProducts = new ExportProductCountDto
                    {
                        Count = x.ProductsSold.Count(),
                        Products = x.ProductsSold.Select(p => new ExportProductDto
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                    }
                })
                .OrderByDescending(x => x.SoldProducts.Count)
                .ToArray();

            var resultObj = new ExportUserCountDto
            {
                Count = users.Length,
                Users = users.Take(10).ToArray()
            };

            var xml = XMLConverter.Serialize(resultObj, rootElement);

            return xml;
        }
    }
}