namespace Data.Common.DTO
{
    public class TrainingSetExerciseDto: BaseDto
    {
        public ExerciseDto Exercise { get; set; }
        public List<TrainingSetDto> TrainingSets { get; set; }
    }
}