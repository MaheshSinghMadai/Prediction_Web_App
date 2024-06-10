
namespace Prediction_Web_App.Core.Entities
{
    public class Scorecard
    {
        public int Fixture_ID { get; set; }
        public int User_ID { get; set; }
        public int Final_Score_Points { get; set; }
        public int Result_Points { get; set; }
        public int Goal_Scorer_Points { get; set; }
        public int Total_Points { get; set; }
    }
}
