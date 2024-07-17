﻿using Core.Service;
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
            //var exercisesToAttach = training.TrainingSet.Select(t => t.Exercise);
            //foreach (var t in exercisesToAttach)
            //{
            //    _dbContext.Exercises.Attach(t);
            //}
            
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
                var t1 = trainingToUpdate.TrainingSetExercise.Select(t => t.TrainingSets.Select(tr => tr.Id));
                var t2 = training.TrainingSetExercise.Select(t => t.TrainingSets.Select(tr => tr.Id));
                var deleteIds = t1.SelectMany(t => t).Except(t2.SelectMany(t => t));
                var toDelete = trainingToUpdate.TrainingSetExercise.SelectMany(t => t.TrainingSets).Where(t => deleteIds.Contains(t.Id)).ToList();
                toDelete.ForEach(t => _dbContext.Entry(t).State = EntityState.Deleted);

                trainingToUpdate.TrainingSetExercise = training.TrainingSetExercise;
                _dbContext.Update(trainingToUpdate);
                
           }
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
