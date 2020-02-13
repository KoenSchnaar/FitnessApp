using FitnessApp.Data;
using FitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Repositories
{
    public class RepsOfExerciseRepository : IRepsOfExerciseRepository
    {
        private readonly ApplicationDbContext context;

        public RepsOfExerciseRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<RepsOfExerciseModel>> GetReps()
        {
            return null;
        }
    }
}
