﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PES.Models
{
    public class DayDetail
    {
        public int DayId { get; set; }
        public DayOfWeek WeekDay { get; set; }
        public decimal Sales { get; set; }
    }
}
