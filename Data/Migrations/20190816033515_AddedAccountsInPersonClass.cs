using Microsoft.EntityFrameworkCore.Migrations;

namespace TMP2019.Data.Migrations
{
    public partial class AddedAccountsInPersonClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BankAccount",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SwishNumber",
                table: "Person",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankAccount",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "BankName",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "SwishNumber",
                table: "Person");
        }
    }
}
