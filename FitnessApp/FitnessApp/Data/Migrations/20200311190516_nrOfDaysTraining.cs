using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessApp.Data.Migrations
{
    public partial class nrOfDaysTraining : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "days",
                table: "trainingSchedules",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "days",
                table: "trainingSchedules");
        }
    }
}
