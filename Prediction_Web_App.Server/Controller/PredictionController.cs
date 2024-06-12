using Microsoft.AspNetCore.Mvc;
using Prediction_Web_App.Infrastructure.Data;

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
        public async Task<IActionResult> GetPredictionByUserId()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }



    }
}
