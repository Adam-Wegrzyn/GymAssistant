using Data.Common.DTO;
using DataAccess.Entities;
using GymAssistantv2.Server.Controllers;
using Microsoft.VisualBasic;
using System.Net.Http.Headers;

namespace Core.Service
{
    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _trainingRepository;

        public TrainingService(ITrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }
        public async Task AddExercise(ExerciseDto exerciseDto, CancellationToken cancellationToken)
        {
            var exercise = new Exercise();
            exercise.Id = exerciseDto.Id;
            exercise.Name = exerciseDto.Name;
            await _trainingRepository.AddExercise(exercise, cancellationToken);
        }

        public async Task AddTraining(TrainingDto trainingDto, CancellationToken cancellationToken)
        {
            var training = new Training
            {
                Name = trainingDto.Name,
                TrainingSet = new List<TrainingSet>()
                
            };

            foreach (var t in trainingDto.TrainingSet)
            {
                var trainingSet = new TrainingSet
                {
                    Exercise = new Exercise(),
                    Reps = t.Reps,
                    Weight = t.Weight
                };
                trainingSet.Exercise.Name = t.Exercise.Name;
                trainingSet.Exercise.Id = t.Exercise.Id;
                training.TrainingSet.Add(trainingSet);               
                
            }
            await _trainingRepository.AddTraining(training, cancellationToken);
        }

        public async Task DeleteExercise(int id, CancellationToken cancellationToken)
        {
            await _trainingRepository.DeleteExercise(id, cancellationToken);
        }

        public async Task<List<ExerciseDto>> GetAllExercises(CancellationToken cancellationToken)
        {
            
            var exercises = await _trainingRepository.GetAllExercises(cancellationToken);
            var exercisesDto = new List<ExerciseDto>();
            foreach (var exercise in exercises)
            {
                var ex = new ExerciseDto();
                ex.Name = exercise.Name;
                ex.Id = exercise.Id;
                exercisesDto.Add(ex);
            }
            return exercisesDto;
        }

        public async Task<List<TrainingDto>> GetAllTrainings(CancellationToken cancellationToken)
        {
            var trainings = await _trainingRepository.GetAllTrainings(cancellationToken);
            var trainingsDto = new List<TrainingDto>();
            foreach (var training in trainings)
            {
                var trainingDto = new TrainingDto();
                trainingDto.Name = training.Name;
                trainingDto.Id = training.Id;
                trainingDto.TrainingSet = [];
                
                foreach(var tSet in training.TrainingSet)
                {
                    var trainingSet = new TrainingSetDto();
                    trainingSet.Id = tSet.Id;
                    trainingSet.Reps = tSet.Reps;
                    trainingSet.Weight  = tSet.Weight;
                    trainingSet.Exercise = new ExerciseDto { Id = tSet.Exercise.Id, Name =  tSet.Exercise.Name };

                    trainingDto.TrainingSet.Add(trainingSet);


                }
                trainingsDto.Add(trainingDto);
            }
            return trainingsDto;
        }
    }
}
