using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FalmatazClothing.Migrations
{
    /// <inheritdoc />
    public partial class makechangesintheOrdertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17037a06-cf7b-4ba0-846f-4f7572cdd22f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f635190-b89b-45ce-9bfc-b1aac7e6dea4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a3062487-60a5-435b-955a-7e615ce40805", null, "CUSTOMER", "CUSTOMER" },
                    { "ce96e767-763d-46ed-b5d7-dc2cd31b9a59", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3062487-60a5-435b-955a-7e615ce40805");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce96e767-763d-46ed-b5d7-dc2cd31b9a59");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "17037a06-cf7b-4ba0-846f-4f7572cdd22f", null, "Admin", "ADMIN" },
                    { "5f635190-b89b-45ce-9bfc-b1aac7e6dea4", null, "CUSTOMER", "CUSTOMER" }
                });
        }
    }
}
