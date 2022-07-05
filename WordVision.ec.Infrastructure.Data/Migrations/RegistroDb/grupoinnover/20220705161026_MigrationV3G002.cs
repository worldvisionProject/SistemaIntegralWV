using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.grupoinnover
{
    public partial class MigrationV3G002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CalificacionDonante",
                schema: "donacion",
                table: "Donantes",
                type: "int",
                maxLength: 10,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaEntrega",
                schema: "donacion",
                table: "Donantes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Formulario",
                schema: "donacion",
                table: "Donantes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroGuia",
                schema: "donacion",
                table: "Donantes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PeriodoDonacion",
                schema: "donacion",
                table: "Donantes",
                type: "int",
                maxLength: 10,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Quincena",
                schema: "donacion",
                table: "Debitos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalificacionDonante",
                schema: "donacion",
                table: "Donantes");

            migrationBuilder.DropColumn(
                name: "FechaEntrega",
                schema: "donacion",
                table: "Donantes");

            migrationBuilder.DropColumn(
                name: "Formulario",
                schema: "donacion",
                table: "Donantes");

            migrationBuilder.DropColumn(
                name: "NumeroGuia",
                schema: "donacion",
                table: "Donantes");

            migrationBuilder.DropColumn(
                name: "PeriodoDonacion",
                schema: "donacion",
                table: "Donantes");

            migrationBuilder.AlterColumn<int>(
                name: "Quincena",
                schema: "donacion",
                table: "Debitos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
