using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class TrainingSession: BaseEntity
    {
        public required string Name { get; set; }
        [Required]
        public TrainingPlan TrainingsPlan { get; set; }
        public ICollection<TrainingSet> TrainingSets { get; set; }

    }
}