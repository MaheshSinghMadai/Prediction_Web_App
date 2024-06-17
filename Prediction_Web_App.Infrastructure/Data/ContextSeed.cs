using Microsoft.AspNetCore.Identity;
using Prediction_Web_App.Core.Entities.Identity;
using Prediction_Web_App.Core.Enum;

namespace Prediction_Web_App.Infrastructure.Data
{
    public static class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));
        }
    }
}
