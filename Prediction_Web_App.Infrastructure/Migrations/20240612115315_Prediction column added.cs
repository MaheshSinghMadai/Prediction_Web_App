using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prediction_Web_App.Infrastructure.Migrations
{
    public partial class Predictioncolumnadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User_ID",
                table: "Scorecards",
                newName: "User_Id");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Predictions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Predictions");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "Scorecards",
                newName: "User_ID");
        }
    }
}
