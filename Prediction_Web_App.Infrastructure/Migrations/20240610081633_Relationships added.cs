using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prediction_Web_App.Infrastructure.Migrations
{
    public partial class Relationshipsadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Player_Infos");

            migrationBuilder.DropColumn(
                name: "Goal_Scorer_Tbl_Id",
                table: "Fixtures");

            migrationBuilder.AddColumn<int>(
                name: "Country_Id",
                table: "Player_Infos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Scorecards",
                columns: table => new
                {
                    Fixture_ID = table.Column<int>(type: "int", nullable: false),
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    Final_Score_Points = table.Column<int>(type: "int", nullable: false),
                    Result_Points = table.Column<int>(type: "int", nullable: false),
                    Goal_Scorer_Points = table.Column<int>(type: "int", nullable: false),
                    Total_Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateIndex(
                name: "IX_Predictions_Fixture_ID",
                table: "Predictions",
                column: "Fixture_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Player_Infos_Country_Id",
                table: "Player_Infos",
                column: "Country_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Goal_Scorers_Fixture_Id",
                table: "Goal_Scorers",
                column: "Fixture_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Goal_Scorers_Player_Id",
                table: "Goal_Scorers",
                column: "Player_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Goal_Scorers_Fixtures_Fixture_Id",
                table: "Goal_Scorers",
                column: "Fixture_Id",
                principalTable: "Fixtures",
                principalColumn: "Fixture_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Goal_Scorers_Player_Infos_Player_Id",
                table: "Goal_Scorers",
                column: "Player_Id",
                principalTable: "Player_Infos",
                principalColumn: "Player_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Infos_Countries_Country_Id",
                table: "Player_Infos",
                column: "Country_Id",
                principalTable: "Countries",
                principalColumn: "Country_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Predictions_Fixtures_Fixture_ID",
                table: "Predictions",
                column: "Fixture_ID",
                principalTable: "Fixtures",
                principalColumn: "Fixture_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goal_Scorers_Fixtures_Fixture_Id",
                table: "Goal_Scorers");

            migrationBuilder.DropForeignKey(
                name: "FK_Goal_Scorers_Player_Infos_Player_Id",
                table: "Goal_Scorers");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_Infos_Countries_Country_Id",
                table: "Player_Infos");

            migrationBuilder.DropForeignKey(
                name: "FK_Predictions_Fixtures_Fixture_ID",
                table: "Predictions");

            migrationBuilder.DropTable(
                name: "Scorecards");

            migrationBuilder.DropIndex(
                name: "IX_Predictions_Fixture_ID",
                table: "Predictions");

            migrationBuilder.DropIndex(
                name: "IX_Player_Infos_Country_Id",
                table: "Player_Infos");

            migrationBuilder.DropIndex(
                name: "IX_Goal_Scorers_Fixture_Id",
                table: "Goal_Scorers");

            migrationBuilder.DropIndex(
                name: "IX_Goal_Scorers_Player_Id",
                table: "Goal_Scorers");

            migrationBuilder.DropColumn(
                name: "Country_Id",
                table: "Player_Infos");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Player_Infos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Goal_Scorer_Tbl_Id",
                table: "Fixtures",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
