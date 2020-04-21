using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.DatabaseClasses
{
    public class WorkoutRef
    {
        public int WorkoutRefId { get; set; }
        public Exercise Exercise { get; set; }
        public int ExerciseId { get; set; }
        public Workout Workout { get; set; }
        public int WorkoutId { get; set; }
    }
}
