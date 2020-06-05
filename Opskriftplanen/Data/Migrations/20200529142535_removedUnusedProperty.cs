using Microsoft.EntityFrameworkCore.Migrations;

namespace Opskriftplanen.Data.Migrations
{
    public partial class removedUnusedProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeekPlan_Recipe_RecipesId",
                table: "WeekPlan");

            migrationBuilder.AlterColumn<int>(
                name: "RecipesId",
                table: "WeekPlan",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AlterColumn<int>(
                name: "RecipesId",
                table: "WeekPlan",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WeekPlan_Recipe_RecipesId",
                table: "WeekPlan",
                column: "RecipesId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
