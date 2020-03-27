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
        private readonly IWorkoutFormRepository workoutFormRepo;
        private readonly IWorkoutRepository workoutRepo;

        public WorkoutController(IExerciseRepository ExerciseRepo,
            IWorkoutFormRepository workoutFormRepo,
            IWorkoutRepository workoutRepo
            )
        {
            exerciseRepo = ExerciseRepo;
            this.workoutFormRepo = workoutFormRepo;
            this.workoutRepo = workoutRepo;
        }
        public async Task<IActionResult> CreateWorkout1()
        {
            var exercises = await exerciseRepo.GetAllExercises();
            return View(exercises);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkout1(List<int> selectedExercises, string name, string muscleGroup)
        {
            var workoutID = await workoutRepo.CreateWorkout(selectedExercises, name, muscleGroup);
            return RedirectToAction("CreateWorkout2", new { workoutId = workoutID });
        }

        public async Task<IActionResult> CreateWorkout2(int workoutId)
        {
            var exercises = await workoutRepo.GetWorkout(workoutId);
            return View(exercises);
        }

        [HttpPost]
        public ActionResult CreateWorkout2(WorkoutModel workout)
        {
            workoutRepo.CreateNrOfSets(workout);
            return RedirectToAction("CreateWorkout3", new { workoutId = workout.WorkoutModelId });
        }

        public async Task<IActionResult> CreateWorkout3(int workoutId)
        {
            var workout = await workoutRepo.GetWorkout(workoutId);
            return View(workout);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkout3(WorkoutModel workout)
        {
            workoutRepo.AddReps(workout);
            return RedirectToAction("CreateWorkout4", new { workoutId = workout.WorkoutModelId });
        }

        public async Task<IActionResult> CreateWorkout4(int workoutId)
        {
            var workout = await workoutRepo.GetWorkout(workoutId);
            return View(workout);
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

        public async Task<IActionResult> DeleteWorkout(int workoutId)
        {
            await workoutRepo.DeleteWorkout(workoutId);
            return RedirectToAction("ShowWorkouts");
        }

        public async Task<IActionResult> EditWorkout(int workoutId)
        {
            var workout = await workoutRepo.GetWorkout(workoutId);
            return View(workout);
        }

        [HttpPost]
        public async Task<IActionResult> EditWorkout(WorkoutModel workoutMdl)
        {
            await workoutRepo.EditWorkout(workoutMdl);
            return RedirectToAction("ShowWorkouts");
        }

        public async Task<IActionResult> DeleteExercise(int workoutID, int exerciseId)
        {
            await workoutRepo.DeleteExercise(workoutID, exerciseId);
            return RedirectToAction("ShowWorkout", new { workoutId = workoutID });
        }

        public async Task<IActionResult> UseWorkout(int workoutId)
        {
            ViewBag.LastWorkout = await workoutFormRepo.GetLastWorkoutFormById(workoutId);
            var workout = await workoutRepo.GetWorkout(workoutId);
            var newWorkoutForm = workoutFormRepo.CreateWorkoutFormModel(workout);
            return View(newWorkoutForm);
        }

        [HttpPost]
        public async Task<IActionResult> UseWorkout(WorkoutFormModel workoutForm) 
        {
            await workoutFormRepo.CreateTotalWorkout(workoutForm);
            return RedirectToAction("ShowSchedules", "Training");
        }
    }
}