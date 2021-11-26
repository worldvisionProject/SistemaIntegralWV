using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb
{
    public partial class MigrationV10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApellidoMaterno",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "ApellidoPaterno",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "Identificacion",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "PrimerNombre",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "SegundoNombre",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "RutaFirma",
                table: "Firmas");

            migrationBuilder.AlterColumn<string>(
                name: "CuentaBancaria",
                table: "Formularios",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Formularios",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Firmas",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Firmas");

            migrationBuilder.AlterColumn<string>(
                name: "CuentaBancaria",
                table: "Formularios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<string>(
                name: "ApellidoMaterno",
                table: "Formularios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApellidoPaterno",
                table: "Formularios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Formularios",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Identificacion",
                table: "Formularios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PrimerNombre",
                table: "Formularios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SegundoNombre",
                table: "Formularios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RutaFirma",
                table: "Firmas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
