using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prediction_Web_App.Core.Entities
{
    public  class Player_Info
    {
        [Key]
        public int Player_ID { get; set; }
        public string Player_Name { get; set; }

        [ForeignKey("Country")]
        public int Country_Id { get; set; }

        public Country Country { get; set; }
        public ICollection<Goal_Scorer> GoalScorers { get; set; }
    }
}
