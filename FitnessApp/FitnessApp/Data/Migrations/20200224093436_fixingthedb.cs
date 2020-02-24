using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessApp.Data.Migrations
{
    public partial class fixingthedb : Migration
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
                name: "Workouts",
                columns: table => new
                {
                    WorkoutId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    MuscleGroup = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.WorkoutId);
                });

            

            migrationBuilder.CreateTable(
                name: "ExerciseSets",
                columns: table => new
                {
                    ExerciseSetsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseId = table.Column<int>(nullable: false),
                    WorkoutId = table.Column<int>(nullable: false),
                    Reps = table.Column<int>(nullable: false),
                    WeightKG = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseSets", x => x.ExerciseSetsId);
                    table.ForeignKey(
                        name: "FK_ExerciseSets_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseSets_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "WorkoutId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutForms",
                columns: table => new
                {
                    WorkoutFormId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkoutId = table.Column<int>(nullable: false),
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
                    table.ForeignKey(
                        name: "FK_WorkoutForms_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "WorkoutId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutRefs",
                columns: table => new
                {
                    WorkoutRefId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseId = table.Column<int>(nullable: false),
                    WorkoutId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutRefs", x => x.WorkoutRefId);
                    table.ForeignKey(
                        name: "FK_WorkoutRefs_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutRefs_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "WorkoutId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerformedExercises",
                columns: table => new
                {
                    PerformedExerciseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseId = table.Column<int>(nullable: false),
                    WorkoutFormId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NumberOfSets = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformedExercises", x => x.PerformedExerciseId);
                    table.ForeignKey(
                        name: "FK_PerformedExercises_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerformedExercises_WorkoutForms_WorkoutFormId",
                        column: x => x.WorkoutFormId,
                        principalTable: "WorkoutForms",
                        principalColumn: "WorkoutFormId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerformedSets",
                columns: table => new
                {
                    PerformedSetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerformedExerciseId = table.Column<int>(nullable: false),
                    Reps = table.Column<int>(nullable: false),
                    WeightKG = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformedSets", x => x.PerformedSetId);
                    table.ForeignKey(
                        name: "FK_PerformedSets_PerformedExercises_PerformedExerciseId",
                        column: x => x.PerformedExerciseId,
                        principalTable: "PerformedExercises",
                        principalColumn: "PerformedExerciseId",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSets_ExerciseId",
                table: "ExerciseSets",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSets_WorkoutId",
                table: "ExerciseSets",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformedExercises_ExerciseId",
                table: "PerformedExercises",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformedExercises_WorkoutFormId",
                table: "PerformedExercises",
                column: "WorkoutFormId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformedSets_PerformedExerciseId",
                table: "PerformedSets",
                column: "PerformedExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutForms_UserId",
                table: "WorkoutForms",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutForms_WorkoutId",
                table: "WorkoutForms",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutRefs_ExerciseId",
                table: "WorkoutRefs",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutRefs_WorkoutId",
                table: "WorkoutRefs",
                column: "WorkoutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ExerciseSets");

            migrationBuilder.DropTable(
                name: "PerformedSets");

            migrationBuilder.DropTable(
                name: "WorkoutRefs");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "PerformedExercises");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "WorkoutForms");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Workouts");
        }
    }
}
