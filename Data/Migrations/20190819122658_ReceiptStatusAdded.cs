using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TMP2019.Data.Migrations
{
    public partial class ReceiptStatusAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AmountPaidHD1",
                table: "GameReceipt",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AmountPaidHD2",
                table: "GameReceipt",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AmountPaidLD1",
                table: "GameReceipt",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AmountPaidLD2",
                table: "GameReceipt",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReceiptStatusId",
                table: "GameReceipt",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecieptStatusId",
                table: "GameReceipt",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalAmountPaid",
                table: "GameReceipt",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalAmountToPay",
                table: "GameReceipt",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ReceiptStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReceiptStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameReceipt_RecieptStatusId",
                table: "GameReceipt",
                column: "RecieptStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameReceipt_ReceiptStatus_RecieptStatusId",
                table: "GameReceipt",
                column: "RecieptStatusId",
                principalTable: "ReceiptStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameReceipt_ReceiptStatus_RecieptStatusId",
                table: "GameReceipt");

            migrationBuilder.DropTable(
                name: "ReceiptStatus");

            migrationBuilder.DropIndex(
                name: "IX_GameReceipt_RecieptStatusId",
                table: "GameReceipt");

            migrationBuilder.DropColumn(
                name: "AmountPaidHD1",
                table: "GameReceipt");

            migrationBuilder.DropColumn(
                name: "AmountPaidHD2",
                table: "GameReceipt");

            migrationBuilder.DropColumn(
                name: "AmountPaidLD1",
                table: "GameReceipt");

            migrationBuilder.DropColumn(
                name: "AmountPaidLD2",
                table: "GameReceipt");

            migrationBuilder.DropColumn(
                name: "ReceiptStatusId",
                table: "GameReceipt");

            migrationBuilder.DropColumn(
                name: "RecieptStatusId",
                table: "GameReceipt");

            migrationBuilder.DropColumn(
                name: "TotalAmountPaid",
                table: "GameReceipt");

            migrationBuilder.DropColumn(
                name: "TotalAmountToPay",
                table: "GameReceipt");
        }
    }
}
