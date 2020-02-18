using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessApp.Models;
using FitnessApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Controllers
{
    public class WorkoutController : Controller
    {
        private readonly IExerciseRepository exerciseRepo;
        private readonly IPerformedExerciseRepository performedExerciseRepo;
        private readonly IRepsOfExerciseRepository repsOfExerciseRepo;
        private readonly IWorkoutFormRepository workoutFormRepo;
        private readonly IWorkoutRepository workoutRepo;

        public WorkoutController(IExerciseRepository ExerciseRepo,
            IPerformedExerciseRepository performedExerciseRepo,
            IRepsOfExerciseRepository repsOfExerciseRepo,
            IWorkoutFormRepository workoutFormRepo,
            IWorkoutRepository workoutRepo
            )
        {
            exerciseRepo = ExerciseRepo;
            this.performedExerciseRepo = performedExerciseRepo;
            this.repsOfExerciseRepo = repsOfExerciseRepo;
            this.workoutFormRepo = workoutFormRepo;
            this.workoutRepo = workoutRepo;
        }
        public async Task<IActionResult> CreateWorkout()
        {
            var exercises = await exerciseRepo.GetAllExercises();
            return View(exercises);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkout(List<int> selectedExercises)
        {
            await workoutRepo.CreateWorkout(selectedExercises);
            return RedirectToAction("ShowWorkouts");
        }

        public async Task<IActionResult> ShowWorkouts()
        {
            var workouts = await workoutRepo.GetWorkouts();
            return View(workouts);
        }

        public async Task<IActionResult> ShowWorkout(int workoutId)
        {
            var workout = await workoutRepo.GetWorkout(workoutId);
            return View(workout);
        }
    }
}