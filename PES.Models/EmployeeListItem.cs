using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PES.Models
{
    public class EmployeeListItem
    {
        [Display(Name="ID Number")]
        public int EmployeeId { get; set; }
        public string Name { get; set; }

        [Display(Name="Wage")]
        public float WageAmount { get; set; }

        public float Rating { get; set; }

        public override string ToString() => Name;
    }
}
