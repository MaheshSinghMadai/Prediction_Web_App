using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Prediction_Web_App.Core.Entities.Identity;
using Prediction_Web_App.Core.Interface;
using Prediction_Web_App.Infrastructure.Data;
using Prediction_Web_App.Server.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Prediction_Web_App.Server.Controller
{
    
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly ApplicationDbContext _db;
        private readonly SymmetricSecurityKey _key;
        private readonly IConfiguration _config;
        public AccountController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ITokenService tokenService,
             IConfiguration config,
            ApplicationDbContext db)
        {
            _db = db;
            _userManager = userManager;
            _config = config;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]));
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
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

        [HttpPost("refresh-token")]
        public IActionResult RefreshToken([FromBody] UserDto user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.Username)
            };

            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddMinutes(30),
                    SigningCredentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);
                //user.DisplayName = identity.FindFirst("GivenName").Value;
                user.ExpiresAt = tokenDescriptor.Expires;

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = new { code = "Internal Server Error", message = ex.GetBaseException().Message } });
            }
        }

    }
}
