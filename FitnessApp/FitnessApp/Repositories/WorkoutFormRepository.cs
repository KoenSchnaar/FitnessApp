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
    }
}
