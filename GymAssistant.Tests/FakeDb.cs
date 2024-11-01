using DataAccess.Entities;
using DataAccess.Enums;

namespace GymAssistant.Tests
{
    public class FakeDb
    {
        public static List<Exercise> GetFakeExercises()
        {
            return new List<Exercise>
            {
                new Exercise
                {
                   // Id = 1,
                    Name = "Push Up",
                    Description = "A basic push-up exercise",
                    MuscleGroup = MuscleGroup.Back,
                    ImagePath = "images/pushup.png",
                    VideoPath = "videos/pushup.mp4"
                },
                new Exercise
                {
                   // Id = 2,
                    Name = "Sit Up",
                    Description = "A basic sit-up exercise",
                    MuscleGroup = MuscleGroup.Triceps,
                    ImagePath = "images/situp.png",
                    VideoPath = "videos/situp.mp4"
                }
            };
        }

        public static List<Training> GetFakeTrainings()
        {
            return new List<Training>
        {
            new Training {  Name = "FBW", isLogged = false },
            new Training {  Name = "Split", isLogged = true }
        };
        }

        public static List<TrainingSet> GetFakeTrainingSets()
        {
            return new List<TrainingSet>
        {
            new TrainingSet {  Reps = 10, Weight = 50 },
            new TrainingSet {  Reps = 15, Weight = 60 }
        };
        }

        public static List<TrainingSetExercise> GetFakeTrainingSetExercises()
        {
            return new List<TrainingSetExercise>
        {
            new TrainingSetExercise
            {
                Id = 1,
                Exercise =  GetFakeExercises().SingleOrDefault(e => e.Id == 1),
                TrainingSets = new List<TrainingSet>
                {
                    new TrainingSet {  Reps = 10, Weight = 50 },
                    new TrainingSet {  Reps = 15, Weight = 60 }
                }
            },
            new TrainingSetExercise
            {
                Id = 2,
                Exercise = GetFakeExercises().SingleOrDefault(e => e.Id == 2),
                TrainingSets = new List<TrainingSet>
                {
                    new TrainingSet {  Reps = 20, Weight = 0 },
                    new TrainingSet {  Reps = 25, Weight = 0 }
                }
            }
        };
        }

    }
}
