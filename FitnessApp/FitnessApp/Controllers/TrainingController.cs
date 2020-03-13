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
        private readonly IWorkoutFormRepository workoutFormRepo;
        private readonly IWorkoutRepository workoutRepo;
        private readonly ITrainingRepository trainingRepo;

        public TrainingController(IExerciseRepository ExerciseRepo,
            IWorkoutFormRepository workoutFormRepo,
            IWorkoutRepository workoutRepo,
            ITrainingRepository trainingRepo
            )
        {
            exerciseRepo = ExerciseRepo;
            this.workoutFormRepo = workoutFormRepo;
            this.workoutRepo = workoutRepo;
            this.trainingRepo = trainingRepo;
        }

        public async Task<IActionResult> ShowSchedules()
        {
            var schedules = await trainingRepo.GetAllSchedules();

            return View(schedules);
        }

        public async Task<IActionResult> ShowSchedule(int trainingScheduleId)
        {
            var ids = await trainingRepo.GetWorkoutsIdsFromTraining(trainingScheduleId);
            var workouts = await workoutRepo.GetWorkoutsByIds(ids);
            var schedule = await trainingRepo.GetScheduleById(trainingScheduleId, workouts);
            return View(schedule);
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

        public async Task<IActionResult> AddSchedule2(TrainingModel training)
        {
            ViewBag.Training = training;
            var workouts = await workoutRepo.GetWorkouts();
            return View(workouts);
        }

        [HttpPost]
        public async Task<IActionResult> AddSchedule2(List<int> selectedWorkouts, int days, string name)
        {
            var workouts = await workoutRepo.GetWorkoutsByIds(selectedWorkouts);
            var trainingScheduleId = await trainingRepo.AddSchedule(workouts, days, name);
            return RedirectToAction("AddSchedule3", new { trainingId = trainingScheduleId});
        }

        public async Task<IActionResult> AddSchedule3(int trainingId)
        {
            var ids = await trainingRepo.GetWorkoutsIdsFromTraining(trainingId);
            var workouts = await workoutRepo.GetWorkoutsByIds(ids);
            var trainingSchedule = await trainingRepo.GetScheduleById(trainingId, workouts);
            return View(trainingSchedule);
        }
    }
}