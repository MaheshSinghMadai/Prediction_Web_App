using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prediction_Web_App.Infrastructure.Migrations
{
    public partial class Resultcolumndeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Result_Points",
                table: "Scorecards");

            migrationBuilder.DropColumn(
                name: "Result",
                table: "Predictions");

            migrationBuilder.DropColumn(
                name: "Result",
                table: "Fixtures");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Result_Points",
                table: "Scorecards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "Predictions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "Fixtures",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
