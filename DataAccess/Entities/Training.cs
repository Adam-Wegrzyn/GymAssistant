namespace DataAccess.Entities
{
    public class Training: BaseEntity
    {
        public string Name { get; set; }
        public ICollection<TrainingSetExercise>? TrainingSetExercise { get; set; }
        public bool? isLogged { get; set; }
    }
}