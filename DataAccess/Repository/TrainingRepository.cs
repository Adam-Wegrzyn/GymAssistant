using Core.Service;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly GymAssistantDbContext _dbContext;

        public TrainingRepository(GymAssistantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddExercise(Exercise exercise, CancellationToken cancellationToken)
        {
            _dbContext.Exercises.Add(exercise);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Exercise> GetExercise(int id, CancellationToken cancellationToken)
        {
            return await _dbContext.Exercises.Where(e => e.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task AddTraining(Training training, CancellationToken cancellationToken)
        {
            _dbContext.Trainings.Add(training);
            foreach (var t in training.TrainingSetExercise)
            {
                _dbContext.Exercises.Attach(t.Exercise);

            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Training> GetTraining(int id, CancellationToken cancellationToken)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _dbContext.Trainings
                .Include(t => t.TrainingSetExercise)
                                    .ThenInclude(e => e.Exercise).AsNoTracking()
                .Include(t => t.TrainingSetExercise)
                    .ThenInclude(t => t.TrainingSets)
                .Where(e => e.Id == id).FirstOrDefaultAsync(cancellationToken)
          ;
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task DeleteExercise(int id, CancellationToken cancellationToken)
        {
            var exercise = _dbContext.Exercises.FirstOrDefault(ex => ex.Id == id);

            if (exercise != null)
            {
                _dbContext.Exercises.Remove(exercise);
                await _dbContext.SaveChangesAsync();
            }

        }

        public async Task DeleteTraining(int id, CancellationToken cancellationToken)
        {
            var training = _dbContext.Trainings
                .Include(t => t.TrainingSetExercise)
                    .ThenInclude(ts => ts.Exercise)
                    .Include(t => t.TrainingSetExercise)
                    .ThenInclude(t => t.TrainingSets).FirstOrDefault(t => t.Id == id)
   ;

            if (training != null)
            {
                _dbContext.Trainings
                    .Remove(training);
                await _dbContext.SaveChangesAsync();
            }

        }

        public async Task<List<Exercise>> GetAllExercises(CancellationToken cancellationToken)
        {
            return await _dbContext.Exercises.ToListAsync(cancellationToken);

        }

        public async Task<List<Training>> GetAllTrainings(CancellationToken cancellationToken)
        {
            return await _dbContext.Trainings
                .Include(t => t.TrainingSetExercise)
                    .ThenInclude(e => e.Exercise)
                .Include(t => t.TrainingSetExercise)
                    .ThenInclude(t => t.TrainingSets)
                .ToListAsync(cancellationToken);
        }


        public async Task UpdateTraining(Training training, CancellationToken cancellationToken)
        {
            var trainingToUpdate = await GetTraining(training.Id, cancellationToken);
            if (trainingToUpdate != null)
            {
                //handle what nested entities have been deleted
                var t1 = trainingToUpdate.TrainingSetExercise.Select(t => t.TrainingSets.Select(tr => tr.Id));
                var t2 = training.TrainingSetExercise
                    .Select(t => t.TrainingSets.Select(tr => tr.Id));
                var deleteExercises = trainingToUpdate.TrainingSetExercise
                    .Select(t => t.Id).Except(training.TrainingSetExercise.Select(t => t.Id));
                var deleteIdsSets = t1.SelectMany(t => t).Except(t2.SelectMany(t => t));
                var toDeleteExercise = trainingToUpdate.TrainingSetExercise.Where(t => deleteExercises.Contains(t.Id)).ToList();
                var toDeleteSets = trainingToUpdate.TrainingSetExercise.SelectMany(t => t.TrainingSets)
                    .Where(t => deleteIdsSets.Contains(t.Id)).ToList();
                toDeleteSets.ForEach(t => _dbContext.Entry(t).State = EntityState.Deleted);
                toDeleteExercise.ForEach(t => _dbContext.Entry(t).State = EntityState.Deleted);


                trainingToUpdate.TrainingSetExercise = training.TrainingSetExercise;
                _dbContext.Update(trainingToUpdate);

            }
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
