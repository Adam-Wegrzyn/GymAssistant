using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Common.DTO
{
    public class TrainingDto: BaseDto
    {
        public string Name { get; set; }
        public List<TrainingSetExerciseDto> TrainingSetExercise { get; set; }
    }
}
