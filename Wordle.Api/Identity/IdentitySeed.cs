using Microsoft.AspNetCore.Identity;
using Wordle.Api.Data;

namespace Wordle.Api.Identity
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

            if ((await userManager.FindByNameAsync("admin@intellitect.com")) == null)
            {
                //Add admin account
                var user = new AppUser
                {
                    UserName = "admin@intellitect.com",
                    NormalizedUserName = "admin@intellitect.com".ToUpper(),
                    Email = "admin@intellitect.com",
                    NormalizedEmail = "admin@intellitect.com".ToUpper(),
                    DateOfBirth = "6-1-2000",
                    isMasterOfTheUniverse = true,
                };
                var result = await userManager.CreateAsync(user, "P@ssw0rd");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, Roles.Admin);
                }
                else
                {
                    throw new Exception("Could not create admin user");
                }

                //Add basic user account
                user = new AppUser
                {
                    UserName = "user1@intellitect.com",
                    NormalizedUserName = "user1@intellitect.com".ToUpper(),
                    Email = "user1@intellitect.com",
                    NormalizedEmail = "user1@intellitect.com".ToUpper(),
                    DateOfBirth = "6-1-2015",
                    isMasterOfTheUniverse = false,
                };
                result = await userManager.CreateAsync(user, "P@ssw0rd");
                if (!result.Succeeded)
                {
                    throw new Exception("Could not create basic user");
                }

                //create 21+ user
                user = new AppUser
                {
                    UserName = "user2@intellitect.com",
                    NormalizedUserName = "user2@intellitect.com".ToUpper(),
                    Email = "user2@intellitect.com",
                    NormalizedEmail = "user2@intellitect.com".ToUpper(),
                    DateOfBirth = "6-1-2000",
                    isMasterOfTheUniverse = true,
                };
                result = await userManager.CreateAsync(user, "P@ssw0rd");
                if (!result.Succeeded)
                {
                    throw new Exception("Could not create admin user");
                }
            }
        }
    }
}
