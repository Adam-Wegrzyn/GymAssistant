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

    // Method to get TrainingSetLog by Id
    public async Task<TrainingSetLog> GetTrainingSetLogAsync(int id, CancellationToken cancellationToken)
    {
        return await _dbContext.TrainingSetLogs.FindAsync(new object[] { id }, cancellationToken);
    }

    // Method to create TrainingSetLog
    public async Task CreateTrainingSetLogAsync(TrainingSetLog trainingSetLog, CancellationToken cancellationToken)
    {
        _dbContext.TrainingSetLogs.Add(trainingSetLog);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    // Method to update TrainingSetLog
    public async Task UpdateTrainingSetLogAsync(TrainingSetLog trainingSetLog, CancellationToken cancellationToken)
    {
        var existingLog = await _dbContext.TrainingSetLogs.FindAsync(new object[] { trainingSetLog.Id }, cancellationToken);
        if (existingLog != null)
        {
            _dbContext.Entry(existingLog).CurrentValues.SetValues(trainingSetLog);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }

    // Method to get TrainingSetExerciseLog by Id
    public async Task<TrainingSetExerciseLog> GetTrainingSetExerciseLogAsync(int id, CancellationToken cancellationToken)
    {
        return await _dbContext.TrainingSetExerciseLogs.FindAsync(new object[] { id }, cancellationToken);
    }

    // Method to create TrainingSetExerciseLog
    public async Task CreateTrainingSetExerciseLogAsync(TrainingSetExerciseLog trainingSetExerciseLog, CancellationToken cancellationToken)
    {
        _dbContext.TrainingSetExerciseLogs.Add(trainingSetExerciseLog);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    // Method to update TrainingSetExerciseLog
    public async Task UpdateTrainingSetExerciseLogAsync(TrainingSetExerciseLog trainingSetExerciseLog, CancellationToken cancellationToken)
    {
        var existingLog = await _dbContext.TrainingSetExerciseLogs.FindAsync(new object[] { trainingSetExerciseLog.Id }, cancellationToken);
        if (existingLog != null)
        {
            _dbContext.Entry(existingLog).CurrentValues.SetValues(trainingSetExerciseLog);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }

    // Method to get TrainingLog by Id
    public async Task<TrainingLog> GetTrainingLogAsync(int id, CancellationToken cancellationToken)
    {
        return await _dbContext.TrainingLogs.FindAsync(new object[] { id }, cancellationToken);
    }

    // Method to create TrainingLog
    public async Task CreateTrainingLogAsync(TrainingLog trainingLog, CancellationToken cancellationToken)
    {
        _dbContext.TrainingLogs.Add(trainingLog);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    // Method to update TrainingLog
    public async Task UpdateTrainingLogAsync(TrainingLog trainingLog, CancellationToken cancellationToken)
    {
        var existingLog = await _dbContext.TrainingLogs.FindAsync(new object[] { trainingLog.Id }, cancellationToken);
        if (existingLog != null)
        {
            _dbContext.Entry(existingLog).CurrentValues.SetValues(trainingLog);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}