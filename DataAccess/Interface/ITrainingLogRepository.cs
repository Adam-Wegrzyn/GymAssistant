using DataAccess.Entities;

public interface ITrainingLogRepository
{

    Task<TrainingLog> GetTrainingLog(int id, CancellationToken cancellationToken);
    Task CreateTrainingLog(TrainingLog trainingLog, CancellationToken cancellationToken);
    Task UpdateTrainingLog(TrainingLog trainingLog, CancellationToken cancellationToken);
    Task<List<TrainingLog>> GetAllTrainingLogs(CancellationToken cancellationToken);
}