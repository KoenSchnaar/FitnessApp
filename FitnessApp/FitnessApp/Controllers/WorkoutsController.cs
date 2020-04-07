using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessApp.Models;
using FitnessApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Controllers
{
    [Route("api/[Controller]")]

    public class WorkoutsController : Controller
    {
        private readonly IExerciseRepository exerciseRepository;
        private readonly ITrainingRepository trainingRepository;
        private readonly IWorkoutFormRepository workoutFormRepository;
        private readonly IWorkoutRepository workoutRepository;

        public WorkoutsController(IExerciseRepository exerciseRepository, ITrainingRepository trainingRepository, IWorkoutFormRepository workoutFormRepository, IWorkoutRepository workoutRepository)
        {
            this.exerciseRepository = exerciseRepository;
            this.trainingRepository = trainingRepository;
            this.workoutFormRepository = workoutFormRepository;
            this.workoutRepository = workoutRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<WorkoutModel>>> Get()
        {
            try
            {
                return Ok(await workoutRepository.GetWorkouts());

            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get exercises");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]WorkoutModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Model = await workoutRepository.CreateWorkoutFromModel(model);
                    return Created($"/api/workouts/{Model.WorkoutId}", Model);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch
            {
                return BadRequest("Failed to add a new workout");
            }
        }
    }
}