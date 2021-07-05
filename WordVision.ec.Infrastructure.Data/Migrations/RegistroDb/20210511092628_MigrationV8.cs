using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb
{
    public partial class MigrationV8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApellidoMaterno",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "ApellidoPaterno",
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
        }
    }
}
