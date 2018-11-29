using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PES.Models
{
    public class WeekDataCreate
    {
        [Required]
        public float MondaySales { get; set; }
        public float TuesdaySales { get; set; }
        public float WednesdaySales { get; set; }
        public float ThursdaySales { get; set; }
        public float FridaySales { get; set; }
        public float SaturdaySales { get; set; }
        public float SundaySales { get; set; }
    }
}
