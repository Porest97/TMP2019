using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TMP2019.Data.Migrations
{
    public partial class RefFeesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameReceipt_ReceiptStatus_RecieptStatusId",
                table: "GameReceipt");

            migrationBuilder.DropIndex(
                name: "IX_GameReceipt_RecieptStatusId",
                table: "GameReceipt");

            migrationBuilder.DropColumn(
                name: "RecieptStatusId",
                table: "GameReceipt");

            migrationBuilder.AddColumn<int>(
                name: "HD1Other",
                table: "GameReceipt",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HD2Other",
                table: "GameReceipt",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LD1Other",
                table: "GameReceipt",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LD2Other",
                table: "GameReceipt",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FeeCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FeeCategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeeCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefFee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FeeCategoryId = table.Column<int>(nullable: true),
                    GameCategoryId = table.Column<int>(nullable: true),
                    FeeHD = table.Column<double>(nullable: true),
                    FeeLD = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefFee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefFee_FeeCategory_FeeCategoryId",
                        column: x => x.FeeCategoryId,
                        principalTable: "FeeCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RefFee_GameCategory_GameCategoryId",
                        column: x => x.GameCategoryId,
                        principalTable: "GameCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameReceipt_ReceiptStatusId",
                table: "GameReceipt",
                column: "ReceiptStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_RefFee_FeeCategoryId",
                table: "RefFee",
                column: "FeeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RefFee_GameCategoryId",
                table: "RefFee",
                column: "GameCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameReceipt_ReceiptStatus_ReceiptStatusId",
                table: "GameReceipt",
                column: "ReceiptStatusId",
                principalTable: "ReceiptStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameReceipt_ReceiptStatus_ReceiptStatusId",
                table: "GameReceipt");

            migrationBuilder.DropTable(
                name: "RefFee");

            migrationBuilder.DropTable(
                name: "FeeCategory");

            migrationBuilder.DropIndex(
                name: "IX_GameReceipt_ReceiptStatusId",
                table: "GameReceipt");

            migrationBuilder.DropColumn(
                name: "HD1Other",
                table: "GameReceipt");

            migrationBuilder.DropColumn(
                name: "HD2Other",
                table: "GameReceipt");

            migrationBuilder.DropColumn(
                name: "LD1Other",
                table: "GameReceipt");

            migrationBuilder.DropColumn(
                name: "LD2Other",
                table: "GameReceipt");

            migrationBuilder.AddColumn<int>(
                name: "RecieptStatusId",
                table: "GameReceipt",
                nullable: true);

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
    }
}
