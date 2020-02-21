using FitnessApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Repositories
{
    public interface IWorkoutFormRepository
    {
        Task<List<WorkoutFormModel>> GetForms();
        Task<WorkoutFormModel> CreateWorkoutForm(WorkoutModel workout);
    }
}