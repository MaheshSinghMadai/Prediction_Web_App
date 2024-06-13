using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prediction_Web_App.Core.Entities;
using Prediction_Web_App.Infrastructure.Data;
using Prediction_Web_App.Server.DTO;

namespace Prediction_Web_App.Server.Controller
{

    [ApiController]
    [Route("[controller]")]
    public class PredictionController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public PredictionController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllPredictionByUserId([FromQuery] string user_Id)
        {
            try
            {
                var query = (from p in _db.Predictions
                             where p.User_Id == user_Id 
                             select new 
                             {
                                p.Fixture_ID,
                                p.Country1,
                                p.Country2,
                                p.Country1_Score,
                                p.Country2_Score,
                                p.Goal_Scorer_Name
                             }).AsNoTracking().ToList();

                return Ok(query);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetPredictionByUserId([FromQuery] string user_Id, [FromQuery] int fixture_Id)
        {
            try
            {

                var query = (from p in _db.Predictions
                             join f in _db.Fixtures on p.Fixture_ID equals f.Fixture_ID
                             where p.User_Id == user_Id && p.Fixture_ID == fixture_Id
                             select new
                             {
                                 p.Fixture_ID,
                                 p.Country1,
                                 p.Country2,
                                 f.Country1_Flag,
                                 p.Country1_Score,
                                 f.Country2_Flag,
                                 p.Country2_Score,
                                 p.Goal_Scorer_Name
                             }).AsNoTracking().ToList();

                return Ok(query);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddNewPrediction([FromBody] PredictionDto prd)
        {
            try
            {
                var existingPrediction = await _db.Predictions
                    .FirstOrDefaultAsync(p => p.Fixture_ID == prd.Fixture_ID && p.User_Id == prd.User_Id);

                if (existingPrediction != null)
                {
                    return BadRequest("You have already made a prediction for this fixture.");
                }
                var prediction = new Prediction()
                {
                    Fixture_ID = prd.Fixture_ID,
                    Country1 = prd.Country1,
                    Country1_Score = prd.Country1_Score,
                    Country2_Score = prd.Country2_Score,
                    Country2 = prd.Country2,
                    Goal_Scorer_Id = prd.Goal_Scorer_Id,
                    Goal_Scorer_Name = prd.Goal_Scorer_Name,
                    User_Id = prd.User_Id,
                };

                _db.Add(prediction);
                await _db.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
