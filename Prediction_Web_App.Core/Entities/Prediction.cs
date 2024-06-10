using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public Fixture Fixture { get; set; }
    }
}
