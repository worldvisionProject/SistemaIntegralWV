using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev1
{
    public partial class MigrationV06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreArchivo",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "Ruta",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.AddColumn<byte[]>(
                name: "Archivo",
                schema: "soporte",
                table: "Solicitudes",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Archivo",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.AddColumn<string>(
                name: "NombreArchivo",
                schema: "soporte",
                table: "Solicitudes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ruta",
                schema: "soporte",
                table: "Solicitudes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
