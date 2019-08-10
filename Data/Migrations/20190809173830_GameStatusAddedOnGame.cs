using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TMP2019.Data.Migrations
{
    public partial class GameStatusAddedOnGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameStatusId",
                table: "Game",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GameStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GameStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Game_GameStatusId",
                table: "Game",
                column: "GameStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_GameStatus_GameStatusId",
                table: "Game",
                column: "GameStatusId",
                principalTable: "GameStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_GameStatus_GameStatusId",
                table: "Game");

            migrationBuilder.DropTable(
                name: "GameStatus");

            migrationBuilder.DropIndex(
                name: "IX_Game_GameStatusId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "GameStatusId",
                table: "Game");
        }
    }
}
