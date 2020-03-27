using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Models
{
    public class TrainingModel
    {
        public int TrainingModelId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required] [Range(0, 7)] [Display(Name = "Training days")]
        public int NrOfTrainingDays { get; set; }

        public List<WorkoutModel> Workouts { get; set; }
        
    }
}
