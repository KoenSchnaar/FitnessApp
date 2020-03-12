using System;
using System.Collections.Generic;
using System.Text;
using FitnessApp.DatabaseClasses;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<WorkoutForm> WorkoutForms { get; set; }
        public DbSet<PerformedExercise> PerformedExercises { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutRef> WorkoutRefs { get; set; }
        public DbSet<ExerciseSets> ExerciseSets { get; set; }
        public DbSet<PerformedSet> PerformedSets { get; set; }
        public DbSet<TrainingSchedule> trainingSchedules { get; set; }
        public DbSet<TrainingScheduleRef> trainingScheduleRefs { get; set; }
    }
}
