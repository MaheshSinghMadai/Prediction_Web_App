using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Prediction_Web_App.Core.Entities
{
    public class Fixture
    {
        [Key]
        public int Fixture_ID { get; set; }
        public string Country1 { get; set; }
        public string Country1_Flag { get; set; }
        public int Country1_Score { get; set; }
        public string Country2 { get; set; }
        public string Country2_Flag { get; set; }
        public int Country2_Score { get; set; }

        [JsonIgnore]
        public ICollection<Goal_Scorer> Goal_Scorers { get; set; }
        [JsonIgnore]
        public ICollection<Prediction> Predictions { get; set; }

    }
}
