using DataAccess.Entities;
using System.Threading;
using System.Threading.Tasks;

public interface ITrainingLogRepository
{

    Task<TrainingLog> GetTrainingLog(int id, CancellationToken cancellationToken);
    Task CreateTrainingLog(TrainingLog trainingLog, CancellationToken cancellationToken);
    Task UpdateTrainingLog(TrainingLog trainingLog, CancellationToken cancellationToken);
    Task<List<TrainingLog>> GetAllTrainingLogs(CancellationToken cancellationToken);
}