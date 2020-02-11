using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessApp.Data.Migrations
{
    public partial class CreatieDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Discription = table.Column<string>(nullable: true),
                    MuscleGroup = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.ExerciseId);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutForms",
                columns: table => new
                {
                    WorkoutFormId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Day = table.Column<int>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutForms", x => x.WorkoutFormId);
                    table.ForeignKey(
                        name: "FK_WorkoutForms_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutFormRows",
                columns: table => new
                {
                    PerformedExerciseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseId = table.Column<int>(nullable: false),
                    WorkoutFormId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Sets = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutFormRows", x => x.PerformedExerciseId);
                    table.ForeignKey(
                        name: "FK_WorkoutFormRows_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutFormRows_WorkoutForms_WorkoutFormId",
                        column: x => x.WorkoutFormId,
                        principalTable: "WorkoutForms",
                        principalColumn: "WorkoutFormId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepsOfExercises",
                columns: table => new
                {
                    RepsOfExerciseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExercisePerformedExerciseId = table.Column<int>(nullable: true),
                    Reps = table.Column<int>(nullable: false),
                    WeightKG = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepsOfExercises", x => x.RepsOfExerciseId);
                    table.ForeignKey(
                        name: "FK_RepsOfExercises_WorkoutFormRows_ExercisePerformedExerciseId",
                        column: x => x.ExercisePerformedExerciseId,
                        principalTable: "WorkoutFormRows",
                        principalColumn: "PerformedExerciseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RepsOfExercises_ExercisePerformedExerciseId",
                table: "RepsOfExercises",
                column: "ExercisePerformedExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutFormRows_ExerciseId",
                table: "WorkoutFormRows",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutFormRows_WorkoutFormId",
                table: "WorkoutFormRows",
                column: "WorkoutFormId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutForms_UserId",
                table: "WorkoutForms",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepsOfExercises");

            migrationBuilder.DropTable(
                name: "WorkoutFormRows");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "WorkoutForms");
        }
    }
}
