using Microsoft.EntityFrameworkCore.Migrations;

namespace Opskriftplanen.Data.Migrations
{
    public partial class changedForeignKeyonWeekDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeekDetails_Recipe_PlanId",
                table: "WeekDetails");

            migrationBuilder.CreateIndex(
                name: "IX_WeekDetails_RecipesId",
                table: "WeekDetails",
                column: "RecipesId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeekDetails_Recipe_RecipesId",
                table: "WeekDetails",
                column: "RecipesId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeekDetails_Recipe_RecipesId",
                table: "WeekDetails");

            migrationBuilder.DropIndex(
                name: "IX_WeekDetails_RecipesId",
                table: "WeekDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_WeekDetails_Recipe_PlanId",
                table: "WeekDetails",
                column: "PlanId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
