using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Common.DTO
{
    public class TrainingSessionDto: BaseDto
    {
        public string Name { get; set; }
        public TrainingDTO TrainingPlan { get; set; }
        public ICollection<TrainingSetDTO> TrainingSets { get; set; }
    }
}
