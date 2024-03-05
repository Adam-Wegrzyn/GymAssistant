using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class TrainingSet: BaseEntity
    {
        public string Name { get; set; }
        public Exercise Exercise { get; set; }
        public int Reps { get; set; }
        public decimal Weight { get; set; }
        public TrainingSession TrainingSession { get; set; }
    }
}
