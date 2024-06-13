using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prediction_Web_App.Infrastructure.Migrations
{
    public partial class Predictioncolumnmodifyss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Goal_Scorer",
                table: "Predictions",
                newName: "Goal_Scorer_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Goal_Scorer_Id",
                table: "Predictions",
                newName: "Goal_Scorer");
        }
    }
}
