using FitnessApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Repositories
{
    public interface IRepsOfExerciseRepository
    {
        Task<List<RepsOfExerciseModel>> GetReps();
    }
}