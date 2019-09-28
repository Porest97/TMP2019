using Microsoft.EntityFrameworkCore.Migrations;

namespace TMP2019.Data.Migrations
{
    public partial class Somechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "Game",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Game_ActivityId",
                table: "Game",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Activity_ActivityId",
                table: "Game",
                column: "ActivityId",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Activity_ActivityId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_ActivityId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Game");
        }
    }
}
