using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Models
{
    public class WorkoutModel
    {
        public int WorkoutModelId { get; set; }
        public string Name { get; set; }
        public string MuscleGroup { get; set; }
        public List<ExerciseModel> Exercises { get; set; }
        public int HighestSets { get; set; }

    }
}
