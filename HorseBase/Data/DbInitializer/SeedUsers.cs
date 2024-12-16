using HorseBase.Models;
using HorseBase.Models.ViewModels.User;
using Microsoft.AspNetCore.Identity;

namespace HorseBase.Data.DbInitializer
{
    public static class SeedUsers
    {

        public static async void Seed(IApplicationBuilder applicationBuilder, ApplicationDbContext context)
        {
            using (var scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetService<UserManager<User>>();
                await CreateUsers(userManager, context);
            }
        }
        public static async Task CreateUsers(UserManager<User> userManager, ApplicationDbContext context)
        {
            if (context.Users.Where(x => x.UserName == "AdminGay").FirstOrDefault() != null)
            {
                return;
            }
            User admin = new User()
            {
                UserName = "AdminGay",
                Email = "admin@admin.admin",
                FirstName = "Admin",
                MiddleName = "Adminov",
                LastName = "Adminchov",
            };

            var result = await userManager.CreateAsync(admin, "123%Ab");
            await userManager.AddToRoleAsync(admin, "Admin");

        }
    }
}