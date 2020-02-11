using FitnessApp.Data;
using FitnessApp.DatabaseClasses;
using FitnessApp.Models;
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

        public async Task<List<ExerciseModel>> GetExercises()
        {
            return null;
        }
    }
}
