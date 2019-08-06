using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TMP2019.Data.Migrations
{
    public partial class MatchesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arena",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArenaName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arena", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MatchCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MatchCategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TeamName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MatchCategoryId = table.Column<int>(nullable: true),
                    MatchNumber = table.Column<string>(nullable: true),
                    MatchDateTime = table.Column<DateTime>(nullable: false),
                    ArenaId = table.Column<int>(nullable: true),
                    TeamId = table.Column<int>(nullable: true),
                    TeamId1 = table.Column<int>(nullable: true),
                    HomeTeamScore = table.Column<int>(nullable: true),
                    AwayTeamScore = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    PersonId1 = table.Column<int>(nullable: true),
                    PersonId2 = table.Column<int>(nullable: true),
                    PersonId3 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_Arena_ArenaId",
                        column: x => x.ArenaId,
                        principalTable: "Arena",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_MatchCategory_MatchCategoryId",
                        column: x => x.MatchCategoryId,
                        principalTable: "MatchCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_Person_PersonId1",
                        column: x => x.PersonId1,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_Person_PersonId2",
                        column: x => x.PersonId2,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_Person_PersonId3",
                        column: x => x.PersonId3,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_Team_TeamId1",
                        column: x => x.TeamId1,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Receipt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MatchId = table.Column<int>(nullable: true),
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
                    table.PrimaryKey("PK_Receipt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receipt_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receipt_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receipt_Person_PersonId1",
                        column: x => x.PersonId1,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receipt_Person_PersonId2",
                        column: x => x.PersonId2,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receipt_Person_PersonId3",
                        column: x => x.PersonId3,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Match_ArenaId",
                table: "Match",
                column: "ArenaId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_MatchCategoryId",
                table: "Match",
                column: "MatchCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_PersonId",
                table: "Match",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_PersonId1",
                table: "Match",
                column: "PersonId1");

            migrationBuilder.CreateIndex(
                name: "IX_Match_PersonId2",
                table: "Match",
                column: "PersonId2");

            migrationBuilder.CreateIndex(
                name: "IX_Match_PersonId3",
                table: "Match",
                column: "PersonId3");

            migrationBuilder.CreateIndex(
                name: "IX_Match_TeamId",
                table: "Match",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_TeamId1",
                table: "Match",
                column: "TeamId1");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_MatchId",
                table: "Receipt",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_PersonId",
                table: "Receipt",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_PersonId1",
                table: "Receipt",
                column: "PersonId1");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_PersonId2",
                table: "Receipt",
                column: "PersonId2");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_PersonId3",
                table: "Receipt",
                column: "PersonId3");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Receipt");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "Arena");

            migrationBuilder.DropTable(
                name: "MatchCategory");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
