using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb
{
    public partial class MigrationV52 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Plazo",
                schema: "planifica",
                table: "Actividades",
                newName: "FechaInicio");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaFin",
                schema: "planifica",
                table: "Actividades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "TotalRecurso",
                schema: "planifica",
                table: "Actividades",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaFin",
                schema: "planifica",
                table: "Actividades");

            migrationBuilder.DropColumn(
                name: "TotalRecurso",
                schema: "planifica",
                table: "Actividades");

            migrationBuilder.RenameColumn(
                name: "FechaInicio",
                schema: "planifica",
                table: "Actividades",
                newName: "Plazo");
        }
    }
}
