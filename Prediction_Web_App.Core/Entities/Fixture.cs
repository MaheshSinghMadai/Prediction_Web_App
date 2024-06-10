using System.ComponentModel.DataAnnotations;

namespace Prediction_Web_App.Core.Entities
{
    public class Fixture
    {
        [Key]
        public int Fixture_ID { get; set; }
        public string Country1 { get; set; }
        public int Country1_Score { get; set; }
        public string Country2 { get; set; }
        public int Country2_Score { get; set; }
        public string Result { get; set; }

        public ICollection<Goal_Scorer> Goal_Scorers { get; set; }
        public ICollection<Prediction> Predictions { get; set; }

    }
}
