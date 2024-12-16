﻿
using HorseBase.Models;

namespace HorseBase.Data.DbInitializer
{
    public static class SeedBreed
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (context.breeds.Any())
            {
                return; // Database has been seeded
            }
            // Seed Breeds
            var breeds = new List<Breed>
            {
                new Breed{ Name = "Mustang", Url = "/lib/images/Thoroughbred.png" },
                new Breed { Name = "Quarter Horse", Url = "/lib/images/QuarterHorse.png" },
                new Breed { Name = "Appaloosa", Url = "/lib/images/Appaloosa.png" },
                new Breed { Name = "PaintHorse", Url = "/lib/images/PaintHorse.png" },
                new Breed { Name = "Warmbloods", Url = "/lib/images/Warmbloods.png" },
            };

            context.breeds.AddRange(breeds);
            context.SaveChanges();
        }
    }
}
