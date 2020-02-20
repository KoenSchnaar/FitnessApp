using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessApp.Data.Migrations
{
    public partial class SetsAndReps2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkoutId",
                table: "ExerciseSets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSets_WorkoutId",
                table: "ExerciseSets",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseSets_Workouts_WorkoutId",
                table: "ExerciseSets",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "WorkoutId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseSets_Workouts_WorkoutId",
                table: "ExerciseSets");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseSets_WorkoutId",
                table: "ExerciseSets");

            migrationBuilder.DropColumn(
                name: "WorkoutId",
                table: "ExerciseSets");
        }
    }
}
