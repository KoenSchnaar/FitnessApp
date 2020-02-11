using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly IExerciseRepository exerciseRepo;
        private readonly IPerformedExerciseRepository performedExerciseRepo;
        private readonly IRepsOfExerciseRepository repsOfExerciseRepo;
        private readonly IWorkoutFormRepository workoutFormRepo;

        public ExerciseController(IExerciseRepository ExerciseRepo,
            IPerformedExerciseRepository performedExerciseRepo,
            IRepsOfExerciseRepository repsOfExerciseRepo,
            IWorkoutFormRepository workoutFormRepo
            )
        {
            exerciseRepo = ExerciseRepo;
            this.performedExerciseRepo = performedExerciseRepo;
            this.repsOfExerciseRepo = repsOfExerciseRepo;
            this.workoutFormRepo = workoutFormRepo;
        }

        public async Task<IActionResult> Exercises()
        {
            var exercises = await exerciseRepo.GetAllExercises();
            return View(exercises);
        }
    }
}