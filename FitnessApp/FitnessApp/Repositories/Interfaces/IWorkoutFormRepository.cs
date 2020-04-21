using FitnessApp.DatabaseClasses;
using FitnessApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Repositories
{
    public interface IWorkoutFormRepository
    {
        Task<List<WorkoutFormModel>> GetForms(int trainingId, string userId);
        WorkoutFormModel CreateWorkoutFormModel(WorkoutModel workout, string userId);
        Task<WorkoutForm> CreateWorkoutForm(WorkoutFormModel workoutForm, string userId);
        Task CreateTotalWorkout(WorkoutFormModel workoutForm, string userId);
        Task<PerformedExercise> CreatePerformedExercise(PerformedExerciseModel exercise, int workoutFormId);
        Task<WorkoutFormModel> GetLastWorkoutFormById(int id);
    }
}