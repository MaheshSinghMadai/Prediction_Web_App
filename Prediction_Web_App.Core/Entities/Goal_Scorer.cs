using System.ComponentModel.DataAnnotations;

namespace Prediction_Web_App.Core.Entities
{
    public class Goal_Scorer
    {
        [Key]
        public int Id { get; set; }
        public int Fixture_Id { get; set; }
        public int Player_Id { get; set; }
    }
}
