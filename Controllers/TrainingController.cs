using System.Collections;
using System.Collections.Generic;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Core;

namespace GymAssistant.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TrainingController : ControllerBase
	{
		private readonly ILogger<TrainingController> _logger;
		private readonly ITrainingService _trainingService;

		public TrainingController(ILogger<TrainingController> logger, ITrainingService trainingService)
		{
			_logger = logger;
			_trainingService = trainingService;
		}

		[HttpGet]
		[Route("Get")]
		public IEnumerable<Exercise> GetAllExercises()
		{
			return null;
		}
	}
}