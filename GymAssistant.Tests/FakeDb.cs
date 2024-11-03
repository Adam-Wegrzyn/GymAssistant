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
                    Name = "Pull Up",
                    Description = "A basic push-up exercise",
                    MuscleGroup = MuscleGroup.Back,
                    ImagePath = "images/pushup.png",
                    VideoPath = "videos/pushup.mp4"
                },
                new Exercise
                {
                    Name = "Bench Press",
                    Description = "A basic bench press exercise",
                    MuscleGroup = MuscleGroup.Chest,
                    ImagePath = "images/situp.png",
                    VideoPath = "videos/situp.mp4"
                }
                new Exercise
                {
                    Name = "Biceps curl",
                    Description = "A basic biceps curl exercise",
                    MuscleGroup = MuscleGroup.Biceps,
                    ImagePath = "images/pushup.png",
                    VideoPath = "videos/pushup.mp4"
                },
                new Exercise
                {
                    Name = "Squat",
                    Description = "A basic squat exercise",
                    MuscleGroup = MuscleGroup.Legs,
                    ImagePath = "images/situp.png",
                    VideoPath = "videos/situp.mp4"
                }
            };
        }

        public static List<Training> GetFakeTrainings()
        {
            return new List<Training>
        {
            new Training {  Name = "FBW",
                            isLogged = false,
                            TrainingSetExercise = GetFakeTrainingSetExercises()
            },
            new Training {  Name = "Split",
                            isLogged = true,
                            TrainingSetExercise = GetFakeTrainingSetExercises2()}
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
        public static List<TrainingSetExercise> GetFakeTrainingSetExercises2()
        {
            return new List<TrainingSetExercise>
        {
            new TrainingSetExercise
            {
                Id = 3,
                Exercise =  GetFakeExercises().SingleOrDefault(e => e.Id == 3),
                TrainingSets = new List<TrainingSet>
                {
                    new TrainingSet {  Reps = 10, Weight = 50 },
                    new TrainingSet {  Reps = 15, Weight = 30 }
                }
            },
            new TrainingSetExercise
            {
                Id = 4,
                Exercise = GetFakeExercises().SingleOrDefault(e => e.Id == 4),
                TrainingSets = new List<TrainingSet>
                {
                    new TrainingSet {  Reps = 5, Weight = 100 },
                    new TrainingSet {  Reps = 3, Weight = 120 }
                }
            }
        };
        }

    }
}
