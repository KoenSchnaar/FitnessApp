using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Models
{
    public class ExerciseModel
    {
        public int ExerciseId { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Discription { get; set; }

        [Required]
        public string MuscleGroup { get; set; }
        public int NrOfSets { get; set; }
        public List<SetModel> Sets { get; set; }
    }
}
