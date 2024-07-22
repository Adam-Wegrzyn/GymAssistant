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
        public async Task AddExercise(ExerciseDto exerciseDto, CancellationToken cancellationToken)
        {
            var exercise = _mapper.Map<ExerciseDto, Exercise>(exerciseDto);
            await _trainingRepository.AddExercise(exercise, cancellationToken);
        }

        public async Task AddTraining(TrainingDto trainingDto, CancellationToken cancellationToken)
        {
            var training = _mapper.Map<TrainingDto, Training>(trainingDto);

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

        public async Task<List<ExerciseDto>> GetAllExercises(CancellationToken cancellationToken)
        {

            var exercises = await _trainingRepository.GetAllExercises(cancellationToken);
            var exercisesDto = _mapper.Map<List<Exercise>, List<ExerciseDto>>(exercises);
            return exercisesDto;
        }

        public async Task<List<TrainingDto>> GetAllTrainings(CancellationToken cancellationToken)
        {

            var trainings = await _trainingRepository.GetAllTrainings(cancellationToken);
            var trainingsDto = _mapper.Map<List<Training>, List<TrainingDto>>(trainings);
           return trainingsDto;
        }

        public async Task<ExerciseDto> GetExercise(int id, CancellationToken cancellationToken)
        {
            var exercise = await _trainingRepository.GetExercise(id, cancellationToken);
            return _mapper.Map<Exercise, ExerciseDto>(exercise);

        }

        public async Task UpdateTraining(TrainingDto trainingDto, CancellationToken cancellationToken)
        {          
            var trainingToUpdate = _mapper.Map<TrainingDto, Training>(trainingDto);

            await _trainingRepository.UpdateTraining(trainingToUpdate, cancellationToken);
        }
    }
}
