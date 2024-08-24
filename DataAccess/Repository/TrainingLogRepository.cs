using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

public class TrainingLogRepository : ITrainingLogRepository
{
    private readonly GymAssistantDbContext _dbContext;

    public TrainingLogRepository(GymAssistantDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TrainingLog> GetTrainingLog(int id, CancellationToken cancellationToken)
    {
        return await _dbContext.TrainingLogs.FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task CreateTrainingLog(TrainingLog trainingLog, CancellationToken cancellationToken)
    {
        _dbContext.TrainingLogs.Add(trainingLog);
        foreach (var t in trainingLog.Training.TrainingSetExercise)
        {
            _dbContext.Exercises.Attach(t.Exercise);
        }

            await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateTrainingLog(TrainingLog trainingLog, CancellationToken cancellationToken)
    {
        var existingLog = await _dbContext.TrainingLogs.FindAsync(new object[] { trainingLog.Id }, cancellationToken);
        if (existingLog != null)
        {
            _dbContext.Entry(existingLog).CurrentValues.SetValues(trainingLog);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
