using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prediction_Web_App.Infrastructure.Migrations
{
    public partial class DBrecreared : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Country_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlagWebUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Country_ID);
                });

            migrationBuilder.CreateTable(
                name: "Fixtures",
                columns: table => new
                {
                    Fixture_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country1_Score = table.Column<int>(type: "int", nullable: false),
                    Country2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country2_Score = table.Column<int>(type: "int", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fixtures", x => x.Fixture_ID);
                });

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

            migrationBuilder.CreateTable(
                name: "Player_Infos",
                columns: table => new
                {
                    Player_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Player_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player_Infos", x => x.Player_ID);
                    table.ForeignKey(
                        name: "FK_Player_Infos_Countries_Country_Id",
                        column: x => x.Country_Id,
                        principalTable: "Countries",
                        principalColumn: "Country_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Predictions",
                columns: table => new
                {
                    Prediction_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fixture_ID = table.Column<int>(type: "int", nullable: false),
                    Country1_Score = table.Column<int>(type: "int", nullable: false),
                    Country2_Score = table.Column<int>(type: "int", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Goal_Scorer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predictions", x => x.Prediction_ID);
                    table.ForeignKey(
                        name: "FK_Predictions_Fixtures_Fixture_ID",
                        column: x => x.Fixture_ID,
                        principalTable: "Fixtures",
                        principalColumn: "Fixture_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Goal_Scorers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fixture_Id = table.Column<int>(type: "int", nullable: false),
                    Player_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goal_Scorers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Goal_Scorers_Fixtures_Fixture_Id",
                        column: x => x.Fixture_Id,
                        principalTable: "Fixtures",
                        principalColumn: "Fixture_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Goal_Scorers_Player_Infos_Player_Id",
                        column: x => x.Player_Id,
                        principalTable: "Player_Infos",
                        principalColumn: "Player_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Goal_Scorers_Fixture_Id",
                table: "Goal_Scorers",
                column: "Fixture_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Goal_Scorers_Player_Id",
                table: "Goal_Scorers",
                column: "Player_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Player_Infos_Country_Id",
                table: "Player_Infos",
                column: "Country_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Predictions_Fixture_ID",
                table: "Predictions",
                column: "Fixture_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Goal_Scorers");

            migrationBuilder.DropTable(
                name: "Predictions");

            migrationBuilder.DropTable(
                name: "Scorecards");

            migrationBuilder.DropTable(
                name: "Player_Infos");

            migrationBuilder.DropTable(
                name: "Fixtures");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
