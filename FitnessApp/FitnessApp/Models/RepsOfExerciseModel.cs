using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Models
{
    public class RepsOfExerciseModel
    {
        public int RepsOfExerciseId { get; set; }
        public int PerformedExerciseId { get; set; }
        public int Reps { get; set; }
        public int WeightKG { get; set; }
        public double WeightLBS { get { return WeightKG * 2.20462262; } }
    }
}
