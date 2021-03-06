﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FitnessApp.FileTransfers;
using FitnessApp.Models;
using FitnessApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly IExerciseRepository exerciseRepo;
        private readonly IWorkoutFormRepository workoutFormRepo;
        private readonly IMapper mapper;

        public ExerciseController(IExerciseRepository ExerciseRepo,
            IWorkoutFormRepository workoutFormRepo,
            IMapper mapper
            )
        {
            exerciseRepo = ExerciseRepo;
            this.workoutFormRepo = workoutFormRepo;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Exercises()
        {
            var exercises = await exerciseRepo.GetAllExercises();
            return View(exercises);
        }

        public async Task<IActionResult> ExercisesAngular()
        {
            var exercises = await exerciseRepo.GetAllExercises();
            return View(exercises);
        }
       
        public ActionResult Add()
        {
            return View(new ExerciseModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(ExerciseModel exercise)
        {
            if (ModelState.IsValid)
            {
                if (exercise.ImageUpload != null)
                {
                    Upload upload = new Upload();
                    var completeMdl = upload.UploadPicture(exercise);
                    await exerciseRepo.AddExercise(completeMdl);
                }
                else
                {
                    await exerciseRepo.AddExercise(exercise);
                }
                return RedirectToAction("Add");
            }
            return View();
        }

        public async Task<IActionResult> Edit(int exerciseId)
        {
            var exercise = await exerciseRepo.GetExercise(exerciseId);
            if(exercise == null)
            {
                return NotFound();
            }
            return View(exercise);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ExerciseModel exercise)
        {
            if (ModelState.IsValid)
            {
                await exerciseRepo.Edit(exercise);
                TempData["Message"] = "You have succesfully changed the exercise!";
                return RedirectToAction("Exercises");
            }
            return View(exercise);
        }

        public async Task<IActionResult> Delete(int exerciseId)
        {
            await exerciseRepo.Delete(exerciseId);
            return RedirectToAction("Exercises");
        }

        public async Task<IActionResult> ShowExercise(int exerciseId)
        {
            var exercise = await exerciseRepo.GetExercise(exerciseId);
            return View(exercise);
        }
    }
}