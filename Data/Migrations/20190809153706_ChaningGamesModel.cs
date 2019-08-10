using Microsoft.EntityFrameworkCore.Migrations;

namespace TMP2019.Data.Migrations
{
    public partial class ChaningGamesModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_MatchCategory_GameCategoryId",
                table: "Game");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_GameCategory_GameCategoryId",
                table: "Game",
                column: "GameCategoryId",
                principalTable: "GameCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_GameCategory_GameCategoryId",
                table: "Game");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_MatchCategory_GameCategoryId",
                table: "Game",
                column: "GameCategoryId",
                principalTable: "MatchCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
