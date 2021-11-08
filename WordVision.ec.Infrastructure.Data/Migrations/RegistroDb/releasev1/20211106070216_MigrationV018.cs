using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev1
{
    public partial class MigrationV018 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "AutorizaciondelLider",
                schema: "soporte",
                table: "Comunicaciones",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "DisponibilidadPresupuestaria",
                schema: "soporte",
                table: "Comunicaciones",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutorizaciondelLider",
                schema: "soporte",
                table: "Comunicaciones");

            migrationBuilder.DropColumn(
                name: "DisponibilidadPresupuestaria",
                schema: "soporte",
                table: "Comunicaciones");
        }
    }
}
