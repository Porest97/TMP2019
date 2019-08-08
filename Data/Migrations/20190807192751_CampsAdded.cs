using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TMP2019.Data.Migrations
{
    public partial class CampsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CampId",
                table: "Person",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ActivityType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActivityTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Camp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CampName = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    CampDescription = table.Column<string>(nullable: true),
                    ArenaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Camp_Arena_ArenaId",
                        column: x => x.ArenaId,
                        principalTable: "Arena",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActivityName = table.Column<string>(nullable: true),
                    StartDateTime = table.Column<DateTime>(nullable: false),
                    EndDateTime = table.Column<DateTime>(nullable: false),
                    ActivityDescription = table.Column<string>(nullable: true),
                    ArenaId = table.Column<int>(nullable: true),
                    ActivityTypeId = table.Column<int>(nullable: true),
                    CampId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activity_ActivityType_ActivityTypeId",
                        column: x => x.ActivityTypeId,
                        principalTable: "ActivityType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Activity_Arena_ArenaId",
                        column: x => x.ArenaId,
                        principalTable: "Arena",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Activity_Camp_CampId",
                        column: x => x.CampId,
                        principalTable: "Camp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_ActivityId",
                table: "Person",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_CampId",
                table: "Person",
                column: "CampId");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_ActivityTypeId",
                table: "Activity",
                column: "ActivityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_ArenaId",
                table: "Activity",
                column: "ArenaId");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_CampId",
                table: "Activity",
                column: "CampId");

            migrationBuilder.CreateIndex(
                name: "IX_Camp_ArenaId",
                table: "Camp",
                column: "ArenaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Activity_ActivityId",
                table: "Person",
                column: "ActivityId",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Camp_CampId",
                table: "Person",
                column: "CampId",
                principalTable: "Camp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Activity_ActivityId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Camp_CampId",
                table: "Person");

            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "ActivityType");

            migrationBuilder.DropTable(
                name: "Camp");

            migrationBuilder.DropIndex(
                name: "IX_Person_ActivityId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_CampId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "CampId",
                table: "Person");
        }
    }
}
