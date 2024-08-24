using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MissingFieldsFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeOnly>(
                name: "Duration",
                table: "TrainingSetLogs",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "TrainingSetLogs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "Duration",
                table: "TrainingSetExerciseLogs",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "TrainingSetExerciseLogs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "Duration",
                table: "TrainingLogs",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "TrainingLogs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "TrainingSetLogs");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "TrainingSetLogs");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "TrainingSetExerciseLogs");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "TrainingSetExerciseLogs");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "TrainingLogs");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "TrainingLogs");
        }
    }
}
