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
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly ApplicationDbContext context;

        public WorkoutRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddWorkout(List<ExerciseModel> exercises, int workoutId)
        {
            foreach (var exercise in exercises) {
                var workoutRef = new WorkoutRef()
                {
                    ExerciseId = exercise.ExerciseId,
                    WorkoutId = workoutId
                };
                context.WorkoutRefs.Add(workoutRef);
            };
            await context.SaveChangesAsync();
        }

        public async Task EditWorkout(WorkoutModel workoutMdl)
        {
            var workout = await context.Workouts.SingleOrDefaultAsync(m => m.WorkoutId == workoutMdl.WorkoutModelId);

            workout.Name = workoutMdl.Name;
            workout.MuscleGroup = workoutMdl.MuscleGroup;

            await context.SaveChangesAsync();
        }

        public async Task<List<WorkoutModel>> GetWorkouts()
        {
            var workouts = await context.Workouts.ToListAsync();
            var workoutModels = new List<WorkoutModel>();

            foreach(var workout in workouts)
            {
                var workoutMdl = new WorkoutModel()
                {
                    WorkoutModelId = workout.WorkoutId,
                    Name = workout.Name,
                    MuscleGroup = workout.MuscleGroup
                };

                var workoutRefs = await context.WorkoutRefs.Where(m => m.WorkoutId == workout.WorkoutId).ToListAsync();
                var exercises = new List<Exercise>();

                foreach (var workoutRef in workoutRefs)
                {
                    var exercise = await context.Exercises.SingleAsync(m => m.ExerciseId == workoutRef.ExerciseId);
                    exercises.Add(exercise);
                }

                var exerciseModels = new List<ExerciseModel>();
                
                foreach(var exercise in exercises)
                {
                    var exerciseModel = new ExerciseModel()
                    {
                        ExerciseId = exercise.ExerciseId,
                        Name = exercise.Name,
                        Discription = exercise.Discription,
                        MuscleGroup = exercise.MuscleGroup
                    };
                    exerciseModels.Add(exerciseModel);
                }

                workoutMdl.Exercises = exerciseModels;
                workoutModels.Add(workoutMdl);
            }
            return workoutModels;
        }

        public async Task<List<WorkoutModel>> GetWorkoutsByIds(List<int> workoutIds)
        {
            var workouts = new List<Workout>();

            foreach (var id in workoutIds)
            {
                var workout = await context.Workouts.SingleAsync(w => w.WorkoutId == id);
                workouts.Add(workout);
            }

            var workoutModels = new List<WorkoutModel>();

            foreach (var workout in workouts)
            {
                var workoutMdl = new WorkoutModel()
                {
                    WorkoutModelId = workout.WorkoutId,
                    Name = workout.Name,
                    MuscleGroup = workout.MuscleGroup
                };

                var workoutRefs = await context.WorkoutRefs.Where(m => m.WorkoutId == workout.WorkoutId).ToListAsync();
                var exercises = new List<Exercise>();

                foreach (var workoutRef in workoutRefs)
                {
                    var exercise = await context.Exercises.SingleAsync(m => m.ExerciseId == workoutRef.ExerciseId);
                    exercises.Add(exercise);
                }

                var exerciseModels = new List<ExerciseModel>();

                foreach (var exercise in exercises)
                {
                    var exerciseModel = new ExerciseModel()
                    {
                        ExerciseId = exercise.ExerciseId,
                        Name = exercise.Name,
                        Discription = exercise.Discription,
                        MuscleGroup = exercise.MuscleGroup
                    };
                    exerciseModels.Add(exerciseModel);
                }

                workoutMdl.Exercises = exerciseModels;
                workoutModels.Add(workoutMdl);
            }
            return workoutModels;
        }

        public async Task<WorkoutModel> GetWorkout(int workoutId)
        {
            // get workout entity
            var workout = context.Workouts.Single(w => w.WorkoutId == workoutId);
            
            // make new workoutmodel
            var workoutMdl = new WorkoutModel()
            {
                WorkoutModelId = workout.WorkoutId,
                Name = workout.Name,
                MuscleGroup = workout.MuscleGroup
            };

            // get exercises in selected workout
            var workoutRefs = await context.WorkoutRefs.Where(m => m.WorkoutId == workout.WorkoutId).ToListAsync();
            var exercises = new List<Exercise>();

            foreach (var workoutRef in workoutRefs)
            {
                var exercise = await context.Exercises.SingleAsync(m => m.ExerciseId == workoutRef.ExerciseId);
                exercises.Add(exercise);
            }

            // make exercise models for the workout model
            var exerciseModels = new List<ExerciseModel>();
            var highestNrOfSets = 0;
            foreach (var exercise in exercises)
            {
                var exerciseModel = new ExerciseModel()
                {
                    ExerciseId = exercise.ExerciseId,
                    Name = exercise.Name,
                    Discription = exercise.Discription,
                    MuscleGroup = exercise.MuscleGroup
                };
                
                // gets the sets for each exercise
                var exerciseSets = await context.ExerciseSets.Where(e => e.WorkoutId == workoutId && e.ExerciseId == exercise.ExerciseId).ToListAsync();
                if (exerciseSets != null)
                {
                    var setModels = new List<SetModel>();

                    foreach (var set in exerciseSets)
                    {
                            var setModel = new SetModel()
                            {
                                ExerciseSetsId = set.ExerciseSetsId,
                                Reps = set.Reps,
                                WeightKg = set.WeightKG
                            };
                        setModels.Add(setModel);
                    }
                    exerciseModel.Sets = setModels;
                    if (setModels.Count() > highestNrOfSets)
                    {
                        highestNrOfSets = setModels.Count();
                    }
                }
                exerciseModels.Add(exerciseModel);
            }
            workoutMdl.HighestSets = highestNrOfSets;
            workoutMdl.Exercises = exerciseModels;

            return workoutMdl;
        }

        public async Task<int> CreateWorkout(List<int> selectedExercises, string name, string muscleGroup)
        {
            var workout = new Workout()
            {
                Name = name,
                MuscleGroup = muscleGroup,
            };
            context.Workouts.Add(workout);
            await context.SaveChangesAsync();

            var workoutId = workout.WorkoutId;

            foreach(var exerciseId in selectedExercises)
            {
                var selectedExercise = new WorkoutRef()
                {
                    WorkoutId = workoutId,
                    ExerciseId = exerciseId
                };
                context.WorkoutRefs.Add(selectedExercise);
            }

            await context.SaveChangesAsync();
            return workout.WorkoutId;
        }

        public void CreateNrOfSets(WorkoutModel workout)
        {
            foreach (var exercise in workout.Exercises)
            {
                var nrOfSets = exercise.NrOfSets;

                for (int x = 0; x < nrOfSets; x++)
                {
                    var newSet = new ExerciseSets()
                    {
                        ExerciseId = exercise.ExerciseId,
                        WorkoutId = workout.WorkoutModelId,
                        Reps = 0,
                        WeightKG = 0
                    };
                    context.ExerciseSets.Add(newSet);
                }
                context.SaveChanges();
            }
        }

        public void AddReps(WorkoutModel workout)
        {
            foreach (var exercise in workout.Exercises)
            {
                foreach (var set in exercise.Sets)
                {
                    var exerciseSet = context.ExerciseSets.Single(e => e.ExerciseSetsId == set.ExerciseSetsId);
                    exerciseSet.Reps = set.Reps;
                }
            }
            context.SaveChanges();
        }

        public async Task DeleteWorkout(int workoutId)
        {
            var entity = await context.Workouts.SingleOrDefaultAsync(w => w.WorkoutId == workoutId);
            if (entity != null)
            {
                context.Workouts.Remove(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteExercise(int workoutId, int exerciseId)
        {
            var entity = await context.WorkoutRefs.SingleOrDefaultAsync(w => w.WorkoutId == workoutId && w.ExerciseId == exerciseId);
            if (entity != null)
            {
                context.WorkoutRefs.Remove(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Workout> CreateWorkoutFromModel(WorkoutModel workout)
        {
            var newWorkout = new Workout
            {
                Name = workout.Name,
                MuscleGroup = workout.MuscleGroup
            };

            context.Workouts.Add(newWorkout);
            await context.SaveChangesAsync();

            foreach (var exercise in workout.Exercises)
            {
                var selectedExercise = new WorkoutRef()
                {
                    WorkoutId = newWorkout.WorkoutId,
                    ExerciseId = exercise.ExerciseId
                };
                context.WorkoutRefs.Add(selectedExercise);
            }
            await context.SaveChangesAsync();

            return newWorkout;
        }
    }
}
