using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessApp.Data.Migrations
{
    public partial class fixenEersteDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepsOfExercises_WorkoutFormRows_ExercisePerformedExerciseId",
                table: "RepsOfExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutFormRows_Exercises_ExerciseId",
                table: "WorkoutFormRows");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutFormRows_WorkoutForms_WorkoutFormId",
                table: "WorkoutFormRows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkoutFormRows",
                table: "WorkoutFormRows");

            migrationBuilder.RenameTable(
                name: "WorkoutFormRows",
                newName: "PerformedExercises");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutFormRows_WorkoutFormId",
                table: "PerformedExercises",
                newName: "IX_PerformedExercises_WorkoutFormId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutFormRows_ExerciseId",
                table: "PerformedExercises",
                newName: "IX_PerformedExercises_ExerciseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PerformedExercises",
                table: "PerformedExercises",
                column: "PerformedExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_PerformedExercises_Exercises_ExerciseId",
                table: "PerformedExercises",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "ExerciseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PerformedExercises_WorkoutForms_WorkoutFormId",
                table: "PerformedExercises",
                column: "WorkoutFormId",
                principalTable: "WorkoutForms",
                principalColumn: "WorkoutFormId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RepsOfExercises_PerformedExercises_ExercisePerformedExerciseId",
                table: "RepsOfExercises",
                column: "ExercisePerformedExerciseId",
                principalTable: "PerformedExercises",
                principalColumn: "PerformedExerciseId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerformedExercises_Exercises_ExerciseId",
                table: "PerformedExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_PerformedExercises_WorkoutForms_WorkoutFormId",
                table: "PerformedExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_RepsOfExercises_PerformedExercises_ExercisePerformedExerciseId",
                table: "RepsOfExercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PerformedExercises",
                table: "PerformedExercises");

            migrationBuilder.RenameTable(
                name: "PerformedExercises",
                newName: "WorkoutFormRows");

            migrationBuilder.RenameIndex(
                name: "IX_PerformedExercises_WorkoutFormId",
                table: "WorkoutFormRows",
                newName: "IX_WorkoutFormRows_WorkoutFormId");

            migrationBuilder.RenameIndex(
                name: "IX_PerformedExercises_ExerciseId",
                table: "WorkoutFormRows",
                newName: "IX_WorkoutFormRows_ExerciseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkoutFormRows",
                table: "WorkoutFormRows",
                column: "PerformedExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepsOfExercises_WorkoutFormRows_ExercisePerformedExerciseId",
                table: "RepsOfExercises",
                column: "ExercisePerformedExerciseId",
                principalTable: "WorkoutFormRows",
                principalColumn: "PerformedExerciseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutFormRows_Exercises_ExerciseId",
                table: "WorkoutFormRows",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "ExerciseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutFormRows_WorkoutForms_WorkoutFormId",
                table: "WorkoutFormRows",
                column: "WorkoutFormId",
                principalTable: "WorkoutForms",
                principalColumn: "WorkoutFormId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
