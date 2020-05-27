using Microsoft.EntityFrameworkCore.Migrations;

namespace Opskriftplanen.Data.Migrations
{
    public partial class AddIEnumerableToRecipeList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ingredientCollectionId",
                table: "RecipeList",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeList_ingredientCollectionId",
                table: "RecipeList",
                column: "ingredientCollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeList_IngredientCollection_ingredientCollectionId",
                table: "RecipeList",
                column: "ingredientCollectionId",
                principalTable: "IngredientCollection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeList_IngredientCollection_ingredientCollectionId",
                table: "RecipeList");

            migrationBuilder.DropIndex(
                name: "IX_RecipeList_ingredientCollectionId",
                table: "RecipeList");

            migrationBuilder.DropColumn(
                name: "ingredientCollectionId",
                table: "RecipeList");
        }
    }
}
