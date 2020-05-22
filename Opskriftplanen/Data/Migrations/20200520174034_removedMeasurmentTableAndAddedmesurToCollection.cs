using Microsoft.EntityFrameworkCore.Migrations;

namespace Opskriftplanen.Data.Migrations
{
    public partial class removedMeasurmentTableAndAddedmesurToCollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientCollection_Measurment_MeasurmentId",
                table: "IngredientCollection");

            migrationBuilder.DropTable(
                name: "Measurment");

            migrationBuilder.DropIndex(
                name: "IX_IngredientCollection_MeasurmentId",
                table: "IngredientCollection");

            migrationBuilder.DropColumn(
                name: "MeasurmentId",
                table: "IngredientCollection");

            migrationBuilder.AddColumn<int>(
                name: "Measur",
                table: "IngredientCollection",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Measur",
                table: "IngredientCollection");

            migrationBuilder.AddColumn<int>(
                name: "MeasurmentId",
                table: "IngredientCollection",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Measurment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Measures = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurment", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientCollection_MeasurmentId",
                table: "IngredientCollection",
                column: "MeasurmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientCollection_Measurment_MeasurmentId",
                table: "IngredientCollection",
                column: "MeasurmentId",
                principalTable: "Measurment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
