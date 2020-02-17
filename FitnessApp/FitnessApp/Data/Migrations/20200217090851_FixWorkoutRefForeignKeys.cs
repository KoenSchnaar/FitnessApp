using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessApp.Data.Migrations
{
    public partial class FixWorkoutRefForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MuscleGroup",
                table: "Workouts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutRefs_ExerciseId",
                table: "WorkoutRefs",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutRefs_WorkoutId",
                table: "WorkoutRefs",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutRefs_Exercises_ExerciseId",
                table: "WorkoutRefs",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "ExerciseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutRefs_Workouts_WorkoutId",
                table: "WorkoutRefs",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "WorkoutId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutRefs_Exercises_ExerciseId",
                table: "WorkoutRefs");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutRefs_Workouts_WorkoutId",
                table: "WorkoutRefs");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutRefs_ExerciseId",
                table: "WorkoutRefs");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutRefs_WorkoutId",
                table: "WorkoutRefs");

            migrationBuilder.DropColumn(
                name: "MuscleGroup",
                table: "Workouts");
        }
    }
}
