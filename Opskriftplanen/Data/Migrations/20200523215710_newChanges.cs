using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Opskriftplanen.Data.Migrations
{
    public partial class newChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeekPlan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Week = table.Column<DateTime>(nullable: false),
                    Monday = table.Column<int>(nullable: false),
                    Tuesday = table.Column<int>(nullable: false),
                    Wednesday = table.Column<int>(nullable: false),
                    Thursday = table.Column<int>(nullable: false),
                    Friday = table.Column<int>(nullable: false),
                    Saturday = table.Column<int>(nullable: false),
                    Sunday = table.Column<int>(nullable: false),
                    RecipesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeekPlan_Recipe_RecipesId",
                        column: x => x.RecipesId,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeekPlan_RecipesId",
                table: "WeekPlan",
                column: "RecipesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeekPlan");
        }
    }
}
