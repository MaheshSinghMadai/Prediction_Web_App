using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prediction_Web_App.Core.Entities
{
    public  class Player_Info
    {
        [Key]
        public int Player_ID { get; set; }
        public int Player_Name { get; set; }
        public string Country { get; set; }
    }
}
