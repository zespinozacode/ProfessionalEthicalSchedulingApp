using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PES.Models
{
    public class WeekDataListItem
    {
        [Display(Name="Week Number")]
        public int WeekId { get; set; }

        [Display(Name ="Monday Sales")]
        public float MondaySales { get; set; }

        [Display(Name = "Tuesday Sales")]
        public float TuesdaySales { get; set; }

        [Display(Name = "Wednesday Sales")]
        public float WednesdaySales { get; set; }

        [Display(Name = "Thursday Sales")]
        public float ThursdaySales { get; set; }

        [Display(Name = "Friday Sales")]
        public float FridaySales { get; set; }

        [Display(Name = "Saturday Sales")]
        public float SaturdaySales { get; set; }

        [Display(Name = "Sunday Sales")]
        public float SundaySales { get; set; }
    }
}
