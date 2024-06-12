using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Prediction_Web_App.Core.Entities
{
    public class Prediction
    {
        [Key]
        public int Prediction_ID { get; set; }

        [ForeignKey("Fixture")]
        public int Fixture_ID { get; set; }
        public int Country1_Score { get; set; }
        public int Country2_Score { get; set; }
        public string Result { get; set; }
        public string Goal_Scorer { get; set; }
        [JsonIgnore]
        public Fixture Fixture { get; set; }
        public string User_Id { get; set; }
    }
}
