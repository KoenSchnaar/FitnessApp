using FitnessApp.DatabaseClasses;
using FitnessApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Repositories
{
    public interface ITrainingRepository
    {
        Task<TrainingSchedule> CreateSchedule(int days, string name);
        Task<int> AddSchedule(List<WorkoutModel> workouts, int days, string name);
        Task<TrainingModel> GetScheduleById(int trainingSceduleId, List<WorkoutModel> workoutMdls);
        Task<List<int>> GetWorkoutsIdsFromTraining(int trainingId);
        Task<List<TrainingModel>> GetAllSchedules();
    }
}