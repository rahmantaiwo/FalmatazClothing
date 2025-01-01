using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FalmatazClothing.Migrations
{
    /// <inheritdoc />
    public partial class Makesomechangesintheentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Adires_AdireId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Ankaras_AnkaraId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Aso_Okes_Aso_okeId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Atikus_AtikuId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Guineas_GuineaId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Senators_SenatorId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Textiles_TextilesId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Adires");

            migrationBuilder.DropTable(
                name: "Ankaras");

            migrationBuilder.DropTable(
                name: "Aso_Okes");

            migrationBuilder.DropTable(
                name: "Atikus");

            migrationBuilder.DropTable(
                name: "Guineas");

            migrationBuilder.DropTable(
                name: "Senators");

            migrationBuilder.DropTable(
                name: "Textiles");

            migrationBuilder.DropIndex(
                name: "IX_Products_AdireId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_AnkaraId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Aso_okeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_AtikuId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_GuineaId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SenatorId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AdireId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AnkaraId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Aso_okeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AtikuId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "GuineaId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SenatorId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "TextilesId",
                table: "Products",
                newName: "MaterialTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_TextilesId",
                table: "Products",
                newName: "IX_Products_MaterialTypeId");

            migrationBuilder.CreateTable(
                name: "MaterialType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialType", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MaterialType_MaterialTypeId",
                table: "Products",
                column: "MaterialTypeId",
                principalTable: "MaterialType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_MaterialType_MaterialTypeId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "MaterialType");

            migrationBuilder.RenameColumn(
                name: "MaterialTypeId",
                table: "Products",
                newName: "TextilesId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_MaterialTypeId",
                table: "Products",
                newName: "IX_Products_TextilesId");

            migrationBuilder.AddColumn<Guid>(
                name: "AdireId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AnkaraId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Aso_okeId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AtikuId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GuineaId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SenatorId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Adires",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adires", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ankaras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ankaras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aso_Okes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aso_Okes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Atikus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atikus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guineas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guineas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Senators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Senators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Textiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Textiles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_AdireId",
                table: "Products",
                column: "AdireId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_AnkaraId",
                table: "Products",
                column: "AnkaraId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Aso_okeId",
                table: "Products",
                column: "Aso_okeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_AtikuId",
                table: "Products",
                column: "AtikuId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_GuineaId",
                table: "Products",
                column: "GuineaId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SenatorId",
                table: "Products",
                column: "SenatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Adires_AdireId",
                table: "Products",
                column: "AdireId",
                principalTable: "Adires",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Ankaras_AnkaraId",
                table: "Products",
                column: "AnkaraId",
                principalTable: "Ankaras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Aso_Okes_Aso_okeId",
                table: "Products",
                column: "Aso_okeId",
                principalTable: "Aso_Okes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Atikus_AtikuId",
                table: "Products",
                column: "AtikuId",
                principalTable: "Atikus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Guineas_GuineaId",
                table: "Products",
                column: "GuineaId",
                principalTable: "Guineas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Senators_SenatorId",
                table: "Products",
                column: "SenatorId",
                principalTable: "Senators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Textiles_TextilesId",
                table: "Products",
                column: "TextilesId",
                principalTable: "Textiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
