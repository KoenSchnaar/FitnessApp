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
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly ApplicationDbContext context;

        public WorkoutRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddWorkout(List<ExerciseModel> exercises, int workoutId)
        {
            foreach (var exercise in exercises) {
                var workoutRef = new WorkoutRef()
                {
                    ExerciseId = exercise.ExerciseId,
                    WorkoutId = workoutId
                };
                context.WorkoutRefs.Add(workoutRef);
            };
            await context.SaveChangesAsync();
        }

        public async Task<List<WorkoutModel>> GetWorkouts()
        {
            var workouts = await context.Workouts.ToListAsync();
            var workoutModels = new List<WorkoutModel>();

            foreach(var workout in workouts)
            {
                var workoutMdl = new WorkoutModel()
                {
                    WorkoutModelId = workout.WorkoutId,
                    Name = workout.Name,
                    MuscleGroup = workout.MuscleGroup
                };

                var workoutRefs = await context.WorkoutRefs.Where(m => m.WorkoutId == workout.WorkoutId).ToListAsync();
                var exercises = new List<Exercise>();

                foreach (var workoutRef in workoutRefs)
                {
                    var exercise = await context.Exercises.SingleAsync(m => m.ExerciseId == workoutRef.ExerciseId);
                    exercises.Add(exercise);
                }

                var exerciseModels = new List<ExerciseModel>();
                
                foreach(var exercise in exercises)
                {
                    var exerciseModel = new ExerciseModel()
                    {
                        ExerciseId = exercise.ExerciseId,
                        Name = exercise.Name,
                        Discription = exercise.Discription,
                        MuscleGroup = exercise.MuscleGroup
                    };
                    exerciseModels.Add(exerciseModel);
                }

                workoutMdl.Exercises = exerciseModels;
                workoutModels.Add(workoutMdl);
            }
            return workoutModels;
        }

        public async Task<WorkoutModel> GetWorkout(int workoutId)
        {
            return null;
        }
    }
}
