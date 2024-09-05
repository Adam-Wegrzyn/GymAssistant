using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Data.Common.DTO;
using System.Threading;

namespace GymAssistantv2.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TrainingController: ControllerBase
    {
        private readonly ITrainingService _trainingService;
    //    private readonly ILogger _logger;

        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        
        }

        [HttpGet]
        [Route("getAllTrainings")]
        public async Task<IActionResult> GetAllTrainings(CancellationToken cancellationToken)
        {
           var result = await _trainingService.GetAllTrainings(cancellationToken);
            return Ok(result);
        }        
        [HttpGet]
        [Route("getExercise/{id}")]
        public async Task<IActionResult> GetExercise(int id, CancellationToken cancellationToken)
        {
           var result = await _trainingService.GetExercise(id, cancellationToken);
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
        [Route("addTraining")]
        public async Task<IActionResult> AddTraining([FromBody] TrainingDTO TrainingDTO, CancellationToken cancellationToken)
        {

            await _trainingService.AddTraining(TrainingDTO, cancellationToken);
            return Ok();
        }        
        
        [HttpDelete]
        [Route("deleteTraining/{id}")]
        public async Task<IActionResult> DeleteTraining(int id, CancellationToken cancellationToken)
        {

            await _trainingService.DeleteTraining(id, cancellationToken);
            return Ok();
        }

        [HttpPost]
        [Route("addExercise")]
        public async Task<IActionResult> AddExercise([FromBody] ExerciseDTO ExerciseDTO, CancellationToken cancellationToken)
        {
            await _trainingService.AddExercise(ExerciseDTO, cancellationToken);
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

        [HttpPost]
        [Route("updateTraining")]
        public async Task<IActionResult> UpdateTraining([FromBody] TrainingDTO TrainingDTO, CancellationToken cancellationToken)
        {
            await _trainingService.UpdateTraining(TrainingDTO, cancellationToken);
            return Ok();
        }
    }
}
