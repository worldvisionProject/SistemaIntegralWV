using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev1
{
    public partial class MigrationV029 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MetaCicloEstrategico",
                schema: "planifica");

            migrationBuilder.AddColumn<decimal>(
                name: "Logro",
                schema: "planifica",
                table: "IndicadorProductoObjetivos",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Meta",
                schema: "planifica",
                table: "IndicadorProductoObjetivos",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnioFiscal",
                schema: "planifica",
                table: "IndicadorCicloEstrategico",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Logro",
                schema: "planifica",
                table: "IndicadorCicloEstrategico",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Meta",
                schema: "planifica",
                table: "IndicadorCicloEstrategico",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logro",
                schema: "planifica",
                table: "IndicadorProductoObjetivos");

            migrationBuilder.DropColumn(
                name: "Meta",
                schema: "planifica",
                table: "IndicadorProductoObjetivos");

            migrationBuilder.DropColumn(
                name: "AnioFiscal",
                schema: "planifica",
                table: "IndicadorCicloEstrategico");

            migrationBuilder.DropColumn(
                name: "Logro",
                schema: "planifica",
                table: "IndicadorCicloEstrategico");

            migrationBuilder.DropColumn(
                name: "Meta",
                schema: "planifica",
                table: "IndicadorCicloEstrategico");

            migrationBuilder.CreateTable(
                name: "MetaCicloEstrategico",
                schema: "planifica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdGestion = table.Column<int>(type: "int", nullable: false),
                    IdIndicadorCicloEstrategico = table.Column<int>(type: "int", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Meta = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaCicloEstrategico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetaCicloEstrategico_IndicadorCicloEstrategico_IdIndicadorCicloEstrategico",
                        column: x => x.IdIndicadorCicloEstrategico,
                        principalSchema: "planifica",
                        principalTable: "IndicadorCicloEstrategico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MetaCicloEstrategico_IdIndicadorCicloEstrategico",
                schema: "planifica",
                table: "MetaCicloEstrategico",
                column: "IdIndicadorCicloEstrategico");
        }
    }
}
