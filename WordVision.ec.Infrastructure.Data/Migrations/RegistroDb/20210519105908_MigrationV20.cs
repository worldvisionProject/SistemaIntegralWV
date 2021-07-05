using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb
{
    public partial class MigrationV20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnioIngreso",
                schema: "pres",
                table: "Presupuestos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MesIngreso",
                schema: "pres",
                table: "Presupuestos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnioIngreso",
                schema: "pres",
                table: "DatosLDRs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MesIngreso",
                schema: "pres",
                table: "DatosLDRs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PorceImputado",
                schema: "pres",
                table: "DatosLDRs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalGasto",
                schema: "pres",
                table: "DatosLDRs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorImputado",
                schema: "pres",
                table: "DatosLDRs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnioIngreso",
                schema: "pres",
                table: "Presupuestos");

            migrationBuilder.DropColumn(
                name: "MesIngreso",
                schema: "pres",
                table: "Presupuestos");

            migrationBuilder.DropColumn(
                name: "AnioIngreso",
                schema: "pres",
                table: "DatosLDRs");

            migrationBuilder.DropColumn(
                name: "MesIngreso",
                schema: "pres",
                table: "DatosLDRs");

            migrationBuilder.DropColumn(
                name: "PorceImputado",
                schema: "pres",
                table: "DatosLDRs");

            migrationBuilder.DropColumn(
                name: "TotalGasto",
                schema: "pres",
                table: "DatosLDRs");

            migrationBuilder.DropColumn(
                name: "ValorImputado",
                schema: "pres",
                table: "DatosLDRs");
        }
    }
}
