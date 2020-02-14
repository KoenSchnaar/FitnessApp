using FitnessApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Repositories
{
    public interface IExerciseRepository
    {
        Task<List<ExerciseModel>> GetAllExercises();
        Task AddExercise(ExerciseModel exercise);
        Task Delete(int exerciseId);
    }
}