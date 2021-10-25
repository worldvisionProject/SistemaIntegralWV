using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev1
{
    public partial class MigrationV012 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BancoBp",
                schema: "soporte",
                table: "Donantes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCaducidadBp",
                schema: "soporte",
                table: "Donantes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumReferenciaBp",
                schema: "soporte",
                table: "Donantes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroCuentaBp",
                schema: "soporte",
                table: "Donantes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroTarjetaBp",
                schema: "soporte",
                table: "Donantes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoCuentaBp",
                schema: "soporte",
                table: "Donantes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TiposTarjetasCreditoBp",
                schema: "soporte",
                table: "Donantes",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BancoBp",
                schema: "soporte",
                table: "Donantes");

            migrationBuilder.DropColumn(
                name: "FechaCaducidadBp",
                schema: "soporte",
                table: "Donantes");

            migrationBuilder.DropColumn(
                name: "NumReferenciaBp",
                schema: "soporte",
                table: "Donantes");

            migrationBuilder.DropColumn(
                name: "NumeroCuentaBp",
                schema: "soporte",
                table: "Donantes");

            migrationBuilder.DropColumn(
                name: "NumeroTarjetaBp",
                schema: "soporte",
                table: "Donantes");

            migrationBuilder.DropColumn(
                name: "TipoCuentaBp",
                schema: "soporte",
                table: "Donantes");

            migrationBuilder.DropColumn(
                name: "TiposTarjetasCreditoBp",
                schema: "soporte",
                table: "Donantes");
        }
    }
}
