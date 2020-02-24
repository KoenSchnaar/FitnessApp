using FitnessApp.Data;
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

        public async Task<List<WorkoutFormModel>> GetForms()
        {
            return null;
        }

        public WorkoutFormModel CreateWorkoutFormModel(WorkoutModel workout)
        {
            var workoutForm = new WorkoutFormModel
            {
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

        public async Task CreateTotalWorkout(WorkoutFormModel workoutForm)
        {
            var workout = await CreateWorkoutForm(workoutForm);

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

        public async Task<WorkoutForm> CreateWorkoutForm(WorkoutFormModel workoutForm)
        {
            var workout = new WorkoutForm()
            {
                WorkoutId = workoutForm.workoutId,
                Day = DateTime.Now.Day,
                Month = DateTime.Now.Month,
                Year = DateTime.Now.Year
            };
            context.WorkoutForms.Add(workout);
            await context.SaveChangesAsync();
            return workout;
        }

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
