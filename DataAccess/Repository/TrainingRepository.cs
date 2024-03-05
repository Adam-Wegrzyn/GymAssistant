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

        public Task AddTrainingPlan(TrainingPlanDto trainingPlanDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
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

        public async Task<List<Exercise>> GetAllExercises(CancellationToken cancellationToken)
        {
            return await _dbContext.Exercises.ToListAsync(cancellationToken);

        }

        public Task<List<TrainingPlan>> GetAllTrainingPlans(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
