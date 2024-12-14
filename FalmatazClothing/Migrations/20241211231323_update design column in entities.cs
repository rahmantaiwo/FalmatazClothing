using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FalmatazClothing.Migrations
{
    /// <inheritdoc />
    public partial class updatedesigncolumninentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Inventories",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Designs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Designs");
        }
    }
}
