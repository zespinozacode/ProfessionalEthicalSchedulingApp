using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PES.Models
{
    public class EmployeeEdit
    {
        public int EmployeeId { get; set; }

        [Display(Name = "Weekly Hours")]
        public int AvailableHours { get; set; }

        public string Name { get; set; }

        [Display(Name = "Hourly Rate")]
        public float WageAmount { get; set; }

        public float Rating { get; set; }
        public bool CanOpen { get; set; }
        public bool CanClose { get; set; }
    }
}
