using HorseBase.Models;

namespace HorseBase.Data.DbInitializer
{
    public static class SeedHorses
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (context.horses.Any())
            {
                return; // Database has been seeded
            }

            // Seed Horses
            var horses = new List<Horse> {

             new Horse { Number = 1, BirhtYear = new DateTime(2024, 12, 4), Breed = context.breeds.Where(x => x.Name == "Mustang").FirstOrDefault(), Gender = "true", Height = 30, Price = 5 },
             new Horse { Number = 2, BirhtYear = new DateTime(2024, 11, 4), Breed = context.breeds.Where(x => x.Name == "Quarter Horse").FirstOrDefault(), Gender = "true", Height = 30, Price = 5 },
             new Horse { Number = 3, BirhtYear = new DateTime(2024, 8, 4), Breed = context.breeds.Where(x => x.Name == "Appaloosa").FirstOrDefault(), Gender = "true", Height = 30, Price = 5 },
             new Horse { Number = 4, BirhtYear = new DateTime(2024, 3, 4), Breed = context.breeds.Where(x => x.Name == "PaintHorse").FirstOrDefault(), Gender = "true", Height = 30, Price = 5 },
             new Horse { Number = 5, BirhtYear = new DateTime(2024, 5, 4), Breed = context.breeds.Where(x => x.Name == "Warmbloods").FirstOrDefault(), Gender = "true", Height = 30, Price = 5 },

            };
            context.horses.AddRange(horses);
            context.SaveChanges();
        }
    }
}
