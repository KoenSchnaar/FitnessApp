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
        public DbSet<RepsOfExercise> RepsOfExercises { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
    }
}
