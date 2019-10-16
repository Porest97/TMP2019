using Microsoft.EntityFrameworkCore.Migrations;

namespace TMP2019.Data.Migrations
{
    public partial class ArnenaAddedToPoolGameReceipts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArenaId",
                table: "PoolGameReceipt",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PoolGameReceipt_ArenaId",
                table: "PoolGameReceipt",
                column: "ArenaId");

            migrationBuilder.AddForeignKey(
                name: "FK_PoolGameReceipt_Arena_ArenaId",
                table: "PoolGameReceipt",
                column: "ArenaId",
                principalTable: "Arena",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoolGameReceipt_Arena_ArenaId",
                table: "PoolGameReceipt");

            migrationBuilder.DropIndex(
                name: "IX_PoolGameReceipt_ArenaId",
                table: "PoolGameReceipt");

            migrationBuilder.DropColumn(
                name: "ArenaId",
                table: "PoolGameReceipt");
        }
    }
}
