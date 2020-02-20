using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Models
{
    public class ExerciseModel
    {
        public int ExerciseId { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public string MuscleGroup { get; set; }
        public int NrOfSets { get; set; }
        public List<SetModel> Sets { get; set; }
    }
}
