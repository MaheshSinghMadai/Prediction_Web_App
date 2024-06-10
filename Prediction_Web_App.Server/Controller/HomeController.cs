using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prediction_Web_App.Infrastructure.Data;

namespace Prediction_Web_App.Server.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetFixturesList()
        {
            try
            {
                return Ok(await _db.Fixtures.ToListAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
