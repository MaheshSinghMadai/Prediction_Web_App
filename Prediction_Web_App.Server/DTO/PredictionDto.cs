using Prediction_Web_App.Core.Entities;

namespace Prediction_Web_App.Server.DTO
{
    public class PredictionDto
    {
        public int Fixture_ID { get; set; }
        public string Country1 { get; set; }
        public int Country1_Score { get; set; }
        public string Country2 { get; set; }
        public int Country2_Score { get; set; }
        public int Goal_Scorer_Id { get; set; }
        public string Goal_Scorer_Name { get; set; }
        public string User_Id { get; set; }
    }
}
