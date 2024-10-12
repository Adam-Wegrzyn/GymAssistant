using DataAccess.Enums;

namespace Data.Common.DTO
{
    public class ExerciseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MuscleGroup MuscleGroup { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string VideoPath { get; set; }
    }
}
