using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.DatabaseClasses
{
    public class ExerciseSets
    {
        public int ExerciseSetsId { get; set; }
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        public int WorkoutId { get; set; }
        public Workout Workout { get; set; }
        public int Reps { get; set; }
        public int WeightKG { get; set; }
        public double WeightLBS { get { return WeightKG * 2.20462262; } }
    }
}
