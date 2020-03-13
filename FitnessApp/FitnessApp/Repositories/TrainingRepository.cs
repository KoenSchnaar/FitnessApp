using FitnessApp.Data;
using FitnessApp.DatabaseClasses;
using FitnessApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Repositories
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly ApplicationDbContext context;

        public TrainingRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<TrainingSchedule> CreateSchedule(int days, string name)
        {
            TrainingSchedule training = new TrainingSchedule();
            training.Name = name;
            training.Days = days;

            context.trainingSchedules.Add(training);
            await context.SaveChangesAsync();

            return training;
        }

        public async Task<int> AddSchedule(List<WorkoutModel> workouts, int days, string name)
        {
            var training = await CreateSchedule(days, name);

            foreach(var workout in workouts)
            {
                TrainingScheduleRef scheduleRef = new TrainingScheduleRef();
                scheduleRef.TrainingScheduleId = training.TrainingScheduleId;
                scheduleRef.WorkoutId = workout.WorkoutModelId;
                context.trainingScheduleRefs.Add(scheduleRef);
            }
            await context.SaveChangesAsync();

            return training.TrainingScheduleId;
        }

        public async Task<List<int>> GetWorkoutsIdsFromTraining(int trainingId)
        {
            var ints = new List<int>();
            var workouts = await context.trainingScheduleRefs.Where(m => m.TrainingScheduleId == trainingId).ToListAsync();

            foreach (var workout in workouts)
            {
                var id = workout.WorkoutId;
                ints.Add(id);
            }

            return ints;
        }

        public async Task<TrainingModel> GetScheduleById(int trainingSceduleId, List<WorkoutModel> workoutMdls)
        {
            var training = await context.trainingSchedules.SingleAsync(m => m.TrainingScheduleId == trainingSceduleId);

            var trainingMdl = new TrainingModel
            {
                TrainingModelId = training.TrainingScheduleId,
                Name = training.Name,
                NrOfTrainingDays = training.Days,
                Workouts = workoutMdls
            };

            return trainingMdl;
        }


        public async Task<List<TrainingModel>> GetAllSchedules()
        {
            var schedules = new List<TrainingModel>();
            var scheduleEntities = await context.trainingSchedules.ToListAsync();
            
            foreach(var entity in scheduleEntities)
            {
                var trainingMdl = new TrainingModel
                {
                    TrainingModelId = entity.TrainingScheduleId,
                    Name = entity.Name,
                    NrOfTrainingDays = entity.Days,
                    Workouts = new List<WorkoutModel>()
                };
                var refs = await context.trainingScheduleRefs.Where(m => m.TrainingScheduleId == entity.TrainingScheduleId).ToListAsync();
                foreach(var trainingRef in refs)
                {
                    var workoutMdl = new WorkoutModel()
                    {
                        WorkoutModelId = trainingRef.WorkoutId
                    };
                    trainingMdl.Workouts.Add(workoutMdl);
                }
                schedules.Add(trainingMdl);
            }
            return schedules;
        }
    }
}
