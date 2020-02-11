using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.DatabaseClasses
{
    public class WorkoutForm
    {
        public int WorkoutFormId { get; set; }
        public IdentityUser User { get; set; }
        public string UserId { get; set; }
        public List<PerformedExercise> PerformedExercises { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }


    }
}
