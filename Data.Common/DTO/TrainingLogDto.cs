using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Common.DTO
{
    public class TrainingLogDTO
    {
        public TrainingDTO Training { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
    }
}
