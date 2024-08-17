using DataAccess.Entities;
using System.Threading;
using System.Threading.Tasks;

public interface ITrainingLogRepository
{
    Task<TrainingSetLog> GetTrainingSetLogAsync(int id, CancellationToken cancellationToken);
    Task CreateTrainingSetLogAsync(TrainingSetLog trainingSetLog, CancellationToken cancellationToken);
    Task UpdateTrainingSetLogAsync(TrainingSetLog trainingSetLog, CancellationToken cancellationToken);

    Task<TrainingSetExerciseLog> GetTrainingSetExerciseLogAsync(int id, CancellationToken cancellationToken);
    Task CreateTrainingSetExerciseLogAsync(TrainingSetExerciseLog trainingSetExerciseLog, CancellationToken cancellationToken);
    Task UpdateTrainingSetExerciseLogAsync(TrainingSetExerciseLog trainingSetExerciseLog, CancellationToken cancellationToken);

    Task<TrainingLog> GetTrainingLogAsync(int id, CancellationToken cancellationToken);
    Task CreateTrainingLogAsync(TrainingLog trainingLog, CancellationToken cancellationToken);
    Task UpdateTrainingLogAsync(TrainingLog trainingLog, CancellationToken cancellationToken);
}