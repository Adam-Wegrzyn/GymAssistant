namespace DataAccess.Entities
{
    public class Training: BaseEntity
    {
        public string Name { get; set; }
        public ICollection<TrainingSet> TrainingSet { get; set; }
    }
}