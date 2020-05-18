using Microsoft.EntityFrameworkCore.Migrations;

namespace Opskriftplanen.Data.Migrations
{
    public partial class trytofix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Measurment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Measures = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeasurmentUnit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeasurUnit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurmentUnit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IngredientCollection",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipesId = table.Column<int>(nullable: false),
                    MeasurmentId = table.Column<int>(nullable: false),
                    IngredientId = table.Column<int>(nullable: false),
                    MeasurmentUnitId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientCollection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientCollection_Ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientCollection_Measurment_MeasurmentId",
                        column: x => x.MeasurmentId,
                        principalTable: "Measurment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientCollection_MeasurmentUnit_MeasurmentUnitId",
                        column: x => x.MeasurmentUnitId,
                        principalTable: "MeasurmentUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientCollection_Recipe_RecipesId",
                        column: x => x.RecipesId,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientCollection_IngredientId",
                table: "IngredientCollection",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientCollection_MeasurmentId",
                table: "IngredientCollection",
                column: "MeasurmentId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientCollection_MeasurmentUnitId",
                table: "IngredientCollection",
                column: "MeasurmentUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientCollection_RecipesId",
                table: "IngredientCollection",
                column: "RecipesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientCollection");

            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "Measurment");

            migrationBuilder.DropTable(
                name: "MeasurmentUnit");
        }
    }
}
