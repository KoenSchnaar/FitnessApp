using FitnessApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Repositories
{
    public class TrainingRepository
    {
        private readonly ApplicationDbContext context;

        public TrainingRepository(ApplicationDbContext context)
        {
            this.context = context;
        }


    }
}
