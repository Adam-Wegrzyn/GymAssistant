using Core.Service;
using Data.Common.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GymAssistantv2.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainingLogController : ControllerBase
    {
        private ITrainingLogService _trainingLogService;

        public TrainingLogController(ITrainingLogService trainingLogService)
        {
            _trainingLogService = trainingLogService;
        }

        [HttpPost]
        [Route("CreateTrainingLog")]
        public async Task<IActionResult> CreateTrainingLog([FromBody] TrainingLogDTO trainingLogDto, CancellationToken cancellationToken)
        {
            await _trainingLogService.CreateTrainingLog(trainingLogDto, cancellationToken);
            return Ok();
        }

        [HttpGet]
        [Route("GetAllTrainingLogs")]
        public async Task<IActionResult> GetAllTrainingLogs(CancellationToken cancellationToken)
        {
            var trainingLogs = await _trainingLogService.GetAllTrainingLogs(cancellationToken);
            return Ok(trainingLogs);
        }

        [HttpGet]
        [Route("GetTrainingLog/{id}")]
        public async Task<IActionResult> GetTrainingLog(int id, CancellationToken cancellationToken)
        {
            var trainingLog = await _trainingLogService.GetTrainingLog(id, cancellationToken);
            return Ok(trainingLog);
        }
    }
}
