using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.DatabaseClasses
{
    public class TrainingSchedule
    {
        public int TrainingScheduleId { get; set; }
        public string Name { get; set; }
        public int Days { get; set; }
    }
}
