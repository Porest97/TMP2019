using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TMP2019.Data.Migrations
{
    public partial class PoolGames1Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PoolGame",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PoolGameDateTime = table.Column<DateTime>(nullable: false),
                    GameCategoryId = table.Column<int>(nullable: true),
                    TeamId = table.Column<int>(nullable: true),
                    ArenaId = table.Column<int>(nullable: true),
                    GameId = table.Column<int>(nullable: true),
                    GameId1 = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    PersonId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoolGame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoolGame_Arena_ArenaId",
                        column: x => x.ArenaId,
                        principalTable: "Arena",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PoolGame_GameCategory_GameCategoryId",
                        column: x => x.GameCategoryId,
                        principalTable: "GameCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PoolGame_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PoolGame_Game_GameId1",
                        column: x => x.GameId1,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PoolGame_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PoolGame_Person_PersonId1",
                        column: x => x.PersonId1,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PoolGame_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PoolGame_ArenaId",
                table: "PoolGame",
                column: "ArenaId");

            migrationBuilder.CreateIndex(
                name: "IX_PoolGame_GameCategoryId",
                table: "PoolGame",
                column: "GameCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PoolGame_GameId",
                table: "PoolGame",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_PoolGame_GameId1",
                table: "PoolGame",
                column: "GameId1");

            migrationBuilder.CreateIndex(
                name: "IX_PoolGame_PersonId",
                table: "PoolGame",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PoolGame_PersonId1",
                table: "PoolGame",
                column: "PersonId1");

            migrationBuilder.CreateIndex(
                name: "IX_PoolGame_TeamId",
                table: "PoolGame",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PoolGame");
        }
    }
}
