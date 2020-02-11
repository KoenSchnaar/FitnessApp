using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Models
{
    public class WorkoutFormModel
    {
        public int WorkoutFormId { get; set; }
        public string UserId { get; set; }
        public List<PerformedExerciseModel> PerformedExercises { get; set; }
        public UserModel User { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
