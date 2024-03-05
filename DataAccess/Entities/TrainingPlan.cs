namespace DataAccess.Entities
{
    public class TrainingPlan: BaseEntity
    {
        public string Name { get; set; }
        public ICollection<TrainingSession> TrainingSessions { get; set; }
    }
}