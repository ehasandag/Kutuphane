using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kutuphane.Migrations
{
    /// <inheritdoc />
    public partial class baslangic1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Siniflar",
                columns: new[] { "Id", "SinifAdi" },
                values: new object[,]
                {
                    { 2, "10-A" },
                    { 3, "11-A" },
                    { 4, "12-A" },
                    { 5, "9-B" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Siniflar",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Siniflar",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Siniflar",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Siniflar",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
