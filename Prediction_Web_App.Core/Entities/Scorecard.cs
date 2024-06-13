
using System.ComponentModel.DataAnnotations;

namespace Prediction_Web_App.Core.Entities
{
    public class Scorecard
    {
        [Key]
        public int Scorecard_Id { get; set; }
        public int Fixture_ID { get; set; }
        public string? User_Id { get; set; }
        public int? Final_Score_Points { get; set; }
        public int? Goal_Scorer_Points { get; set; }
        public int? Total_Points { get; set; }
    }
}
