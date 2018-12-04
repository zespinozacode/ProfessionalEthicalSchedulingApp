using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PES.Data
{
    
    public class Day
    {
        public int DayId { get; set; }
        public Guid ManagerId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public float Sales { get; set; }
    }
}
