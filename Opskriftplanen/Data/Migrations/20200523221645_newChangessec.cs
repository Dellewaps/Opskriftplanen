using Microsoft.EntityFrameworkCore.Migrations;

namespace Opskriftplanen.Data.Migrations
{
    public partial class newChangessec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Recipe",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_AspNetUsers_UserId",
                table: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_UserId",
                table: "Recipe");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Recipe",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
