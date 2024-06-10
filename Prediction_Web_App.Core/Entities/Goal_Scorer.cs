using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prediction_Web_App.Core.Entities
{
    public class Goal_Scorer
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Fixture")]
        public int Fixture_Id { get; set; }

        [ForeignKey("Player")]
        public int Player_Id { get; set; }

        public Fixture Fixture { get; set; }
        public Player_Info Player { get; set; }
    }
}
