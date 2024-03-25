using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Common.DTO
{
    public class TrainingSetDto: BaseDto
    {
        public ExerciseDto Exercise { get; set; }
        public int Reps { get; set; }
        public int Sets { get; set; }
        public decimal Weight { get; set; }
    }
}
