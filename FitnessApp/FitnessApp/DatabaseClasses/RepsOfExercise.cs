using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.DatabaseClasses
{
    public class RepsOfExercise
    {
        public int RepsOfExerciseId { get; set; }
        public PerformedExercise Exercise { get; set; }
        public int PerformedExerciseId { get; set; }
        public int Reps { get; set; }
        public int WeightKG { get; set; }
        public double WeightLBS { get { return WeightKG * 2.20462262; } }
    }
}
