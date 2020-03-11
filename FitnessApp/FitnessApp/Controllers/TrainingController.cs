using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public TrainingController(IExerciseRepository ExerciseRepo,
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

        public async Task<IActionResult> ShowSchedules()
        {
            return View();
        }

        public async Task<IActionResult> AddSchedule()
        {
            return View();
        }
    }
}