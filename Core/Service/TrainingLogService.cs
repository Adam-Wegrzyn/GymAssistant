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

        public async Task<TrainingLogDTO> GetTrainingLog(int id, CancellationToken cancellationToken)
        {
            var trainingLog = await _trainingLogRepository.GetTrainingLog(id, cancellationToken);
            return _mapper.Map<TrainingLogDTO>(trainingLog);
        }

        public async Task CreateTrainingLog(TrainingLogDTO trainingLogDto, CancellationToken cancellationToken)
        {
            var trainingLog = _mapper.Map<TrainingLog>(trainingLogDto);
            await _trainingLogRepository.CreateTrainingLog(trainingLog, cancellationToken);
        }

        public async Task UpdateTrainingLog(TrainingLogDTO trainingLogDto, CancellationToken cancellationToken)
        {
            var trainingLog = _mapper.Map<TrainingLog>(trainingLogDto);
            await _trainingLogRepository.UpdateTrainingLog(trainingLog, cancellationToken);
        }

        public async Task<List<TrainingLogDTO>> GetAllTrainingLogs(CancellationToken cancellationToken)
        {
            var  trainingLogs = await _trainingLogRepository.GetAllTrainingLogs(cancellationToken);
            var exercisesDto = _mapper.Map<List<TrainingLog>, List<TrainingLogDTO>>(trainingLogs);
            return _mapper.Map<List<TrainingLogDTO>>(trainingLogs);
        }
    }
}
