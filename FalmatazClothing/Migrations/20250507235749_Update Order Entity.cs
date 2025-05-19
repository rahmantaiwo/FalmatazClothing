using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FalmatazClothing.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3062487-60a5-435b-955a-7e615ce40805");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce96e767-763d-46ed-b5d7-dc2cd31b9a59");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "OrderItems",
                newName: "UnitPrice");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1bea3b05-761d-4cac-916b-a805fa1172fd", null, "Admin", "ADMIN" },
                    { "64a19160-4b14-48d5-bf9f-ab07e5a57fc5", null, "CUSTOMER", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bea3b05-761d-4cac-916b-a805fa1172fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64a19160-4b14-48d5-bf9f-ab07e5a57fc5");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "OrderItems",
                newName: "Price");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a3062487-60a5-435b-955a-7e615ce40805", null, "CUSTOMER", "CUSTOMER" },
                    { "ce96e767-763d-46ed-b5d7-dc2cd31b9a59", null, "Admin", "ADMIN" }
                });
        }
    }
}
