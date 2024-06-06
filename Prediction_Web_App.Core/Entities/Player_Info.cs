using System.ComponentModel.DataAnnotations;

namespace Prediction_Web_App.Core.Entities
{
    public  class Player_Info
    {
        [Key]
        public int Player_ID { get; set; }
        public string Player_Name { get; set; }
        public string Country { get; set; }
    }
}
