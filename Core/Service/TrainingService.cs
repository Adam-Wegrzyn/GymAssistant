using Data.Common.DTO;
using DataAccess.Entities;
using GymAssistantv2.Server.Controllers;

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

        public async Task AddTrainingPlan(TrainingPlanDto trainingPlanDto, CancellationToken cancellationToken)
        {
            await _trainingRepository.AddTrainingPlan(trainingPlanDto, cancellationToken);
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

        public async Task<List<TrainingPlanDto>> GetAllTrainingPlans(CancellationToken cancellationToken)
        {
            var trainingPlans = await _trainingRepository.GetAllExercises(cancellationToken);
            var trainingPlansDto = new List<TrainingPlanDto>();
            foreach (var trainingPlan in trainingPlans)
            {
                var t = new TrainingPlanDto();
                t.Name = trainingPlan.Name;
                t.Id = trainingPlan.Id;
                trainingPlansDto.Add(t);
            }
            return trainingPlansDto;
        }
    }
}
