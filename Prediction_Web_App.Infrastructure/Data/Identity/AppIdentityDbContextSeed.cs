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
                var users = new List<AppUser>
                {
                     new AppUser
                    {
                        DisplayName = "mahesh",
                        Email = "mahesh@test.com",
                        UserName = "mahesh",
                    },

                    new AppUser
                    {
                        DisplayName = "kasam",
                        Email = "kasam@test.com",
                        UserName = "kasam",
                    },
                    new AppUser
                    {
                        DisplayName = "krishna",
                        Email = "krishna@test.com",
                        UserName = "krishna",
                    },
                     new AppUser
                    {
                        DisplayName = "rakshak",
                        Email = "rakshak@test.com",
                        UserName = "rakshak",
                    },
                      new AppUser
                    {
                        DisplayName = "santosh",
                        Email = "santosh@test.com",
                        UserName = "santosh",
                    }
                };

                var passwords = new List<string>
                 {
                    "P@$$w0rd",
                    "kasam@123",
                    "krishna@123",
                    "rakshak@123",
                    "santosh@123",
                // Add corresponding passwords for each user
                };

                for (int i = 0; i < users.Count; i++)
                {
                    var user = users[i];
                    var password = passwords[i];
                    var result = await _userManager.CreateAsync(user, password);
                    if (!result.Succeeded)
                    {
                        throw new Exception("Failed to create user: " + string.Join(", ", result.Errors.Select(e => e.Description)));
                    }
                }
            }
        }
    }
}
