using AutoMapper;
using Data.Common.DTO;
using DataAccess.Entities;
using DataAccess.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Service
{
    public class TrainingLogService : ITrainingLogService
    {
        private readonly ITrainingLogRepository _trainingLogRepository;
        private readonly IMapper _mapper;

        public TrainingLogService(ITrainingLogRepository trainingLogRepository, IMapper mapper)
        {
            _trainingLogRepository = trainingLogRepository;
            _mapper = mapper;
        }

        public  Task<TrainingSetLogDTO> GetTrainingSetLogAsync(int id, CancellationToken cancellationToken)
        {
            var trainingSetLog = await _trainingLogRepository.GetTrainingSetLogAsync(id, cancellationToken);
            return _mapper.Map<TrainingSetLogDTO>(trainingSetLog);
        }

        public async Task CreateTrainingSetLogAsync(TrainingSetLogDTO trainingSetLogDto, CancellationToken cancellationToken)
        {
            var trainingSetLog = _mapper.Map<TrainingSetLog>(trainingSetLogDto);
            await _trainingLogRepository.CreateTrainingSetLogAsync(trainingSetLog, cancellationToken);
        }

        public async Task UpdateTrainingSetLogAsync(TrainingSetLogDTO trainingSetLogDto, CancellationToken cancellationToken)
        {
            var trainingSetLog = _mapper.Map<TrainingSetLog>(trainingSetLogDto);
            await _trainingLogRepository.UpdateTrainingSetLogAsync(trainingSetLog, cancellationToken);
        }

        public async Task<TrainingSetExerciseLogDTO> GetTrainingSetExerciseLogAsync(int id, CancellationToken cancellationToken)
        {
            var trainingSetExerciseLog = await _trainingLogRepository.GetTrainingSetExerciseLogAsync(id, cancellationToken);
            return _mapper.Map<TrainingSetExerciseLogDTO>(trainingSetExerciseLog);
        }

        public async Task CreateTrainingSetExerciseLogAsync(TrainingSetExerciseLogDTO trainingSetExerciseLogDto, CancellationToken cancellationToken)
        {
            var trainingSetExerciseLog = _mapper.Map<TrainingSetExerciseLog>(trainingSetExerciseLogDto);
            await _trainingLogRepository.CreateTrainingSetExerciseLogAsync(trainingSetExerciseLog, cancellationToken);
        }

        public async Task UpdateTrainingSetExerciseLogAsync(TrainingSetExerciseLogDTO trainingSetExerciseLogDto, CancellationToken cancellationToken)
        {
            var trainingSetExerciseLog = _mapper.Map<TrainingSetExerciseLog>(trainingSetExerciseLogDto);
            await _trainingLogRepository.UpdateTrainingSetExerciseLogAsync(trainingSetExerciseLog, cancellationToken);
        }

        public async Task<TrainingLogDTO> GetTrainingLogAsync(int id, CancellationToken cancellationToken)
        {
            var trainingLog = await _trainingLogRepository.GetTrainingLogAsync(id, cancellationToken);
            return _mapper.Map<TrainingLogDTO>(trainingLog);
        }

        public async Task CreateTrainingLogAsync(TrainingLogDTO trainingLogDto, CancellationToken cancellationToken)
        {
            var trainingLog = _mapper.Map<TrainingLog>(trainingLogDto);
            await _trainingLogRepository.CreateTrainingLogAsync(trainingLog, cancellationToken);
        }

        public async Task UpdateTrainingLogAsync(TrainingLogDTO trainingLogDto, CancellationToken cancellationToken)
        {
            var trainingLog = _mapper.Map<TrainingLog>(trainingLogDto);
            await _trainingLogRepository.UpdateTrainingLogAsync(trainingLog, cancellationToken);
        }
    }
}
