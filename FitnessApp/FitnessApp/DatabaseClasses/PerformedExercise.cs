using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.DatabaseClasses
{
    public class PerformedExercise
    {
        public int PerformedExerciseId { get; set; }
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        public WorkoutForm WorkoutForm { get; set; }
        public int WorkoutFormId { get; set; }
        public string Name { get; set; }
        public int Sets { get; set; }
        public List<RepsOfExercise> Reps { get; set; }
    }
}
