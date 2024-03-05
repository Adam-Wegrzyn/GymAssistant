using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Data.Common.DTO;
using System.Threading;

namespace GymAssistantv2.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class TrainingController: ControllerBase
    {
        private readonly ITrainingService _trainingService;
    //    private readonly ILogger _logger;

        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        
        }

        [HttpGet]
        [Route("getAllTrainingPlans")]
        public async Task<IActionResult> GetAllTrainingPlans(CancellationToken cancellationToken)
        {
            var result = await _trainingService.GetAllTrainingPlans(cancellationToken);
            return Ok(result);
        }
        [HttpGet]
        [Route("getAllExercises")]
        public async Task<IActionResult> GetAllExercises(CancellationToken cancellationToken)
        {
            var result = await _trainingService.GetAllExercises(cancellationToken);
            Console.WriteLine("executed get");
            return Ok(result);
        }

        [HttpPost]
        [Route("addTrainingPlan")]
        public async Task<IActionResult> AddTrainingPlan([FromBody] TrainingPlanDto trainingPlanDto, CancellationToken cancellationToken)
        {
            await _trainingService.AddTrainingPlan(trainingPlanDto, cancellationToken);
            return Ok();
        }

        [HttpPost]
        [Route("addExercise")]
        public async Task<IActionResult> AddExercise([FromBody] ExerciseDto exerciseDto, CancellationToken cancellationToken)
        {
            await _trainingService.AddExercise(exerciseDto, cancellationToken);
            Console.WriteLine("executed add");
            return Ok();
            

        }

        [HttpDelete]
        [Route("deleteExercise/{id}")]
        public async Task<IActionResult> DeleteExercise(int id, CancellationToken cancellationToken)
        {

            await _trainingService.DeleteExercise(id, cancellationToken);
            return Ok();
        }
    }
}
