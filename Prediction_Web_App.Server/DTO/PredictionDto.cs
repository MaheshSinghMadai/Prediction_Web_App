using Prediction_Web_App.Core.Entities;

namespace Prediction_Web_App.Server.DTO
{
    public class PredictionDto
    {
        public int Fixture_ID { get; set; }
        public int Country1_Score { get; set; }
        public int Country2_Score { get; set; }
        public string Result { get; set; }
        public string Goal_Scorer { get; set; }
        public string User_Id { get; set; }
    }
}
