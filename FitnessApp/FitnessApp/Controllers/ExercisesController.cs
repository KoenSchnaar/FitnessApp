using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessApp.DatabaseClasses;
using FitnessApp.Models;
using FitnessApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Controllers
{
    [Route("api/[Controller]")]
    //[ApiController]
    //[Produces("application/json")]
    public class ExercisesController : Controller
    {
        private readonly IExerciseRepository exerciseRepository;
        private readonly ITrainingRepository trainingRepository;
        private readonly IWorkoutFormRepository workoutFormRepository;
        private readonly IWorkoutRepository workoutRepository;

        public ExercisesController(IExerciseRepository exerciseRepository, ITrainingRepository trainingRepository, IWorkoutFormRepository workoutFormRepository, IWorkoutRepository workoutRepository)
        {
            this.exerciseRepository = exerciseRepository;
            this.trainingRepository = trainingRepository;
            this.workoutFormRepository = workoutFormRepository;
            this.workoutRepository = workoutRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ExerciseModel>>> Get()
        {
            try
            {
                return Ok(await exerciseRepository.GetAllExercises());

            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get exercises");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<ExerciseModel>>> Get(int id)
        {
            try
            {
                var exercise = await exerciseRepository.GetExercise(id);
                if (exercise != null)
                {
                    return Ok(exercise);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get exercise");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ExerciseModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Model = await exerciseRepository.AddExercise(model);
                    return Created($"/api/exercises/{Model.ExerciseId}", Model);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch
            {
                return BadRequest("Failed to add a new exercise");
            }
        }
    }
}