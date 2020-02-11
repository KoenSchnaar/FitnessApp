using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Models
{
    public class PerformedExerciseModel
    {
        public int PerformedExerciseId { get; set; }
        public int ExerciseId { get; set; }
        public int WorkoutFormId { get; set; }
        public string Name { get; set; }
        public int Sets { get; set; }
        public List<RepsOfExerciseModel> Reps { get; set; }
    }
}
