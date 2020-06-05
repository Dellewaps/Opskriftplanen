using Microsoft.EntityFrameworkCore.Migrations;

namespace Opskriftplanen.Data.Migrations
{
    public partial class addedVirtuelRecipesToWeek : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipesId",
                table: "WeekPlan",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeekPlan_RecipesId",
                table: "WeekPlan",
                column: "RecipesId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeekPlan_Recipe_RecipesId",
                table: "WeekPlan",
                column: "RecipesId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeekPlan_Recipe_RecipesId",
                table: "WeekPlan");

            migrationBuilder.DropIndex(
                name: "IX_WeekPlan_RecipesId",
                table: "WeekPlan");

            migrationBuilder.DropColumn(
                name: "RecipesId",
                table: "WeekPlan");
        }
    }
}
