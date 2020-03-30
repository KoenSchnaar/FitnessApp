using FitnessApp.Data;
using FitnessApp.DatabaseClasses;
using FitnessApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment he;

        public ExerciseRepository(ApplicationDbContext context, IWebHostEnvironment he)
        {
            this.context = context;
            this.he = he;
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

                if (exercise.ImagePath != null)
                {
                    newModel.ImagePath = exercise.ImagePath;
                };

                exercises.Add(newModel);
            }
            return exercises;
        }

        public async Task<ExerciseModel> GetExercise(int exerciseId)
        {

            var entity = await context.Exercises.SingleAsync(e => e.ExerciseId == exerciseId);

            ExerciseModel newModel = new ExerciseModel
            {
                ExerciseId = entity.ExerciseId,
                Name = entity.Name,
                Discription = entity.Discription,
                MuscleGroup = entity.MuscleGroup,
                ImagePath = entity.ImagePath
            };

            if(entity.ImagePath != null)
            {
                newModel.ImagePath = entity.ImagePath;
            }

            return newModel;
        }

        public async Task<List<ExerciseModel>> GetExercisesById(List<int> exerciseId)
        {
            var exerciseEntities = new List<Exercise>();
            foreach (var id in exerciseId)
            {
                var entity = await context.Exercises.SingleAsync(e => e.ExerciseId == id);
                exerciseEntities.Add(entity);
            }

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

                if (exercise.ImagePath != null)
                {
                    newModel.ImagePath = exercise.ImagePath;
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
                MuscleGroup = exercise.MuscleGroup,
                ImagePath = exercise.ImagePath
            };

            context.Exercises.Add(Exercise);
            await context.SaveChangesAsync();
        }

        public async Task Edit(ExerciseModel exercise)
        {
            var Exercise = await context.Exercises.SingleOrDefaultAsync(m => m.ExerciseId == exercise.ExerciseId);

            Exercise.Name = exercise.Name;
            Exercise.Discription = exercise.Discription;
            Exercise.MuscleGroup = exercise.MuscleGroup;
            Exercise.ImagePath = exercise.ImagePath;


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
