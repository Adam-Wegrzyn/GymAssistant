﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Common.DTO
{
    public class TrainingLogDTO: LogDTO
    {
        TrainingDTO Training { get; set; }
        public DateTime Date { get; set; }
    }
}
