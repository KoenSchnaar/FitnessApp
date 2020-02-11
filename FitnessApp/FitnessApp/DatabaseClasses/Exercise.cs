using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.DatabaseClasses
{
    public class Exercise
    {
        public int ExerciseId { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public string MuscleGroup { get; set; }
    }
}
