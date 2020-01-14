using Microsoft.EntityFrameworkCore.Migrations;

namespace MyAPI.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Name" },
                values: new object[] { 56, "Louisville" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Name" },
                values: new object[] { 100, "Alaska" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "LocationId", "Name" },
                values: new object[] { 23, 56, "Ashoka" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "LocationId", "Name" },
                values: new object[] { 1, 100, "Chill Thund" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 100);
        }
    }
}
