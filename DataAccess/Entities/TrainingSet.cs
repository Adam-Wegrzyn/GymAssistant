using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class TrainingSet: BaseEntity
    {
        public int Reps { get; set; }
        public decimal Weight { get; set; }
    }
}
