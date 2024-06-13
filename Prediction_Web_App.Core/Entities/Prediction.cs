using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Prediction_Web_App.Core.Entities
{
    public class Prediction
    {
        [Key]
        public int Prediction_ID { get; set; }
        public string Country1 { get; set; }
        public int Country1_Score { get; set; }
        public string Country2 { get; set; }
        public int Country2_Score { get; set; }
        public int Goal_Scorer_Id { get; set; }
        public string Goal_Scorer_Name { get; set; }

        [ForeignKey("Fixture")]
        public int Fixture_ID { get; set; }
        [JsonIgnore]
        public Fixture Fixture { get; set; }
        public string User_Id { get; set; }
    }
}
