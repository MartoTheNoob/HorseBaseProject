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
                new Breed{ Name = "Mustang", Url = "/lib/images/Thoroughbred.png" },
                new Breed { Name = "Quarter Horse", Url = "/lib/images/QuarterHorse.png" },
                new Breed { Name = "Appaloosa", Url = "/lib/images/Appaloosa.png" },
                new Breed { Name = "PaintHorse", Url = "/lib/images/PaintHorse.png" },
                new Breed { Name = "Warmbloods", Url = "/lib/images/Warmbloods.png" },
            };

            context.breeds.AddRange(breeds);
            context.SaveChanges();

            if (context.horses.Any())
            {
                return; // Database has been seeded
            }

            var horses = new List<Horse> {

             new Horse { Number = 1, BirhtYear = new DateTime(2024, 12, 4), Breed = context.breeds.Where(x => x.Name == "Mustang").FirstOrDefault(), Gender = "male", Height = 30, Price = 5 },
             new Horse { Number = 2, BirhtYear = new DateTime(2024, 11, 4), Breed = context.breeds.Where(x => x.Name == "Quarter Horse").FirstOrDefault(), Gender = "female", Height = 30, Price = 5 },
             new Horse { Number = 3, BirhtYear = new DateTime(2024, 8, 4), Breed = context.breeds.Where(x => x.Name == "Appaloosa").FirstOrDefault(), Gender = "male", Height = 30, Price = 5 },
             new Horse { Number = 4, BirhtYear = new DateTime(2024, 3, 4), Breed = context.breeds.Where(x => x.Name == "PaintHorse").FirstOrDefault(), Gender = "male", Height = 30, Price = 5 },
             new Horse { Number = 5, BirhtYear = new DateTime(2024, 5, 4), Breed = context.breeds.Where(x => x.Name == "Warmbloods").FirstOrDefault(), Gender = "male", Height = 30, Price = 5 },

            };
            context.horses.AddRange(horses);

            // Add breeds to the database

            // Save changes to the database
            context.SaveChanges();
        }
    }
}
