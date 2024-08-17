using Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace GymAssistantv2.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainingLogController : ControllerBase
    {
        private TrainingLogService _trainingLogService;

        public TrainingLogController(TrainingLogService trainingLogService)
        {
            _trainingLogService = trainingLogService;
        }

        [HttpPost]
        [Route("AddTrainingLog")]
        public IActionResult AddTrainingLog(FromBodyAttribute TrainingLogDTO trainingLog)
        {
            _trainingLogService.AddTrainingLog(trainingLog);
            return (Ok());
        }

    }
}
