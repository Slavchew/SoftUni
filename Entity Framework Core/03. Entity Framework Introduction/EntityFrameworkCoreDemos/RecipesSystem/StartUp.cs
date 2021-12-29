using Microsoft.EntityFrameworkCore;
using RecipesSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipesSystem
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new RecipesDbContext();
            db.Database.Migrate();

            db.SaveChanges();
        }
    }
}
