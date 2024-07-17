using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class fixedTrainingSets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingSetsExercises_TrainingSets_TrainingSetId",
                table: "TrainingSetsExercises");

            migrationBuilder.DropIndex(
                name: "IX_TrainingSetsExercises_TrainingSetId",
                table: "TrainingSetsExercises");

            migrationBuilder.DropColumn(
                name: "TrainingSetId",
                table: "TrainingSetsExercises");

            migrationBuilder.AddColumn<int>(
                name: "TrainingSetExerciseId",
                table: "TrainingSets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingSets_TrainingSetExerciseId",
                table: "TrainingSets",
                column: "TrainingSetExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingSets_TrainingSetsExercises_TrainingSetExerciseId",
                table: "TrainingSets",
                column: "TrainingSetExerciseId",
                principalTable: "TrainingSetsExercises",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingSets_TrainingSetsExercises_TrainingSetExerciseId",
                table: "TrainingSets");

            migrationBuilder.DropIndex(
                name: "IX_TrainingSets_TrainingSetExerciseId",
                table: "TrainingSets");

            migrationBuilder.DropColumn(
                name: "TrainingSetExerciseId",
                table: "TrainingSets");

            migrationBuilder.AddColumn<int>(
                name: "TrainingSetId",
                table: "TrainingSetsExercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingSetsExercises_TrainingSetId",
                table: "TrainingSetsExercises",
                column: "TrainingSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingSetsExercises_TrainingSets_TrainingSetId",
                table: "TrainingSetsExercises",
                column: "TrainingSetId",
                principalTable: "TrainingSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
