using Microsoft.EntityFrameworkCore.Migrations;

namespace Opskriftplanen.Data.Migrations
{
    public partial class removedIEnumerableToRecipeList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientCollection_RecipeList_RecipeListId",
                table: "IngredientCollection");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeList_IngredientCollection_ingredientCollectionId",
                table: "RecipeList");

            migrationBuilder.DropIndex(
                name: "IX_RecipeList_ingredientCollectionId",
                table: "RecipeList");

            migrationBuilder.DropIndex(
                name: "IX_IngredientCollection_RecipeListId",
                table: "IngredientCollection");

            migrationBuilder.DropColumn(
                name: "ingredientCollectionId",
                table: "RecipeList");

            migrationBuilder.DropColumn(
                name: "RecipeListId",
                table: "IngredientCollection");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ingredientCollectionId",
                table: "RecipeList",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecipeListId",
                table: "IngredientCollection",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeList_ingredientCollectionId",
                table: "RecipeList",
                column: "ingredientCollectionId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeList_IngredientCollection_ingredientCollectionId",
                table: "RecipeList",
                column: "ingredientCollectionId",
                principalTable: "IngredientCollection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
