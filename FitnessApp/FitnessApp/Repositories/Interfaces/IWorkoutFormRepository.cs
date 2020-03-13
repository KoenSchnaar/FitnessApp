using FitnessApp.DatabaseClasses;
using FitnessApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Repositories
{
    public interface IWorkoutFormRepository
    {
        Task<List<WorkoutFormModel>> GetForms();
        WorkoutFormModel CreateWorkoutFormModel(WorkoutModel workout);
        Task CreateTotalWorkout(WorkoutFormModel workoutForm);
        Task<PerformedExercise> CreatePerformedExercise(PerformedExerciseModel exercise, int workoutFormId);
        Task<WorkoutFormModel> GetLastWorkoutFormById(int id);
    }
}