using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TMP2019.Data.Migrations
{
    public partial class GameReceiptsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameReceipt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GameId = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    PersonId1 = table.Column<int>(nullable: true),
                    PersonId2 = table.Column<int>(nullable: true),
                    PersonId3 = table.Column<int>(nullable: true),
                    HD1Fee = table.Column<int>(nullable: false),
                    HD1TravelKost = table.Column<int>(nullable: false),
                    HD1Alowens = table.Column<int>(nullable: false),
                    HD1LateGameKost = table.Column<int>(nullable: false),
                    HD1TotalFee = table.Column<int>(nullable: false),
                    HD2Fee = table.Column<int>(nullable: false),
                    HD2TravelKost = table.Column<int>(nullable: false),
                    HD2Alowens = table.Column<int>(nullable: false),
                    HD2LateGameKost = table.Column<int>(nullable: false),
                    HD2TotalFee = table.Column<int>(nullable: false),
                    LD1Fee = table.Column<int>(nullable: false),
                    LD1TravelKost = table.Column<int>(nullable: false),
                    LD1Alowens = table.Column<int>(nullable: false),
                    LD1LateGameKost = table.Column<int>(nullable: false),
                    LD1TotalFee = table.Column<int>(nullable: false),
                    LD2Fee = table.Column<int>(nullable: false),
                    LD2TravelKost = table.Column<int>(nullable: false),
                    LD2Alowens = table.Column<int>(nullable: false),
                    LD2LateGameKost = table.Column<int>(nullable: false),
                    LD2TotalFee = table.Column<int>(nullable: false),
                    GameTotalKost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameReceipt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameReceipt_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameReceipt_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameReceipt_Person_PersonId1",
                        column: x => x.PersonId1,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameReceipt_Person_PersonId2",
                        column: x => x.PersonId2,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameReceipt_Person_PersonId3",
                        column: x => x.PersonId3,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameReceipt_GameId",
                table: "GameReceipt",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameReceipt_PersonId",
                table: "GameReceipt",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_GameReceipt_PersonId1",
                table: "GameReceipt",
                column: "PersonId1");

            migrationBuilder.CreateIndex(
                name: "IX_GameReceipt_PersonId2",
                table: "GameReceipt",
                column: "PersonId2");

            migrationBuilder.CreateIndex(
                name: "IX_GameReceipt_PersonId3",
                table: "GameReceipt",
                column: "PersonId3");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameReceipt");
        }
    }
}
