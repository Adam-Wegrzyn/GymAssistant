namespace DataAccess.Entities
{
    public class Exercise: BaseEntity
    {
        public string Name { get; set; }
        public Enum MuscleGroup { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string VideoPath { get; set; }

    }
}