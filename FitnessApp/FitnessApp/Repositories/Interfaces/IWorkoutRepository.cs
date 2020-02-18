using FitnessApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Repositories
{
    public interface IWorkoutRepository
    {
        Task AddWorkout(List<ExerciseModel> exercises, int workoutId);
        Task<List<WorkoutModel>> GetWorkouts();
        Task<WorkoutModel> GetWorkout(int workoutId);
        Task CreateWorkout(List<int> selectedExercises);
    }
}