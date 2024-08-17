namespace Data.Common.DTO
{
    public class TrainingSetExerciseDTO: BaseDto
    {
        public ExerciseDTO Exercise { get; set; }
        public List<TrainingSetDTO> TrainingSets { get; set; }
    }
}