using System.ComponentModel.DataAnnotations;

namespace Prediction_Web_App.Core.Entities
{
    public class Country
    {
        [Key]
        public int Country_ID { get; set; }
        public string Country_Name { get; set; }
        public string Group { get; set; }
    }
}
