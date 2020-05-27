using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Opskriftplanen.Data.Migrations
{
    public partial class newChangestry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanHeader_WeekPlan_WeekPlanId",
                table: "PlanHeader");

            migrationBuilder.DropTable(
                name: "WeekPlan");

            migrationBuilder.DropIndex(
                name: "IX_PlanHeader_WeekPlanId",
                table: "PlanHeader");

            migrationBuilder.DropColumn(
                name: "WeekPlanId",
                table: "PlanHeader");

            migrationBuilder.DropColumn(
                name: "ApplicationUsers_Name",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Recipe",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PlanHeader",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "PlanHeader");

            migrationBuilder.AddColumn<int>(
                name: "WeekPlanId",
                table: "PlanHeader",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUsers_Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WeekPlan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Friday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Monday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecipesId = table.Column<int>(type: "int", nullable: false),
                    Saturday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sunday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Thursday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tuesday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Wednesday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Week = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "IX_PlanHeader_WeekPlanId",
                table: "PlanHeader",
                column: "WeekPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_WeekPlan_RecipesId",
                table: "WeekPlan",
                column: "RecipesId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanHeader_WeekPlan_WeekPlanId",
                table: "PlanHeader",
                column: "WeekPlanId",
                principalTable: "WeekPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
