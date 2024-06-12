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
                             select p)
                             .AsNoTracking().ToList();

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
                             where p.User_Id == user_Id && p.Fixture_ID == fixture_Id
                             select p)
                             .AsNoTracking().ToList();

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
                    Country1_Score = prd.Country1_Score,
                    Country2_Score = prd.Country2_Score,
                    Result = prd.Result,
                    Goal_Scorer = prd.Goal_Scorer,
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
