using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PES.Data
{
    public class WeekData
    {
        [Key]
        public int WeekId { get; set; }

        [Required]
        public Guid ManagerId { get; set; }

        [Required]
        public float MondaySales { get; set; }

        [Required]
        public float TuesdaySales { get; set; }
        
        [Required]
        public float WednesdaySales { get; set; }

        [Required]
        public float ThursdaySales { get; set; }

        [Required]
        public float FridaySales { get; set; }

        [Required]
        public float SaturdaySales { get; set; }

        [Required]
        public float SundaySales { get; set; }        
    }
}
