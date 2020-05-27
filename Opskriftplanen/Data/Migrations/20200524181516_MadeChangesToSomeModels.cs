using Microsoft.EntityFrameworkCore.Migrations;

namespace Opskriftplanen.Data.Migrations
{
    public partial class MadeChangesToSomeModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_AspNetUsers_UserId",
                table: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_UserId",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Recipe");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Recipe",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecipeListId",
                table: "IngredientCollection",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IngredientCollection_RecipeListId",
                table: "IngredientCollection",
                column: "RecipeListId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientCollection_RecipeList_RecipeListId",
                table: "IngredientCollection",
                column: "RecipeListId",
                principalTable: "RecipeList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientCollection_RecipeList_RecipeListId",
                table: "IngredientCollection");

            migrationBuilder.DropIndex(
                name: "IX_IngredientCollection_RecipeListId",
                table: "IngredientCollection");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "RecipeListId",
                table: "IngredientCollection");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Recipe",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_UserId",
                table: "Recipe",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_AspNetUsers_UserId",
                table: "Recipe",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
