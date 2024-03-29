﻿using FitnessApp.Data;
using FitnessApp.DatabaseClasses;
using FitnessApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Repositories
{
    public class WorkoutFormRepository : IWorkoutFormRepository
    {
        private readonly ApplicationDbContext context;

        public WorkoutFormRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public WorkoutFormModel EntityToModel(WorkoutForm form)
        {
            WorkoutFormModel model = new WorkoutFormModel()
            {
                WorkoutFormId = form.WorkoutFormId,
                workoutId = form.WorkoutId,
                UserId = form.UserId,
                Day = form.Day,
                Month = form.Month,
                Year = form.Year
            };
            return model;
        }

        public async Task<List<WorkoutFormModel>> GetForms(int trainingId, string userId)
        {
            var trainingScheduleRefs = await context.trainingScheduleRefs.Where(t => t.TrainingScheduleId == trainingId).ToListAsync();
            var workoutForms = new List<WorkoutFormModel>();
            if (userId != null)
            {
                foreach(var workout in trainingScheduleRefs)
                {
                    var forms = await context.WorkoutForms.Where(forms => forms.UserId == userId && forms.WorkoutId == workout.WorkoutId).ToListAsync();
                    foreach(var form in forms)
                    {
                        var formModel = EntityToModel(form);
                        workoutForms.Add(formModel);
                    }
                }
            }
            //else
            //{
            //    foreach (var workout in trainingScheduleRefs)
            //    {
            //        var workoutForms = await context.WorkoutForms.Where(forms => forms.WorkoutId == workout.WorkoutId).ToListAsync();
            //    }
            //}
            return workoutForms;
        }

        public WorkoutFormModel CreateWorkoutFormModel(WorkoutModel workout, string userId)
        {
            var workoutForm = new WorkoutFormModel
            {
                UserId = userId,
                workoutId = workout.WorkoutModelId,
                Day = DateTime.Now.Day,
                Month = DateTime.Now.Month,
                Year = DateTime.Now.Year
            };

            var exercises = new List<PerformedExerciseModel>();

            foreach(var exercise in workout.Exercises)
            {
                var PerformedExercise = new PerformedExerciseModel()
                {
                    ExerciseId = exercise.ExerciseId,
                    Name = exercise.Name,
                    NumberOfSets = exercise.Sets.Count()
                };
                exercises.Add(PerformedExercise);
            }
            workoutForm.HighestSets = workout.HighestSets;
            workoutForm.PerformedExercises = exercises;

            return workoutForm;
        }

        public async Task<WorkoutFormModel> GetLastWorkoutFormById(int id)
        {
            var workoutForms = await context.WorkoutForms.Where(m => m.WorkoutId == id).ToListAsync();

            if (workoutForms.Count() != 0)
            {
                var workoutForm = workoutForms.Last();

                var workoutFormMdl = new WorkoutFormModel()
                {
                    WorkoutFormId = workoutForm.WorkoutFormId,
                    workoutId = workoutForm.WorkoutId,
                    Day = workoutForm.Day,
                    Month = workoutForm.Month,
                    Year = workoutForm.Year
                };

                var pExercises = await context.PerformedExercises.Where(m => m.WorkoutFormId == workoutForm.WorkoutFormId).ToListAsync();
                var pExerciseMdls = new List<PerformedExerciseModel>();

                foreach (var exercise in pExercises)
                {
                    var pExerciseMdl = new PerformedExerciseModel()
                    {
                        PerformedExerciseId = exercise.PerformedExerciseId,
                        ExerciseId = exercise.ExerciseId,
                        WorkoutFormId = exercise.WorkoutFormId,
                        Name = exercise.Name,
                        NumberOfSets = exercise.NumberOfSets
                    };

                    var pSets = await context.PerformedSets.Where(m => m.PerformedExerciseId == exercise.PerformedExerciseId).ToListAsync();
                    var pSetMdls = new List<PerformedSetModel>();

                    foreach (var set in pSets)
                    {
                        var pSetMdl = new PerformedSetModel()
                        {
                            PerformedSetId = set.PerformedSetId,
                            PerformedExerciseId = set.PerformedExerciseId,
                            Reps = set.Reps,
                            WeightKG = set.WeightKG
                        };
                        pSetMdls.Add(pSetMdl);
                    }
                    pExerciseMdl.Sets = pSetMdls;
                    pExerciseMdls.Add(pExerciseMdl);
                }
                workoutFormMdl.PerformedExercises = pExerciseMdls;
                return workoutFormMdl;
            }
            else
            {
                return null;
            }
        }

        // this creates a workoutform and fills in the reps and weight of the exercises
        public async Task CreateTotalWorkout(WorkoutFormModel workoutForm, string userId)
        {
            var workout = await CreateWorkoutForm(workoutForm, userId);

            foreach(var exercise in workoutForm.PerformedExercises)
            {
                var performedExercise = await CreatePerformedExercise(exercise, workout.WorkoutFormId);

                foreach (var set in exercise.Sets)
                {
                    var performedSet = new PerformedSet()
                    {
                        PerformedExerciseId = performedExercise.PerformedExerciseId,
                        Reps = set.Reps,
                        WeightKG = set.WeightKG
                    };
                    context.PerformedSets.Add(performedSet);
                }
            }
            await context.SaveChangesAsync();
        }

        // creates an empty workoutForm
        public async Task<WorkoutForm> CreateWorkoutForm(WorkoutFormModel workoutForm, string userId)
        {
            var workout = new WorkoutForm()
            {
                UserId = userId,
                WorkoutId = workoutForm.workoutId,
                Day = DateTime.Now.Day,
                Month = DateTime.Now.Month,
                Year = DateTime.Now.Year
            };
            context.WorkoutForms.Add(workout);
            await context.SaveChangesAsync();
            return workout;
        }

        // Creates and fills in a performed exercise
        public async Task<PerformedExercise> CreatePerformedExercise(PerformedExerciseModel exercise, int workoutFormId)
        {
            var performedExercise = new PerformedExercise()
            {
                ExerciseId = exercise.ExerciseId,
                WorkoutFormId = workoutFormId,
                Name = exercise.Name,
                NumberOfSets = exercise.Sets.Count()
            };
            context.PerformedExercises.Add(performedExercise);
            await context.SaveChangesAsync();

            return performedExercise;
        }
    }
}
