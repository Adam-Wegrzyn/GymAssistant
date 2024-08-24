using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class LogFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "TrainingLogs");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Trainings",
                newName: "isLogged");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "TrainingLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "TrainingLogs");

            migrationBuilder.RenameColumn(
                name: "isLogged",
                table: "Trainings",
                newName: "isActive");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "TrainingLogs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
