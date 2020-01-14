using Microsoft.EntityFrameworkCore.Migrations;

namespace MyAPI.Migrations
{
    public partial class init9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cusine",
                table: "Hotels");

            migrationBuilder.AddColumn<string>(
                name: "Cuisine",
                table: "Hotels",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 1,
                column: "Cuisine",
                value: "Colombian");

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 22,
                column: "Cuisine",
                value: "Indian");

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 23,
                column: "Cuisine",
                value: "Italian");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cuisine",
                table: "Hotels");

            migrationBuilder.AddColumn<string>(
                name: "Cusine",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
