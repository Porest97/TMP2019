using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TMP2019.Data.Migrations
{
    public partial class InvoicesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArticleDescription = table.Column<string>(nullable: true),
                    ArticlePrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceRow",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArticleId = table.Column<int>(nullable: true),
                    Quantity = table.Column<double>(nullable: false),
                    RowTotal = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceRow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceRow_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InvoceHeader = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: true),
                    CompanyId1 = table.Column<int>(nullable: true),
                    InvoiceDate = table.Column<DateTime>(nullable: false),
                    Maturity = table.Column<DateTime>(nullable: false),
                    PaymentTerms = table.Column<string>(nullable: true),
                    InvoiceRowId = table.Column<int>(nullable: true),
                    InvoiceRowId1 = table.Column<int>(nullable: true),
                    InvoiceRowId2 = table.Column<int>(nullable: true),
                    InvoiceRowId3 = table.Column<int>(nullable: true),
                    InvoiceRowId4 = table.Column<int>(nullable: true),
                    InvoiceRowId5 = table.Column<int>(nullable: true),
                    InvoiceRowId6 = table.Column<int>(nullable: true),
                    InvoiceRowId7 = table.Column<int>(nullable: true),
                    InvoiceRowId8 = table.Column<int>(nullable: true),
                    InvoiceRowId9 = table.Column<int>(nullable: true),
                    InvoceFooter = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoice_Company_CompanyId1",
                        column: x => x.CompanyId1,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoice_InvoiceRow_InvoiceRowId",
                        column: x => x.InvoiceRowId,
                        principalTable: "InvoiceRow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoice_InvoiceRow_InvoiceRowId1",
                        column: x => x.InvoiceRowId1,
                        principalTable: "InvoiceRow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoice_InvoiceRow_InvoiceRowId2",
                        column: x => x.InvoiceRowId2,
                        principalTable: "InvoiceRow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoice_InvoiceRow_InvoiceRowId3",
                        column: x => x.InvoiceRowId3,
                        principalTable: "InvoiceRow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoice_InvoiceRow_InvoiceRowId4",
                        column: x => x.InvoiceRowId4,
                        principalTable: "InvoiceRow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoice_InvoiceRow_InvoiceRowId5",
                        column: x => x.InvoiceRowId5,
                        principalTable: "InvoiceRow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoice_InvoiceRow_InvoiceRowId6",
                        column: x => x.InvoiceRowId6,
                        principalTable: "InvoiceRow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoice_InvoiceRow_InvoiceRowId7",
                        column: x => x.InvoiceRowId7,
                        principalTable: "InvoiceRow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoice_InvoiceRow_InvoiceRowId8",
                        column: x => x.InvoiceRowId8,
                        principalTable: "InvoiceRow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoice_InvoiceRow_InvoiceRowId9",
                        column: x => x.InvoiceRowId9,
                        principalTable: "InvoiceRow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_CompanyId",
                table: "Invoice",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_CompanyId1",
                table: "Invoice",
                column: "CompanyId1");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_InvoiceRowId",
                table: "Invoice",
                column: "InvoiceRowId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_InvoiceRowId1",
                table: "Invoice",
                column: "InvoiceRowId1");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_InvoiceRowId2",
                table: "Invoice",
                column: "InvoiceRowId2");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_InvoiceRowId3",
                table: "Invoice",
                column: "InvoiceRowId3");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_InvoiceRowId4",
                table: "Invoice",
                column: "InvoiceRowId4");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_InvoiceRowId5",
                table: "Invoice",
                column: "InvoiceRowId5");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_InvoiceRowId6",
                table: "Invoice",
                column: "InvoiceRowId6");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_InvoiceRowId7",
                table: "Invoice",
                column: "InvoiceRowId7");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_InvoiceRowId8",
                table: "Invoice",
                column: "InvoiceRowId8");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_InvoiceRowId9",
                table: "Invoice",
                column: "InvoiceRowId9");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceRow_ArticleId",
                table: "InvoiceRow",
                column: "ArticleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "InvoiceRow");

            migrationBuilder.DropTable(
                name: "Article");
        }
    }
}
