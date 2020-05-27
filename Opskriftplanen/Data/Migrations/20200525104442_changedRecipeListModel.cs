using Microsoft.EntityFrameworkCore.Migrations;

namespace Opskriftplanen.Data.Migrations
{
    public partial class changedRecipeListModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ingredientCollectionId",
                table: "RecipeList",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecipeListId",
                table: "MeasurmentUnit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecipeListId",
                table: "IngredientCollection",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecipeListId",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecipeListId",
                table: "Category",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeList_ingredientCollectionId",
                table: "RecipeList",
                column: "ingredientCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurmentUnit_RecipeListId",
                table: "MeasurmentUnit",
                column: "RecipeListId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientCollection_RecipeListId",
                table: "IngredientCollection",
                column: "RecipeListId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_RecipeListId",
                table: "Ingredient",
                column: "RecipeListId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_RecipeListId",
                table: "Category",
                column: "RecipeListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_RecipeList_RecipeListId",
                table: "Category",
                column: "RecipeListId",
                principalTable: "RecipeList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_RecipeList_RecipeListId",
                table: "Ingredient",
                column: "RecipeListId",
                principalTable: "RecipeList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientCollection_RecipeList_RecipeListId",
                table: "IngredientCollection",
                column: "RecipeListId",
                principalTable: "RecipeList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MeasurmentUnit_RecipeList_RecipeListId",
                table: "MeasurmentUnit",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_RecipeList_RecipeListId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_RecipeList_RecipeListId",
                table: "Ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientCollection_RecipeList_RecipeListId",
                table: "IngredientCollection");

            migrationBuilder.DropForeignKey(
                name: "FK_MeasurmentUnit_RecipeList_RecipeListId",
                table: "MeasurmentUnit");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeList_IngredientCollection_ingredientCollectionId",
                table: "RecipeList");

            migrationBuilder.DropIndex(
                name: "IX_RecipeList_ingredientCollectionId",
                table: "RecipeList");

            migrationBuilder.DropIndex(
                name: "IX_MeasurmentUnit_RecipeListId",
                table: "MeasurmentUnit");

            migrationBuilder.DropIndex(
                name: "IX_IngredientCollection_RecipeListId",
                table: "IngredientCollection");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_RecipeListId",
                table: "Ingredient");

            migrationBuilder.DropIndex(
                name: "IX_Category_RecipeListId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "ingredientCollectionId",
                table: "RecipeList");

            migrationBuilder.DropColumn(
                name: "RecipeListId",
                table: "MeasurmentUnit");

            migrationBuilder.DropColumn(
                name: "RecipeListId",
                table: "IngredientCollection");

            migrationBuilder.DropColumn(
                name: "RecipeListId",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "RecipeListId",
                table: "Category");
        }
    }
}
