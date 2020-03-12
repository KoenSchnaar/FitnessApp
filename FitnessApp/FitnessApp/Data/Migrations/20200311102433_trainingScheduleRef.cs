using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessApp.Data.Migrations
{
    public partial class trainingScheduleRef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "trainingScheduleRefs",
                columns: table => new
                {
                    TrainingScheduleRefId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkoutId = table.Column<int>(nullable: false),
                    TrainingScheduleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trainingScheduleRefs", x => x.TrainingScheduleRefId);
                    table.ForeignKey(
                        name: "FK_trainingScheduleRefs_trainingSchedules_TrainingScheduleId",
                        column: x => x.TrainingScheduleId,
                        principalTable: "trainingSchedules",
                        principalColumn: "TrainingScheduleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_trainingScheduleRefs_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "WorkoutId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_trainingScheduleRefs_TrainingScheduleId",
                table: "trainingScheduleRefs",
                column: "TrainingScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_trainingScheduleRefs_WorkoutId",
                table: "trainingScheduleRefs",
                column: "WorkoutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trainingScheduleRefs");
        }
    }
}
