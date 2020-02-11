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

        public DbSet<WorkoutForm> workoutForms { get; set; }
        public DbSet<PerformedExercise> workoutFormRows { get; set; }
        public DbSet<RepsOfExercise> repsOfExercises { get; set; }
        public DbSet<Exercise> exercises { get; set; }
    }
}
