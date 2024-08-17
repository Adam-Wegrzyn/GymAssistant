using AutoMapper;
using Data.Common.DTO;
using DataAccess.Entities;
using GymAssistantv2.Server.Controllers;
using Microsoft.VisualBasic;
using System.Net.Http.Headers;

namespace Core.Service
{
    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _trainingRepository;
        private readonly IMapper _mapper;

        public TrainingService(ITrainingRepository trainingRepository, IMapper mapper)
        {
            _trainingRepository = trainingRepository;
            _mapper = mapper;
        }
        public async Task AddExercise(ExerciseDTO ExerciseDTO, CancellationToken cancellationToken)
        {
            var exercise = _mapper.Map<ExerciseDTO, Exercise>(ExerciseDTO);
            await _trainingRepository.AddExercise(exercise, cancellationToken);
        }

        public async Task AddTraining(TrainingDTO TrainingDTO, CancellationToken cancellationToken)
        {
            var training = _mapper.Map<TrainingDTO, Training>(TrainingDTO);

            await _trainingRepository.AddTraining(training, cancellationToken);
        }

        public async Task DeleteExercise(int id, CancellationToken cancellationToken)
        {
            await _trainingRepository.DeleteExercise(id, cancellationToken);
        }

        public async Task DeleteTraining(int id, CancellationToken cancellationToken)
        {
            await _trainingRepository.DeleteTraining(id, cancellationToken);
        }

        public async Task<List<ExerciseDTO>> GetAllExercises(CancellationToken cancellationToken)
        {

            var exercises = await _trainingRepository.GetAllExercises(cancellationToken);
            var exercisesDto = _mapper.Map<List<Exercise>, List<ExerciseDTO>>(exercises);
            return exercisesDto;
        }

        public async Task<List<TrainingDTO>> GetAllTrainings(CancellationToken cancellationToken)
        {

            var trainings = await _trainingRepository.GetAllTrainings(cancellationToken);
            var trainingsDto = _mapper.Map<List<Training>, List<TrainingDTO>>(trainings);
           return trainingsDto;
        }

        public async Task<ExerciseDTO> GetExercise(int id, CancellationToken cancellationToken)
        {
            var exercise = await _trainingRepository.GetExercise(id, cancellationToken);
            return _mapper.Map<Exercise, ExerciseDTO>(exercise);

        }

        public async Task UpdateTraining(TrainingDTO TrainingDTO, CancellationToken cancellationToken)
        {          
            var trainingToUpdate = _mapper.Map<TrainingDTO, Training>(TrainingDTO);

            await _trainingRepository.UpdateTraining(trainingToUpdate, cancellationToken);
        }
    }
}
