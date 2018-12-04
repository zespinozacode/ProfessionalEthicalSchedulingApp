using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PES.Data
{
    
    public class Day
    {
        //[Key]
        public int DayId { get; set; }

        //[Required]
        public Guid ManagerId { get; set; }

        //[Required]
        public DayOfWeek DayOfWeek { get; set; }

        //[Required]
        public decimal Sales { get; set; }
    }
}
