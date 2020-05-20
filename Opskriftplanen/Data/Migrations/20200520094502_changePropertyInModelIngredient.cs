using Microsoft.EntityFrameworkCore.Migrations;

namespace Opskriftplanen.Data.Migrations
{
    public partial class changePropertyInModelIngredient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IngredientName",
                table: "Ingredient");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Ingredient",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Ingredient");

            migrationBuilder.AddColumn<string>(
                name: "IngredientName",
                table: "Ingredient",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
