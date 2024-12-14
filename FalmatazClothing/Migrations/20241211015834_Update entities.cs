using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FalmatazClothing.Migrations
{
    /// <inheritdoc />
    public partial class Updateentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measurements");

            migrationBuilder.RenameColumn(
                name: "Syle",
                table: "Designs",
                newName: "Style");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Designs",
                newName: "Image");

            migrationBuilder.AddColumn<string>(
                name: "ImageFileName",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Inventories",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFileName",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Inventories");

            migrationBuilder.RenameColumn(
                name: "Style",
                table: "Designs",
                newName: "Syle");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Designs",
                newName: "ImageUrl");

            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Burst = table.Column<double>(type: "float", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hips = table.Column<double>(type: "float", nullable: false),
                    ShoulderWidth = table.Column<double>(type: "float", nullable: false),
                    SleeveLength = table.Column<double>(type: "float", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Waist = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.Id);
                });
        }
    }
}
