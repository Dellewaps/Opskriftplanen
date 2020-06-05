using Microsoft.EntityFrameworkCore.Migrations;

namespace Opskriftplanen.Data.Migrations
{
    public partial class addWeekDetailsToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "WeekDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanId = table.Column<int>(nullable: false),
                    RecipesId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IngredientCollectionId = table.Column<int>(nullable: true),
                    WeekPlanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeekDetails_IngredientCollection_IngredientCollectionId",
                        column: x => x.IngredientCollectionId,
                        principalTable: "IngredientCollection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeekDetails_PlanHeader_PlanId",
                        column: x => x.PlanId,
                        principalTable: "PlanHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeekDetails_Recipe_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeekDetails_WeekPlan_WeekPlanId",
                        column: x => x.WeekPlanId,
                        principalTable: "WeekPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeekDetails_IngredientCollectionId",
                table: "WeekDetails",
                column: "IngredientCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_WeekDetails_PlanId",
                table: "WeekDetails",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_WeekDetails_WeekPlanId",
                table: "WeekDetails",
                column: "WeekPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeekDetails");

            migrationBuilder.AddColumn<int>(
                name: "RecipeListId",
                table: "Recipe",
                type: "int",
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
    }
}
