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
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly ApplicationDbContext context;

        public ExerciseRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<ExerciseModel>> GetAllExercises()
        {
            var exerciseEntities = await context.Exercises.ToListAsync();
            var exercises = new List<ExerciseModel>();
            foreach (Exercise exercise in exerciseEntities)
            {
                ExerciseModel newModel = new ExerciseModel
                {
                    ExerciseId = exercise.ExerciseId,
                    Name = exercise.Name,
                    Discription = exercise.Discription,
                    MuscleGroup = exercise.MuscleGroup
                };
                exercises.Add(newModel);
            }
            return exercises;
        }

        public async Task AddExercise(ExerciseModel exercise)
        {
            var Exercise = new Exercise()
            {
                Name = exercise.Name,
                Discription = exercise.Discription,
                MuscleGroup = exercise.MuscleGroup
            };

            context.Exercises.Add(Exercise);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int exerciseId)
        {
            var entity = await context.Exercises.SingleAsync(m => m.ExerciseId == exerciseId);
            context.Exercises.Remove(entity);
            await context.SaveChangesAsync();
            
        }
    }
}
