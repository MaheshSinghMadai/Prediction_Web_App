using Microsoft.AspNetCore.Identity;
using Prediction_Web_App.Core.Entities.Identity;

namespace Prediction_Web_App.Infrastructure.Data.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> _userManager)
        {
            if (!_userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "mahesh",
                    Email = "mahesh@test.com",
                    UserName = "mahesh",
                };
                await _userManager.CreateAsync(user, "P@$$w0rd");
            }
        }
    }
}
