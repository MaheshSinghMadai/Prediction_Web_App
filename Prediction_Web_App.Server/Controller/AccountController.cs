using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Prediction_Web_App.Core.Entities.Identity;
using Prediction_Web_App.Core.Interface;
using Prediction_Web_App.Infrastructure.Data;
using Prediction_Web_App.Server.DTO;

namespace Prediction_Web_App.Server.Controller
{
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly ApplicationDbContext _db;
        public AccountController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ITokenService tokenService,
            ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto, string returnUrl)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Username);
            if (user == null)
            {
                return Unauthorized();
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
            {
                return Unauthorized();
            }

            return new UserDto
            {
                UserId = user.Id,
                Token = _tokenService.CreateToken(user),
                Username = user.UserName,
                Email = user.Email,
                ExpiresAt = DateTime.Now.AddMinutes(30),
            };
        }

    }
}
