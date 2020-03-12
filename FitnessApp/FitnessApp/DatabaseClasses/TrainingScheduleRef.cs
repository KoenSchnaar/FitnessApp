using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.DatabaseClasses
{
    public class TrainingScheduleRef
    {
        public int TrainingScheduleRefId { get; set; }
        public Workout Workout { get; set; }
        public int WorkoutId { get; set; }
        public TrainingSchedule TrainingSchedule { get; set; }
        public int TrainingScheduleId { get; set; }
    }
}
