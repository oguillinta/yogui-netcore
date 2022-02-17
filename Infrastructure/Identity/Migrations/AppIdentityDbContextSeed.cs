using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity.Migrations
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Oscar",
                    Email = "oscar@test.com",
                    UserName = "oscar@test.com"
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}