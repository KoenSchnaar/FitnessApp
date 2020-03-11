using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Models
{
    public class TrainingModel
    {
        public int TrainingModelId { get; set; }
        public string Name { get; set; }
        public List<WorkoutModel> Workouts { get; set; }
    }
}
