using FitnessApp.Data;
using FitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Repositories
{
    public class PerformedExerciseRepository : IPerformedExerciseRepository
    {
        private readonly ApplicationDbContext context;

        public PerformedExerciseRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<PerformedExerciseModel>> GetExercises()
        {
            return null;
        }
    }
}
