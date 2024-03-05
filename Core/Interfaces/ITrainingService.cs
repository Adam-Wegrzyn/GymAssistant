using Data.Common.DTO;
using DataAccess.Entities;

namespace GymAssistantv2.Server.Controllers
{
    public interface ITrainingService
    {
        Task AddExercise(ExerciseDto exerciseDto, CancellationToken cancellationToken);
        Task AddTrainingPlan(TrainingPlanDto trainingPlanDto, CancellationToken cancellationToken);
        Task DeleteExercise(int id, CancellationToken cancellationToken);
        Task <List<ExerciseDto>> GetAllExercises(CancellationToken cancellationToken);
        Task <List<TrainingPlanDto>> GetAllTrainingPlans(CancellationToken cancellationToken);
        
    }
}