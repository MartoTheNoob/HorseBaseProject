using HorseBase.Models;
using Microsoft.AspNetCore.Identity;

namespace HorseBase.Data.DbInitializer
{
    public static class SeedRoles
    {
        public static async void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                await CreateRoles(roleManager);
            }
        }
        public static async Task CreateRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("User"))
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
        }
    }
}
