using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Prediction_Web_App.Core.Entities;
using Prediction_Web_App.Core.Entities.Identity;
using Prediction_Web_App.Core.Interface;
using Prediction_Web_App.Infrastructure.Data;
using Prediction_Web_App.Infrastructure.Services;
using System.Text;

namespace Prediction_Web_App.Server.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class ScorecardController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly ScorecardService _scorecardService;
        public ScorecardController(
            ApplicationDbContext db,
            ScorecardService scorecardService)
        {
            _db = db;
            _scorecardService = scorecardService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetScorecardByUser([FromQuery] string user_Id)
        {
            try
            {
                var query = (from s in _db.Scorecards
                             join f in _db.Fixtures on s.Fixture_ID equals f.Fixture_ID
                             where s.User_Id == user_Id
                             select new
                             {
                                 s.Fixture_ID,
                                 f.Country1,
                                 f.Country2,
                                 s.Final_Score_Points,
                                 s.Goal_Scorer_Points,
                                 s.Total_Points,
                             }).AsNoTracking().OrderBy(f => f.Fixture_ID).ToList();

                return Ok(query);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateFixtureScores([FromBody] Fixture fixture)
        {
            try
            {
                var existingFixture = await _db.Fixtures.FindAsync(fixture.Fixture_ID);
                if (existingFixture == null)
                {
                    return NotFound("Fixture not found.");
                }

                // Update fixture scores
                existingFixture.Country1_Score = fixture.Country1_Score;
                existingFixture.Country2_Score = fixture.Country2_Score;
                _db.Entry(existingFixture).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                // Update scorecards
                await _scorecardService.UpdateScorecardsAsync(existingFixture);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
        
    }
}
