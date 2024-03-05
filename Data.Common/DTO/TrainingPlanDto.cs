using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Common.DTO
{
    public class TrainingPlanDto: BaseDto
    {
        public string Name { get; set; }
        public ICollection<TrainingSessionDto> TrainingSessions { get; set; }
    }
}
