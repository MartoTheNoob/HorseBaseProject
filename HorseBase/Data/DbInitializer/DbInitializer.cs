using System;
using System.Security.Policy;
using HorseBase.Models;

namespace HorseBase.Data.DbInitializer
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context, IApplicationBuilder app)
        {
            // Ensure the database is created
            context.Database.EnsureCreated();
            SeedBreed.Seed(context);
            SeedHorses.Seed(context);
            SeedRoles.Seed(app);
            SeedUsers.Seed(app, context);
        }
    }
}
