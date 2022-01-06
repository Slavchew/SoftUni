using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;

        public static void Main(string[] args)
        {
            ProductShopContext db = new ProductShopContext();

            /*
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            string userInputJson = File.ReadAllText("../../../Datasets/users.json");
            string productsInputJson = File.ReadAllText("../../../Datasets/products.json");
            string categoriesInputJson = File.ReadAllText("../../../Datasets/categories.json");
            string categoriesProductsInputJson = File.ReadAllText("../../../Datasets/categories-products.json");

            Console.WriteLine(ImportUsers(db, userInputJson));
            Console.WriteLine(ImportProducts(db, productsInputJson));
            Console.WriteLine(ImportCategories(db, categoriesInputJson));
            Console.WriteLine(ImportCategoryProducts(db, categoriesProductsInputJson));
            */

            Console.WriteLine(GetUsersWithProducts(db));

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
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            InitliazeMapper();

            var dtoUsers = JsonConvert.DeserializeObject<IEnumerable<UserInputModel>>(inputJson);

            var users = mapper.Map<IEnumerable<User>>(dtoUsers);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        // Problem 2
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            InitliazeMapper();

            var dtoProducts = JsonConvert.DeserializeObject<IEnumerable<ProductInputModel>>(inputJson);

            var products = mapper.Map<IEnumerable<Product>>(dtoProducts);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        // Problem 3
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            InitliazeMapper();

            var dtoCategories = JsonConvert
                .DeserializeObject<IEnumerable<CategoryInputModel>>(inputJson)
                .Where(x => x.Name != null);

            var categories = mapper.Map<IEnumerable<Category>>(dtoCategories);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        // Problem 4
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            InitliazeMapper();

            var dtoCategoryProducts = JsonConvert.
                DeserializeObject<IEnumerable<CategoryProductInputModel>>(inputJson);

            var categoryProducts = mapper.Map<IEnumerable<CategoryProduct>>(dtoCategoryProducts);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";
        }

        // Problem 5
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName,
                })
                .OrderBy(p => p.price)
                .ToList();

            var result = JsonConvert.SerializeObject(products, Formatting.Indented);

            return result;
        }

        // Problem 6
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Any(p => p.BuyerId != null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold
                        .Where(p => p.BuyerId != null)
                        .Select(pc => new
                        {
                            name = pc.Name,
                            price = pc.Price,
                            buyerFirstName = pc.Buyer.FirstName,
                            buyerLastName = pc.Buyer.LastName,
                        }).ToList()
                })
                .OrderBy(x => x.lastName)
                .ThenBy(x => x.firstName)
                .ToList();

            var result = JsonConvert.SerializeObject(users, Formatting.Indented);

            return result;
        }

        // Problem 7
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    category = x.Name,
                    productsCount = x.CategoryProducts.Count(),
                    averagePrice = x.CategoryProducts.Average(cp => cp.Product.Price).ToString("F2"),
                    totalRevenue = x.CategoryProducts.Sum(cp => cp.Product.Price).ToString("F2")
                }).OrderByDescending(x => x.productsCount).ToList();

            string result = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return result;
        }

        // Problem 8
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Include(x => x.ProductsSold)
                .ToList()
                .Where(x => x.ProductsSold.Any(p => p.BuyerId != null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    age = x.Age,
                    soldProducts = new
                    {
                        count = x.ProductsSold.Count(p => p.BuyerId != null),
                        products = x.ProductsSold.Where(p => p.BuyerId != null)
                            .Select(p => new
                            {
                                name = p.Name,
                                price = p.Price
                            }).ToList()
                    }
                })
                .OrderByDescending(x => x.soldProducts.products.Count())
                .ToList();

            var resultObj = new
            {
                usersCount = users.Count,
                users = users
            };

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
            };

            string json = JsonConvert.SerializeObject(resultObj, settings);

            return json;

        }
    }
}