using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.V1
{
    public partial class MigrationV01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Actor",
                schema: "planifica",
                table: "IndicadorPOAs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                schema: "planifica",
                table: "IndicadorPOAs",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                schema: "planifica",
                table: "IndicadorPOAs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Actor",
                schema: "planifica",
                table: "IndicadorEstrategicos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                schema: "planifica",
                table: "IndicadorEstrategicos",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                schema: "planifica",
                table: "IndicadorEstrategicos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductoObjetivos",
                schema: "planifica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Producto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdObjetivoEstra = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoObjetivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductoObjetivos_ObjetivoEstrategicos_IdObjetivoEstra",
                        column: x => x.IdObjetivoEstra,
                        principalSchema: "planifica",
                        principalTable: "ObjetivoEstrategicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndicadorProductoObjetivos",
                schema: "planifica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Indicador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnioFiscal = table.Column<int>(type: "int", nullable: false),
                    IdProductoObjetivo = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicadorProductoObjetivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndicadorProductoObjetivos_ProductoObjetivos_IdProductoObjetivo",
                        column: x => x.IdProductoObjetivo,
                        principalSchema: "planifica",
                        principalTable: "ProductoObjetivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndicadorProductoObjetivos_IdProductoObjetivo",
                schema: "planifica",
                table: "IndicadorProductoObjetivos",
                column: "IdProductoObjetivo");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoObjetivos_IdObjetivoEstra",
                schema: "planifica",
                table: "ProductoObjetivos",
                column: "IdObjetivoEstra");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndicadorProductoObjetivos",
                schema: "planifica");

            migrationBuilder.DropTable(
                name: "ProductoObjetivos",
                schema: "planifica");

            migrationBuilder.DropColumn(
                name: "Actor",
                schema: "planifica",
                table: "IndicadorPOAs");

            migrationBuilder.DropColumn(
                name: "Codigo",
                schema: "planifica",
                table: "IndicadorPOAs");

            migrationBuilder.DropColumn(
                name: "Tipo",
                schema: "planifica",
                table: "IndicadorPOAs");

            migrationBuilder.DropColumn(
                name: "Actor",
                schema: "planifica",
                table: "IndicadorEstrategicos");

            migrationBuilder.DropColumn(
                name: "Codigo",
                schema: "planifica",
                table: "IndicadorEstrategicos");

            migrationBuilder.DropColumn(
                name: "Tipo",
                schema: "planifica",
                table: "IndicadorEstrategicos");
        }
    }
}
