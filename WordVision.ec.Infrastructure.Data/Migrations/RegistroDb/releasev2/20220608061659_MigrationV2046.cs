using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class MigrationV2046 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Evidencia",
                schema: "valoracion",
                table: "PlanificacionResultados",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Evidencia",
                schema: "valoracion",
                table: "AvanceObjetivos",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Evidencia",
                schema: "valoracion",
                table: "PlanificacionResultados");

            migrationBuilder.DropColumn(
                name: "Evidencia",
                schema: "valoracion",
                table: "AvanceObjetivos");
        }
    }
}
