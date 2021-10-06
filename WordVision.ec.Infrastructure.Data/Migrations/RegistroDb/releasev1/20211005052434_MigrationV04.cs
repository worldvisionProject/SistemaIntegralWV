using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev1
{
    public partial class MigrationV04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageCedula",
                table: "Tercero",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageCedula",
                table: "Formularios",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageCovid",
                table: "Formularios",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageDiscapacidad",
                table: "Formularios",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageDiscapacidadFamiliar",
                table: "Formularios",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImagePapeleta",
                table: "Formularios",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageCedula",
                table: "Tercero");

            migrationBuilder.DropColumn(
                name: "ImageCedula",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "ImageCovid",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "ImageDiscapacidad",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "ImageDiscapacidadFamiliar",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "ImagePapeleta",
                table: "Formularios");
        }
    }
}
