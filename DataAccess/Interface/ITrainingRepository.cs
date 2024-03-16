
using Data.Common.DTO;
using DataAccess.Entities;

namespace Core.Service
{
    public interface ITrainingRepository
    {
        Task AddExercise(Exercise exercise, CancellationToken cancellationToken);
        Task AddTraining(Training training, CancellationToken cancellationToken);
        Task DeleteExercise(int id, CancellationToken cancellationToken);
        Task<List<Exercise>> GetAllExercises(CancellationToken cancellationToken);
        Task<List<Training>> GetAllTrainings(CancellationToken cancellationToken);
    }
}