
using Data.Common.DTO;
using DataAccess.Entities;

namespace Core.Service
{
    public interface ITrainingRepository
    {
        Task AddExercise(Exercise exercise, CancellationToken cancellationToken);
        Task AddTrainingPlan(TrainingPlanDto trainingPlanDto, CancellationToken cancellationToken);
        Task DeleteExercise(int id, CancellationToken cancellationToken);
        Task<List<Exercise>> GetAllExercises(CancellationToken cancellationToken);
        Task<List<TrainingPlan>> GetAllTrainingPlans(CancellationToken cancellationToken);
    }
}