using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class MigrationV3G009 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaBaja",
                schema: "donacion",
                table: "Donantes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotivosBaja",
                schema: "donacion",
                table: "Donantes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaBaja",
                schema: "donacion",
                table: "Donantes");

            migrationBuilder.DropColumn(
                name: "MotivosBaja",
                schema: "donacion",
                table: "Donantes");
        }
    }
}
