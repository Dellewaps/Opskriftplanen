using Microsoft.EntityFrameworkCore.Migrations;

namespace Opskriftplanen.Data.Migrations
{
    public partial class changedPlanDetailsListAndRecipeListModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipeListId",
                table: "Recipe",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_RecipeListId",
                table: "Recipe",
                column: "RecipeListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_RecipeList_RecipeListId",
                table: "Recipe",
                column: "RecipeListId",
                principalTable: "RecipeList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_RecipeList_RecipeListId",
                table: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_RecipeListId",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "RecipeListId",
                table: "Recipe");
        }
    }
}
