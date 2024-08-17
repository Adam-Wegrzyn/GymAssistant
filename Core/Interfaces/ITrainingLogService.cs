using Data.Common.DTO;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface ITrainingLogService
    {
        Task<TrainingSetLogDTO> GetTrainingSetLogAsync(int id, CancellationToken cancellationToken);
        Task CreateTrainingSetLogAsync(TrainingSetLogDTO trainingSetLogDto, CancellationToken cancellationToken);
        Task UpdateTrainingSetLogAsync(TrainingSetLogDTO trainingSetLogDto, CancellationToken cancellationToken);

        Task<TrainingSetExerciseLogDTO> GetTrainingSetExerciseLogAsync(int id, CancellationToken cancellationToken);
        Task CreateTrainingSetExerciseLogAsync(TrainingSetExerciseLogDTO trainingSetExerciseLogDto, CancellationToken cancellationToken);
        Task UpdateTrainingSetExerciseLogAsync(TrainingSetExerciseLogDTO trainingSetExerciseLogDto, CancellationToken cancellationToken);

        Task<TrainingLogDTO> GetTrainingLogAsync(int id, CancellationToken cancellationToken);
        Task CreateTrainingLogAsync(TrainingLogDTO trainingLogDto, CancellationToken cancellationToken);
        Task UpdateTrainingLogAsync(TrainingLogDTO trainingLogDto, CancellationToken cancellationToken);
    }
}
