using System;

namespace PrototypePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Country country = new Country() { Name = "Uzbekistan" };
            City city = new City() { Name = "Uzbekistan City" };
            Address address = new Address() { Street = "Uzbeki 29" };
            address.City = city;
            address.Country = country;

            Address prototypeAddress = (Address)address.Clone();
            prototypeAddress.Street = "Uzbeli 31";
            prototypeAddress.City.Name = "Sofia";

            Console.WriteLine(address);
            Console.WriteLine(prototypeAddress);
        }
    }
}
