using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessApp.Models;
using FitnessApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Controllers
{
    public class TrainingController : Controller
    {
        private readonly IExerciseRepository exerciseRepo;
        private readonly IPerformedExerciseRepository performedExerciseRepo;
        private readonly IRepsOfExerciseRepository repsOfExerciseRepo;
        private readonly IWorkoutFormRepository workoutFormRepo;
        private readonly IWorkoutRepository workoutRepo;

        public TrainingController(IExerciseRepository ExerciseRepo,
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

        public async Task<IActionResult> ShowSchedules()
        {
            return View();
        }

        public IActionResult AddSchedule1()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSchedule1(TrainingModel training)
        {
            return RedirectToAction("AddSchedule2", training);
        }

        public async Task<IActionResult> AddSchedule2(TrainingModel test)
        {
            //ViewBag.Training = training;
            var workouts = await workoutRepo.GetWorkouts();
            return View(workouts);
        }

        [HttpPost]
        public async Task<IActionResult> AddSchedule2(List<int> selectedExercises, TrainingModel training)
        {
            return RedirectToAction("AddSchedule3", new { workoutIds = selectedExercises });
        }

        public async Task<IActionResult> AddSchedule3(List<int> workoutIds)
        {
            var workouts = await workoutRepo.GetWorkoutsById(workoutIds);
            return View(workouts);
        }
    }
}