using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PES.Data
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public Guid ManagerId { get; set; }

        [Required]
        public int AvailableHours { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public float WageAmount { get; set; }

        [Required]
        public float Rating { get; set; }

        [Required]
        public bool CanOpen { get; set; }

        [Required]
        public bool CanClose { get; set; }
    }
}
