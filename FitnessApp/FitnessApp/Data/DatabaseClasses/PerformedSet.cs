using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.DatabaseClasses
{
    public class PerformedSet
    {
        public int PerformedSetId { get; set; }
        public int PerformedExerciseId { get; set; }
        public PerformedExercise PerformedExercise { get; set; }
        public int Reps { get; set; }
        public int WeightKG { get; set; }
    }
}
