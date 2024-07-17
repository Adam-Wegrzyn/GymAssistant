using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class TrainingSetExercise: BaseEntity
    {
        public Exercise Exercise { get; set; }
        public List<TrainingSet> TrainingSets { get; set; }

    }
}
