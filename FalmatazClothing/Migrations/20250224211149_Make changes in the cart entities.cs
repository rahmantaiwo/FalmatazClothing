using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FalmatazClothing.Migrations
{
    /// <inheritdoc />
    public partial class Makechangesinthecartentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63b8ea4c-b469-4985-b0b0-357887467a9a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e47cbb80-5c44-4e55-848d-a638987f4ab7");

            migrationBuilder.RenameColumn(
                name: "Stock",
                table: "Products",
                newName: "StockQuantity");

            migrationBuilder.AlterColumn<Guid>(
                name: "CartId",
                table: "CartItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9345c153-d5fd-4453-b02e-e0b9f46d4359", null, "Admin", "ADMIN" },
                    { "d776451e-d2f3-4d84-88aa-ed0869c966fa", null, "CUSTOMER", "CUSTOMER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9345c153-d5fd-4453-b02e-e0b9f46d4359");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d776451e-d2f3-4d84-88aa-ed0869c966fa");

            migrationBuilder.RenameColumn(
                name: "StockQuantity",
                table: "Products",
                newName: "Stock");

            migrationBuilder.AlterColumn<Guid>(
                name: "CartId",
                table: "CartItems",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "63b8ea4c-b469-4985-b0b0-357887467a9a", null, "Admin", "ADMIN" },
                    { "e47cbb80-5c44-4e55-848d-a638987f4ab7", null, "CUSTOMER", "CUSTOMER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");
        }
    }
}
