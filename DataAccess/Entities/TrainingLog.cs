﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class TrainingLog: LogEntity
    {
        public DateTime Date { get; set; }
        public Training Training { get; set; }

    }
}
