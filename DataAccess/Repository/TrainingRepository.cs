using Core.Service;
using Data.Common.DTO;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var exercisesToAttach = training.TrainingSet.Select(t => t.Exercise);
            foreach (var t in exercisesToAttach)
            {
                _dbContext.Exercises.Attach(t);
            }
            
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Training> GetTraining(int id, CancellationToken cancellationToken)
        {
            return await _dbContext.Trainings.Where(e => e.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task DeleteExercise(int id, CancellationToken cancellationToken)
        {
            var exercise = _dbContext.Exercises.FirstOrDefault(ex => ex.Id == id);

            if(exercise != null)
            {
                _dbContext.Exercises.Remove(exercise);
                await _dbContext.SaveChangesAsync();
            }

        }

        public async Task DeleteTraining(int id, CancellationToken cancellationToken)
        {
            var training = _dbContext.Trainings.FirstOrDefault(t => t.Id == id);

            if (training != null)
            {
                _dbContext.Trainings.Remove(training);
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
                .Include(t => t.TrainingSet)
                .ThenInclude(e => e.Exercise)
                .ToListAsync(cancellationToken);
        }

        public async Task UpdateTraining(Training training, CancellationToken cancellationToken)
        {
            var trainingToUpdate = await GetTraining(training.Id, cancellationToken); 
            if (trainingToUpdate != null)
            {
                trainingToUpdate.Name = training.Name;
                trainingToUpdate.TrainingSet = training.TrainingSet;
            }
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
