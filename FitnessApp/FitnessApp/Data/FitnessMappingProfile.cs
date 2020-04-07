using AutoMapper;
using FitnessApp.DatabaseClasses;
using FitnessApp.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Data
{
    public class FitnessMappingProfile : Profile
    {
        public FitnessMappingProfile()
        {
            CreateMap<Exercise, ExerciseModel>()
                .ReverseMap();

            CreateMap<Workout, WorkoutModel>()
                .ReverseMap();

            CreateMap<WorkoutForm, WorkoutFormModel>()
                .ReverseMap();

            CreateMap<IdentityUser, UserModel>()
                .ReverseMap();

            CreateMap<TrainingSchedule, TrainingModel>()
                .ForMember(t => t.NrOfTrainingDays, ex => ex.MapFrom(t => t.Days))
                .ReverseMap();

            CreateMap<PerformedSet, PerformedSetModel>()
                .ReverseMap();

            CreateMap<PerformedExercise, PerformedExerciseModel>()
                .ReverseMap();

            //CreateMap<ExerciseSets, SetModel>()
            //    .ReverseMap();
        }
    }
}
