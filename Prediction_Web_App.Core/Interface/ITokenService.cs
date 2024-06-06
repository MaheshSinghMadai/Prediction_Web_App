using Prediction_Web_App.Core.Entities.Identity;

namespace Prediction_Web_App.Core.Interface
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);

    }
}
