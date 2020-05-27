using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Opskriftplanen.Data.Migrations
{
    public partial class addModelsForWeekPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUsers_Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RecipeList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    ResipesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeekPlan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Week = table.Column<DateTime>(nullable: false),
                    Monday = table.Column<DateTime>(nullable: false),
                    Tuesday = table.Column<DateTime>(nullable: false),
                    Wednesday = table.Column<DateTime>(nullable: false),
                    Thursday = table.Column<DateTime>(nullable: false),
                    Friday = table.Column<DateTime>(nullable: false),
                    Saturday = table.Column<DateTime>(nullable: false),
                    Sunday = table.Column<DateTime>(nullable: false),
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

            migrationBuilder.CreateTable(
                name: "PlanHeader",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    WeekPlanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanHeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanHeader_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanHeader_WeekPlan_WeekPlanId",
                        column: x => x.WeekPlanId,
                        principalTable: "WeekPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanHeader_UserId",
                table: "PlanHeader",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanHeader_WeekPlanId",
                table: "PlanHeader",
                column: "WeekPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_WeekPlan_RecipesId",
                table: "WeekPlan",
                column: "RecipesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanHeader");

            migrationBuilder.DropTable(
                name: "RecipeList");

            migrationBuilder.DropTable(
                name: "WeekPlan");

            migrationBuilder.DropColumn(
                name: "ApplicationUsers_Name",
                table: "AspNetUsers");
        }
    }
}
