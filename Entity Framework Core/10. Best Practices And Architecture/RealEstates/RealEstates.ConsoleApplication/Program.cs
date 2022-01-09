using System;
using System.Text;
using RealEstates.Data;
using RealEstates.Services;
using Microsoft.EntityFrameworkCore;

namespace RealEstates.ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var db = new RealEstateDbContext();
            db.Database.Migrate();

            

            IPropertiesService propertiesService = new PropertiesService(db);
            Console.Write("Min price: ");
            int minPrice = int.Parse(Console.ReadLine());
            Console.Write("Max price: ");
            int maxPrice = int.Parse(Console.ReadLine());
            var properties = propertiesService.SearchByPrice(minPrice, maxPrice);
            foreach (var property in properties)
            {
                Console.WriteLine($"{property.District}, fl. {property.Floor}, {property.Size} ㎡, {property.Year}, {property.Price}€, {property.PropertyType}, {property.BuildingType}");
            }

            /*
            IDistrictService districtService = new DistrictService(db);
            var districts = districtService.GetTopDistrictsByAveragePrice();
            foreach (var district in districts)
            {
                Console.WriteLine($"{district.Name} => Price: {district.AveragePrice:f2} ({district.MinPrice}-{district.MaxPrice}) => {district.PropertiesCount} properties");
            }
            */
        }
    }
}
