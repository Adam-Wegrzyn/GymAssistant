using Data.Common.DTO;
using DataAccess.Entities;

namespace GymAssistantv2.Server.Controllers
{
    public interface ITrainingService
    {
        Task<Exercise> AddExercise(ExerciseDTO ExerciseDTO, CancellationToken cancellationToken);
        Task<Training> AddTraining(TrainingDTO TrainingDTO, CancellationToken cancellationToken);
        Task DeleteExercise(int id, CancellationToken cancellationToken);
        Task DeleteTraining(int id, CancellationToken cancellationToken);
        Task<ExerciseDTO> GetExercise(int id, CancellationToken cancellationToken);
        Task<List<ExerciseDTO>> GetAllExercises(CancellationToken cancellationToken);
        Task<List<TrainingDTO>> GetAllTrainings(CancellationToken cancellationToken);
        Task UpdateTraining(TrainingDTO TrainingDTO, CancellationToken cancellationToken);
       // Task AddTrainingLog(TrainingLogDTO trainingLogDTO, CancellationToken cancellationToken);
    }
}