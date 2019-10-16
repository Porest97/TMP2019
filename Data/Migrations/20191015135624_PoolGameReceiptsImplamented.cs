using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TMP2019.Data.Migrations
{
    public partial class PoolGameReceiptsImplamented : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PoolGameReceiptId",
                table: "Game",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PoolGameReceipt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonId = table.Column<int>(nullable: true),
                    HD1Fee = table.Column<int>(nullable: false),
                    HD1TravelKost = table.Column<int>(nullable: false),
                    HD1Alowens = table.Column<int>(nullable: false),
                    HD1LateGameKost = table.Column<int>(nullable: false),
                    HD1Other = table.Column<int>(nullable: false),
                    HD1TotalFee = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: true),
                    Signature = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoolGameReceipt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoolGameReceipt_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Game_PoolGameReceiptId",
                table: "Game",
                column: "PoolGameReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_PoolGameReceipt_PersonId",
                table: "PoolGameReceipt",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_PoolGameReceipt_PoolGameReceiptId",
                table: "Game",
                column: "PoolGameReceiptId",
                principalTable: "PoolGameReceipt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_PoolGameReceipt_PoolGameReceiptId",
                table: "Game");

            migrationBuilder.DropTable(
                name: "PoolGameReceipt");

            migrationBuilder.DropIndex(
                name: "IX_Game_PoolGameReceiptId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "PoolGameReceiptId",
                table: "Game");
        }
    }
}
