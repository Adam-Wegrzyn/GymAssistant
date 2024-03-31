using Data.Common.DTO;
using DataAccess.Entities;

namespace GymAssistantv2.Server.Controllers
{
    public interface ITrainingService
    {
        Task AddExercise(ExerciseDto exerciseDto, CancellationToken cancellationToken);
        Task AddTraining(TrainingDto trainingDto, CancellationToken cancellationToken);
        Task DeleteExercise(int id, CancellationToken cancellationToken);
        Task DeleteTraining(int id, CancellationToken cancellationToken);
        Task <List<ExerciseDto>> GetAllExercises(CancellationToken cancellationToken);
        Task <List<TrainingDto>> GetAllTrainings(CancellationToken cancellationToken);
        Task UpdateTraining(TrainingDto trainingDto, CancellationToken cancellationToken);
    }
}