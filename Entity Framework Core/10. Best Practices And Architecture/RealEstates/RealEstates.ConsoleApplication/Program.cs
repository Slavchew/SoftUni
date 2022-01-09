using RealEstates.Data;
using System;

namespace RealEstates.ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var db = new RealEstateDbContext();
            db.Database.EnsureCreated();
        }
    }
}
