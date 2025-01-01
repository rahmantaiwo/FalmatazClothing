using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FalmatazClothing.Migrations
{
    /// <inheritdoc />
    public partial class secondmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_MaterialType_MaterialTypeId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaterialType",
                table: "MaterialType");

            migrationBuilder.RenameTable(
                name: "MaterialType",
                newName: "MaterialTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaterialTypes",
                table: "MaterialTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MaterialTypes_MaterialTypeId",
                table: "Products",
                column: "MaterialTypeId",
                principalTable: "MaterialTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_MaterialTypes_MaterialTypeId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaterialTypes",
                table: "MaterialTypes");

            migrationBuilder.RenameTable(
                name: "MaterialTypes",
                newName: "MaterialType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaterialType",
                table: "MaterialType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MaterialType_MaterialTypeId",
                table: "Products",
                column: "MaterialTypeId",
                principalTable: "MaterialType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
