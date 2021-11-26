using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev1
{
    public partial class MigrationV021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentoBase",
                schema: "soporte",
                table: "Comunicaciones");

            migrationBuilder.DropColumn(
                name: "FechaSolicitud",
                schema: "soporte",
                table: "Comunicaciones");

            migrationBuilder.AddColumn<int>(
                name: "IdComunicacion",
                schema: "soporte",
                table: "Ponentes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PersonaaContactar",
                schema: "soporte",
                table: "Mensajerias",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InformacionAdicional",
                schema: "soporte",
                table: "Mensajerias",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                schema: "soporte",
                table: "Mensajerias",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DescripcionTramite",
                schema: "soporte",
                table: "Mensajerias",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PublicoObjetivo",
                schema: "soporte",
                table: "Comunicaciones",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ObjetivoEvento",
                schema: "soporte",
                table: "Comunicaciones",
                type: "nvarchar(550)",
                maxLength: 550,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NombreEvento",
                schema: "soporte",
                table: "Comunicaciones",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LugarEvento",
                schema: "soporte",
                table: "Comunicaciones",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HoraEvento",
                schema: "soporte",
                table: "Comunicaciones",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "DisponibilidadPresupuestaria",
                schema: "soporte",
                table: "Comunicaciones",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "AutorizaciondelLider",
                schema: "soporte",
                table: "Comunicaciones",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdComunicacion",
                schema: "soporte",
                table: "Comunicaciones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LogoSocio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Socio = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Logo = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IdComunicacion = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogoSocio", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comunicaciones_IdComunicacion",
                schema: "soporte",
                table: "Comunicaciones",
                column: "IdComunicacion",
                unique: true,
                filter: "[IdComunicacion] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Comunicaciones_LogoSocio_IdComunicacion",
                schema: "soporte",
                table: "Comunicaciones",
                column: "IdComunicacion",
                principalTable: "LogoSocio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comunicaciones_Ponentes_IdComunicacion",
                schema: "soporte",
                table: "Comunicaciones",
                column: "IdComunicacion",
                principalSchema: "soporte",
                principalTable: "Ponentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comunicaciones_LogoSocio_IdComunicacion",
                schema: "soporte",
                table: "Comunicaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Comunicaciones_Ponentes_IdComunicacion",
                schema: "soporte",
                table: "Comunicaciones");

            migrationBuilder.DropTable(
                name: "LogoSocio");

            migrationBuilder.DropIndex(
                name: "IX_Comunicaciones_IdComunicacion",
                schema: "soporte",
                table: "Comunicaciones");

            migrationBuilder.DropColumn(
                name: "IdComunicacion",
                schema: "soporte",
                table: "Ponentes");

            migrationBuilder.DropColumn(
                name: "IdComunicacion",
                schema: "soporte",
                table: "Comunicaciones");

            migrationBuilder.AlterColumn<string>(
                name: "PersonaaContactar",
                schema: "soporte",
                table: "Mensajerias",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "InformacionAdicional",
                schema: "soporte",
                table: "Mensajerias",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                schema: "soporte",
                table: "Mensajerias",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "DescripcionTramite",
                schema: "soporte",
                table: "Mensajerias",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "PublicoObjetivo",
                schema: "soporte",
                table: "Comunicaciones",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "ObjetivoEvento",
                schema: "soporte",
                table: "Comunicaciones",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(550)",
                oldMaxLength: 550);

            migrationBuilder.AlterColumn<string>(
                name: "NombreEvento",
                schema: "soporte",
                table: "Comunicaciones",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "LugarEvento",
                schema: "soporte",
                table: "Comunicaciones",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "HoraEvento",
                schema: "soporte",
                table: "Comunicaciones",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<byte[]>(
                name: "DisponibilidadPresupuestaria",
                schema: "soporte",
                table: "Comunicaciones",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "AutorizaciondelLider",
                schema: "soporte",
                table: "Comunicaciones",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AddColumn<string>(
                name: "DocumentoBase",
                schema: "soporte",
                table: "Comunicaciones",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaSolicitud",
                schema: "soporte",
                table: "Comunicaciones",
                type: "datetime2",
                nullable: true);
        }
    }
}
