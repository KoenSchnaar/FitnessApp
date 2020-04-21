using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessApp.Models;
using FitnessApp.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Controllers
{
    public class TrainingController : Controller
    {
        private readonly IExerciseRepository exerciseRepo;
        private readonly IWorkoutFormRepository workoutFormRepo;
        private readonly IWorkoutRepository workoutRepo;
        private readonly ITrainingRepository trainingRepo;
        private readonly UserManager<IdentityUser> _userManager;

        public TrainingController(IExerciseRepository ExerciseRepo,
            IWorkoutFormRepository workoutFormRepo,
            IWorkoutRepository workoutRepo,
            ITrainingRepository trainingRepo,
            UserManager<IdentityUser> userManager = null
            )
        {
            exerciseRepo = ExerciseRepo;
            this.workoutFormRepo = workoutFormRepo;
            this.workoutRepo = workoutRepo;
            this.trainingRepo = trainingRepo;
            _userManager = userManager;
        }

        public async Task<IActionResult> ShowSchedules()
        {
            var schedules = await trainingRepo.GetAllSchedules();

            return View(schedules);
        }

        public async Task<IActionResult> ShowSchedule(int trainingScheduleId)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            ViewBag.OldForms = await workoutFormRepo.GetForms(trainingScheduleId, userId);
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
        public IActionResult AddSchedule1(TrainingModel training)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("AddSchedule2", training);
            }
            return View();
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

        public async Task<IActionResult> Edit(int trainingId)
        {
            var ids = await trainingRepo.GetWorkoutsIdsFromTraining(trainingId);
            var workouts = await workoutRepo.GetWorkoutsByIds(ids);
            var trainingSchedule = await trainingRepo.GetScheduleById(trainingId, workouts);
            return View(trainingSchedule);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TrainingModel schedule)
        {
            if (ModelState.IsValid)
            {
                await trainingRepo.Edit(schedule);
                TempData["Message"] = "You have succesfully changed your training schedule!";
                return RedirectToAction("ShowSchedules");
            }
            return View();

        }

        public async Task<IActionResult> Delete(int trainingId)
        {
            await trainingRepo.Delete(trainingId);
            return RedirectToAction("ShowSchedules");
        }
    }
}