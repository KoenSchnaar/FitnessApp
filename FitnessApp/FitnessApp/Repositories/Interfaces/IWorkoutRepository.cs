using FitnessApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Repositories
{
    public interface IWorkoutRepository
    {
        Task AddWorkout(List<ExerciseModel> exercises, int workoutId);
        Task<List<WorkoutModel>> GetWorkouts();
        Task<List<WorkoutModel>> GetWorkoutsByIds(List<int> workoutIds);
        Task<WorkoutModel> GetWorkout(int workoutId);
        Task<int> CreateWorkout(List<int> selectedExercises, string name, string muscleGroup);
        void CreateNrOfSets(WorkoutModel workout);
        public void AddReps(WorkoutModel workout);
        Task DeleteWorkout(int workoutId);
        Task DeleteExercise(int workoutId, int exerciseId);
    }
}