using Microsoft.EntityFrameworkCore.Migrations;

namespace Opskriftplanen.Data.Migrations
{
    public partial class changePropertyInModelMeasurmentUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeasurUnit",
                table: "MeasurmentUnit");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MeasurmentUnit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "MeasurmentUnit");

            migrationBuilder.AddColumn<string>(
                name: "MeasurUnit",
                table: "MeasurmentUnit",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
