using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessApp.Data.Migrations
{
    public partial class fixenEersteDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepsOfExercises_PerformedExercises_ExercisePerformedExerciseId",
                table: "RepsOfExercises");

            migrationBuilder.DropIndex(
                name: "IX_RepsOfExercises_ExercisePerformedExerciseId",
                table: "RepsOfExercises");

            migrationBuilder.DropColumn(
                name: "ExercisePerformedExerciseId",
                table: "RepsOfExercises");

            migrationBuilder.AddColumn<int>(
                name: "PerformedExerciseId",
                table: "RepsOfExercises",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RepsOfExercises_PerformedExerciseId",
                table: "RepsOfExercises",
                column: "PerformedExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepsOfExercises_PerformedExercises_PerformedExerciseId",
                table: "RepsOfExercises",
                column: "PerformedExerciseId",
                principalTable: "PerformedExercises",
                principalColumn: "PerformedExerciseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepsOfExercises_PerformedExercises_PerformedExerciseId",
                table: "RepsOfExercises");

            migrationBuilder.DropIndex(
                name: "IX_RepsOfExercises_PerformedExerciseId",
                table: "RepsOfExercises");

            migrationBuilder.DropColumn(
                name: "PerformedExerciseId",
                table: "RepsOfExercises");

            migrationBuilder.AddColumn<int>(
                name: "ExercisePerformedExerciseId",
                table: "RepsOfExercises",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepsOfExercises_ExercisePerformedExerciseId",
                table: "RepsOfExercises",
                column: "ExercisePerformedExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepsOfExercises_PerformedExercises_ExercisePerformedExerciseId",
                table: "RepsOfExercises",
                column: "ExercisePerformedExerciseId",
                principalTable: "PerformedExercises",
                principalColumn: "PerformedExerciseId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
