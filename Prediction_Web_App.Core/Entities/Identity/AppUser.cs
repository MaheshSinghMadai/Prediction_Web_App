using Microsoft.AspNetCore.Identity;

namespace Prediction_Web_App.Core.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string Token { get; set; }
        public DateTime expiresAt { get; set; }
    }
}
