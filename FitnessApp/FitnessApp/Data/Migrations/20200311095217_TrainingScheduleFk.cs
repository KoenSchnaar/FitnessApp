using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessApp.Data.Migrations
{
    public partial class TrainingScheduleFk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrainingScheduleId",
                table: "Workouts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_TrainingScheduleId",
                table: "Workouts",
                column: "TrainingScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_trainingSchedules_TrainingScheduleId",
                table: "Workouts",
                column: "TrainingScheduleId",
                principalTable: "trainingSchedules",
                principalColumn: "TrainingScheduleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_trainingSchedules_TrainingScheduleId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_TrainingScheduleId",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "TrainingScheduleId",
                table: "Workouts");
        }
    }
}
