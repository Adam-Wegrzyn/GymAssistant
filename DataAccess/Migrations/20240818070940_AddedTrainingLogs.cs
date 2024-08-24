using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedTrainingLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainingSetExerciseLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingSetExerciseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingSetExerciseLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingSetExerciseLogs_TrainingSetsExercises_TrainingSetExerciseId",
                        column: x => x.TrainingSetExerciseId,
                        principalTable: "TrainingSetsExercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingSetLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingSetLogs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingSetExerciseLogs_TrainingSetExerciseId",
                table: "TrainingSetExerciseLogs",
                column: "TrainingSetExerciseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingSetExerciseLogs");

            migrationBuilder.DropTable(
                name: "TrainingSetLogs");
        }
    }
}
