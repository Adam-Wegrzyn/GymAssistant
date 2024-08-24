using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Common.DTO
{
    public class TrainingDTO : BaseDto
    {
        public string Name { get; set; }
        public List<TrainingSetExerciseDTO> TrainingSetExercise { get; set; }
        public bool isLogged { get; set; }
    }
}
