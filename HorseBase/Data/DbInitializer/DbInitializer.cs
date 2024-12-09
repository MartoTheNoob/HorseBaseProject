using System;
using System.Security.Policy;

namespace HorseBase.Data.DbInitializer
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Ensure the database is created
            context.Database.EnsureCreated();

            // Check if there are already Breeds in the database
            if (context.breeds.Any())
            {
                return; // Database has been seeded
            }
            //Delete this later
            // Seed Breeds
            var breeds = new List<Breed>
            {
                new Breed{ name = "Mustang", url = "/lib/images/Thoroughbred.png" },
                new Breed { name = "Quarter Horse", url = "/lib/images/QuarterHorse.png" },
                new Breed { name = "Appaloosa", url = "/lib/images/Appaloosa.png" },
                new Breed { name = "PaintHorse", url = "/lib/images/PaintHorse.png" },
                new Breed { name = "Warmbloods", url = "/lib/images/Warmbloods.png" },
            };

            context.breeds.AddRange(breeds);
            context.SaveChanges();

            if (context.horses.Any())
            {
                return; // Database has been seeded
            }

            var horses = new List<Horse> {

             new Horse { number = 1, birhtYear = new DateTime(2024, 12, 4), breed = context.breeds.Where(x => x.name == "Mustang").FirstOrDefault(), gender = true, height = 30, price = 5 },
             new Horse { number = 2, birhtYear = new DateTime(2024, 11, 4), breed = context.breeds.Where(x => x.name == "Quarter Horse").FirstOrDefault(), gender = true, height = 30, price = 5 },
             new Horse { number = 3, birhtYear = new DateTime(2024, 8, 4), breed = context.breeds.Where(x => x.name == "Appaloosa").FirstOrDefault(), gender = true, height = 30, price = 5 },
             new Horse { number = 4, birhtYear = new DateTime(2024, 3, 4), breed = context.breeds.Where(x => x.name == "PaintHorse").FirstOrDefault(), gender = true, height = 30, price = 5 },
             new Horse { number = 5, birhtYear = new DateTime(2024, 5, 4), breed = context.breeds.Where(x => x.name == "Warmbloods").FirstOrDefault(), gender = true, height = 30, price = 5 },

            };
            context.horses.AddRange(horses);

            // Add breeds to the database

            // Save changes to the database
            context.SaveChanges();
        }
    }
}
