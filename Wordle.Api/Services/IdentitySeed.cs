using Microsoft.AspNetCore.Identity;
using Wordle.Api.Data;

namespace Wordle.Api.Services
{
    public class IdentitySeed
    {
        public async static Task Seed(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (await roleManager.FindByNameAsync(Roles.Admin) == null)
            {
                var adminRole = new IdentityRole(Roles.Admin);
                await roleManager.CreateAsync(adminRole);
            }

            if ((await userManager.FindByNameAsync(Roles.Admin)) == null)
            {
                var user = new AppUser
                {
                    UserName = "admin@intellitect.com",
                    NormalizedUserName = "admin@intellitect.com".ToUpper(),
                    Email = "admin@intellitect.com",
                    NormalizedEmail = "admin@intellitect.com".ToUpper(),
                };
                var result = await userManager.CreateAsync(user, "P@ssw0rd");
                await userManager.AddToRoleAsync(user, Roles.Admin);
            }
        }
    }
}
