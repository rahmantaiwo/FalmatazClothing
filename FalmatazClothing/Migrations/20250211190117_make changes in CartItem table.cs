using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FalmatazClothing.Migrations
{
    /// <inheritdoc />
    public partial class makechangesinCartItemtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b760ac5-620e-4496-ac73-8817bb3ae3be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cecd6235-1505-425d-9175-7f9dc31aa0ef");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "CartItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9867b79a-3e59-42e7-b70c-5246e681c46c", null, "Admin", "ADMIN" },
                    { "e59ef005-9c60-4eee-b126-0b65371ed66f", null, "CUSTOMER", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9867b79a-3e59-42e7-b70c-5246e681c46c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e59ef005-9c60-4eee-b126-0b65371ed66f");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "CartItems");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8b760ac5-620e-4496-ac73-8817bb3ae3be", null, "Admin", "ADMIN" },
                    { "cecd6235-1505-425d-9175-7f9dc31aa0ef", null, "CUSTOMER", "CUSTOMER" }
                });
        }
    }
}
