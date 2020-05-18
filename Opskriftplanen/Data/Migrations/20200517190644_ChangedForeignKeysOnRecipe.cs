using Microsoft.EntityFrameworkCore.Migrations;

namespace Opskriftplanen.Data.Migrations
{
    public partial class ChangedForeignKeysOnRecipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurment_Measurment_MeasurmentId",
                table: "Measurment");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Category_CategoryId",
                table: "Recipe");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Measurment_MeasurmentId",
                table: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_CategoryId",
                table: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_MeasurmentId",
                table: "Recipe");

            migrationBuilder.AddColumn<int>(
                name: "MeasurmentId1",
                table: "Measurment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Category",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Measurment_MeasurmentId1",
                table: "Measurment",
                column: "MeasurmentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Category_CategoryId",
                table: "Category",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Recipe_CategoryId",
                table: "Category",
                column: "CategoryId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Measurment_Recipe_MeasurmentId",
                table: "Measurment",
                column: "MeasurmentId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Measurment_Measurment_MeasurmentId1",
                table: "Measurment",
                column: "MeasurmentId1",
                principalTable: "Measurment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Recipe_CategoryId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Measurment_Recipe_MeasurmentId",
                table: "Measurment");

            migrationBuilder.DropForeignKey(
                name: "FK_Measurment_Measurment_MeasurmentId1",
                table: "Measurment");

            migrationBuilder.DropIndex(
                name: "IX_Measurment_MeasurmentId1",
                table: "Measurment");

            migrationBuilder.DropIndex(
                name: "IX_Category_CategoryId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "MeasurmentId1",
                table: "Measurment");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_CategoryId",
                table: "Recipe",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_MeasurmentId",
                table: "Recipe",
                column: "MeasurmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Measurment_Measurment_MeasurmentId",
                table: "Measurment",
                column: "MeasurmentId",
                principalTable: "Measurment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Category_CategoryId",
                table: "Recipe",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Measurment_MeasurmentId",
                table: "Recipe",
                column: "MeasurmentId",
                principalTable: "Measurment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
