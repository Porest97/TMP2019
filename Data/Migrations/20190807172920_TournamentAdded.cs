using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TMP2019.Data.Migrations
{
    public partial class TournamentAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TournamentId",
                table: "Team",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TournamentId",
                table: "Match",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tournament",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TournamentName = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    TournamentDescription = table.Column<string>(nullable: true),
                    ArenaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournament", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tournament_Arena_ArenaId",
                        column: x => x.ArenaId,
                        principalTable: "Arena",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Team_TournamentId",
                table: "Team",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_TeamId",
                table: "Person",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_TournamentId",
                table: "Match",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournament_ArenaId",
                table: "Tournament",
                column: "ArenaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Tournament_TournamentId",
                table: "Match",
                column: "TournamentId",
                principalTable: "Tournament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Team_TeamId",
                table: "Person",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Tournament_TournamentId",
                table: "Team",
                column: "TournamentId",
                principalTable: "Tournament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Tournament_TournamentId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Team_TeamId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_Tournament_TournamentId",
                table: "Team");

            migrationBuilder.DropTable(
                name: "Tournament");

            migrationBuilder.DropIndex(
                name: "IX_Team_TournamentId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Person_TeamId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Match_TournamentId",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "TournamentId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "TournamentId",
                table: "Match");
        }
    }
}
