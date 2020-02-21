using FitnessApp.Data;
using FitnessApp.Models;
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

        public async Task<WorkoutFormModel> CreateWorkoutForm(WorkoutModel workout)
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
                    Sets = exercise.Sets.Count()
                };
                exercises.Add(PerformedExercise);
            }
            workoutForm.HighestSets = workout.HighestSets;
            workoutForm.PerformedExercises = exercises;

            return workoutForm;
        }
    }
}
