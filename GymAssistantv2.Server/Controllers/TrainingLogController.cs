using Core.Service;
using Data.Common.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GymAssistantv2.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

    }
}
