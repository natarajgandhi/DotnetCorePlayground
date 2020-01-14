using Microsoft.EntityFrameworkCore.Migrations;

namespace MyAPI.Migrations
{
    public partial class init8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cusines",
                table: "Hotels");

            migrationBuilder.AddColumn<string>(
                name: "Cusine",
                table: "Hotels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cusine",
                table: "Hotels");

            migrationBuilder.AddColumn<string>(
                name: "Cusines",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
