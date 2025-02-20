using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FalmatazClothing.Migrations
{
    /// <inheritdoc />
    public partial class makenewchangesintheentitytable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9867b79a-3e59-42e7-b70c-5246e681c46c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e59ef005-9c60-4eee-b126-0b65371ed66f");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Products",
                newName: "Stock");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "217dbad5-e74a-496a-9068-abaaf2cbea22", null, "Admin", "ADMIN" },
                    { "f721a057-583d-4ffe-bb87-0b31dafd1ef8", null, "CUSTOMER", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "217dbad5-e74a-496a-9068-abaaf2cbea22");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f721a057-583d-4ffe-bb87-0b31dafd1ef8");

            migrationBuilder.RenameColumn(
                name: "Stock",
                table: "Products",
                newName: "Quantity");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9867b79a-3e59-42e7-b70c-5246e681c46c", null, "Admin", "ADMIN" },
                    { "e59ef005-9c60-4eee-b126-0b65371ed66f", null, "CUSTOMER", "CUSTOMER" }
                });
        }
    }
}
