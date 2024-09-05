using Data.Common.DTO;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface ITrainingLogService
    {
        Task<TrainingLogDTO> GetTrainingLog(int id, CancellationToken cancellationToken);
        Task CreateTrainingLog(TrainingLogDTO trainingLogDto, CancellationToken cancellationToken);
        Task UpdateTrainingLog(TrainingLogDTO trainingLogDto, CancellationToken cancellationToken);
        Task<List<TrainingLogDTO>> GetAllTrainingLogs(CancellationToken cancellationToken);
    }
}
