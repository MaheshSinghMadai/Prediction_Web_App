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

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetFixtureById([FromQuery] int fixture_ID)
        {
            try
            {
                var query = (from f in _db.Fixtures
                             where f.Fixture_ID == fixture_ID
                             select f).AsNoTracking().ToList();

                return Ok(query);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetCountriesList()
        {
            try
            {
                return Ok(await _db.Countries.AsNoTracking().ToListAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetPlayersByFixture([FromQuery] string country1, [FromQuery] string country2)
        {
            try
            {
               var query = (from p in _db.Player_Infos
                            join c in _db.Countries on p.Country_Id equals c.Country_ID
                            select new
                            {
                                p.Player_ID,
                                p.Country_Id,
                                p.Player_Name,
                                c.Country_Name
                            }).AsNoTracking().ToList();

                var finalQuery = query.Where(x => x.Country_Name == country1 || x.Country_Name == country2);

                return Ok(finalQuery);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetGoalScorersByFixture([FromQuery] int fixture_ID)
        {
            try
            {
                var query = (from g in _db.Goal_Scorers
                             join p in _db.Player_Infos on g.Player_Id equals p.Player_ID
                             join c in _db.Countries on p.Country_Id equals c.Country_ID
                             where g.Fixture_Id == fixture_ID
                             select new
                             {
                                 p.Player_Name,
                                 c.Country_Name,

                             }).AsNoTracking().ToList();

                return Ok(query);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
