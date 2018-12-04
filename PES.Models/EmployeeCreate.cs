using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PES.Models
{
    public class EmployeeCreate
    {
        [Required]
        public string Name { get; set; }
        public int AvailableHours { get; set; }
        public decimal WageAmount { get; set; }
        public float Rating { get; set; }
        public bool CanOpen { get; set; }
        public bool CanClose { get; set; }

        public override string ToString() => Name;
    }
}
