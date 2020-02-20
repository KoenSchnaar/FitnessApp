using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.DatabaseClasses
{
    public class ExerciseReps
    {
        public int ExerciseRepsId { get; set; }
        public int ExerciseSetsId { get; set; }
        public ExerciseSets ExerciseSets { get; set; }
        public int Reps { get; set; }
        public int WeightKG { get; set; }
        public double WeightLBS { get { return WeightKG * 2.20462262; } }

    }
}
