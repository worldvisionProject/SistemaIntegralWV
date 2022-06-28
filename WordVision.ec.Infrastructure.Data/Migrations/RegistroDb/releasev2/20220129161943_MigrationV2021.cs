using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class MigrationV2021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnioFiscal2",
                schema: "planifica",
                table: "IndicadorCicloEstrategico",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnioFiscal3",
                schema: "planifica",
                table: "IndicadorCicloEstrategico",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnioFiscal4",
                schema: "planifica",
                table: "IndicadorCicloEstrategico",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "LineBase",
                schema: "planifica",
                table: "IndicadorCicloEstrategico",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "LineBase2",
                schema: "planifica",
                table: "IndicadorCicloEstrategico",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "LineBase3",
                schema: "planifica",
                table: "IndicadorCicloEstrategico",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "LineBase4",
                schema: "planifica",
                table: "IndicadorCicloEstrategico",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Logro2",
                schema: "planifica",
                table: "IndicadorCicloEstrategico",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Logro3",
                schema: "planifica",
                table: "IndicadorCicloEstrategico",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Logro4",
                schema: "planifica",
                table: "IndicadorCicloEstrategico",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Meta2",
                schema: "planifica",
                table: "IndicadorCicloEstrategico",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Meta3",
                schema: "planifica",
                table: "IndicadorCicloEstrategico",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Meta4",
                schema: "planifica",
                table: "IndicadorCicloEstrategico",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnioFiscal2",
                schema: "planifica",
                table: "IndicadorCicloEstrategico");

            migrationBuilder.DropColumn(
                name: "AnioFiscal3",
                schema: "planifica",
                table: "IndicadorCicloEstrategico");

            migrationBuilder.DropColumn(
                name: "AnioFiscal4",
                schema: "planifica",
                table: "IndicadorCicloEstrategico");

            migrationBuilder.DropColumn(
                name: "LineBase",
                schema: "planifica",
                table: "IndicadorCicloEstrategico");

            migrationBuilder.DropColumn(
                name: "LineBase2",
                schema: "planifica",
                table: "IndicadorCicloEstrategico");

            migrationBuilder.DropColumn(
                name: "LineBase3",
                schema: "planifica",
                table: "IndicadorCicloEstrategico");

            migrationBuilder.DropColumn(
                name: "LineBase4",
                schema: "planifica",
                table: "IndicadorCicloEstrategico");

            migrationBuilder.DropColumn(
                name: "Logro2",
                schema: "planifica",
                table: "IndicadorCicloEstrategico");

            migrationBuilder.DropColumn(
                name: "Logro3",
                schema: "planifica",
                table: "IndicadorCicloEstrategico");

            migrationBuilder.DropColumn(
                name: "Logro4",
                schema: "planifica",
                table: "IndicadorCicloEstrategico");

            migrationBuilder.DropColumn(
                name: "Meta2",
                schema: "planifica",
                table: "IndicadorCicloEstrategico");

            migrationBuilder.DropColumn(
                name: "Meta3",
                schema: "planifica",
                table: "IndicadorCicloEstrategico");

            migrationBuilder.DropColumn(
                name: "Meta4",
                schema: "planifica",
                table: "IndicadorCicloEstrategico");
        }
    }
}
