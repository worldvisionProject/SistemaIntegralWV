using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb
{
    public partial class Migrationv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Alergias",
                table: "Formularios",
                type: "nvarchar(1500)",
                maxLength: 1500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CalleResidencia",
                table: "Formularios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CalleSecundariaResidencia",
                table: "Formularios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CedulaDependiente",
                table: "Formularios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CedulaExtranjero",
                table: "Formularios",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Formularios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CelularContacto",
                table: "Formularios",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CiudadResidencia",
                table: "Formularios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CiudadaniaExtranjero",
                table: "Formularios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodigoArea",
                table: "Formularios",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodigoAreaContacto",
                table: "Formularios",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreenciaReligiosa",
                table: "Formularios",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CuentaBancaria",
                table: "Formularios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiscapacidadSN",
                table: "Formularios",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DobleCiudadaniaSN",
                table: "Formularios",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EdadContacto",
                table: "Formularios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Formularios",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmailContacto",
                table: "Formularios",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EstadoCivil",
                table: "Formularios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Etnia",
                table: "Formularios",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "FamiliaDiscapacidad",
                table: "Formularios",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "FamiliaDiscapacidadRelacion",
                table: "Formularios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FamiliaDiscapacidadSN",
                table: "Formularios",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FamiliaPorcentajeDiscapacidad",
                table: "Formularios",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "FamiliaTipoDiscapacidad",
                table: "Formularios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FecNacimientoDependiente",
                table: "Formularios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Formularios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FormacionAcademica",
                table: "Formularios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GeneroDependiente",
                table: "Formularios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Idioma",
                table: "Formularios",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Iglesia",
                table: "Formularios",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoResidencia",
                table: "Formularios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nacionalidad",
                table: "Formularios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumCasaResidencia",
                table: "Formularios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PaisCiudadania",
                table: "Formularios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaisResidencia",
                table: "Formularios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "PorcentajeDiscapacidad",
                table: "Formularios",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PorcentajeEscrito",
                table: "Formularios",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PorcentajeHablado",
                table: "Formularios",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Preexistencia",
                table: "Formularios",
                type: "nvarchar(1500)",
                maxLength: 1500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimerApellidoContacto",
                table: "Formularios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PrimerApellidoDependiente",
                table: "Formularios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimerNombreContacto",
                table: "Formularios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PrimerNombreDependiente",
                table: "Formularios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProvinciaResidencia",
                table: "Formularios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReferenciaResidencia",
                table: "Formularios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SectorResidencia",
                table: "Formularios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SegundoApellidoContacto",
                table: "Formularios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SegundoApellidoDependiente",
                table: "Formularios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SegundoNombreContacto",
                table: "Formularios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SegundoNombreDependiente",
                table: "Formularios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Formularios",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelefonoContacto",
                table: "Formularios",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoContacto",
                table: "Formularios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoDependiente",
                table: "Formularios",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoDiscapacidad",
                table: "Formularios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoSangre",
                table: "Formularios",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "VigDesdeDependiente",
                table: "Formularios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "VigHastaDependiente",
                table: "Formularios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "VigenciaDesde",
                table: "Formularios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "VigenciaHasta",
                table: "Formularios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alergias",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "CalleResidencia",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "CalleSecundariaResidencia",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "CedulaDependiente",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "CedulaExtranjero",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "CelularContacto",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "CiudadResidencia",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "CiudadaniaExtranjero",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "CodigoArea",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "CodigoAreaContacto",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "CreenciaReligiosa",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "CuentaBancaria",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "DiscapacidadSN",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "DobleCiudadaniaSN",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "EdadContacto",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "EmailContacto",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "EstadoCivil",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "Etnia",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "FamiliaDiscapacidad",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "FamiliaDiscapacidadRelacion",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "FamiliaDiscapacidadSN",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "FamiliaPorcentajeDiscapacidad",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "FamiliaTipoDiscapacidad",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "FecNacimientoDependiente",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "FormacionAcademica",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "GeneroDependiente",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "Idioma",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "Iglesia",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "InfoResidencia",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "Nacionalidad",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "NumCasaResidencia",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "PaisCiudadania",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "PaisResidencia",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "PorcentajeDiscapacidad",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "PorcentajeEscrito",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "PorcentajeHablado",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "Preexistencia",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "PrimerApellidoContacto",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "PrimerApellidoDependiente",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "PrimerNombreContacto",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "PrimerNombreDependiente",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "ProvinciaResidencia",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "ReferenciaResidencia",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "SectorResidencia",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "SegundoApellidoContacto",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "SegundoApellidoDependiente",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "SegundoNombreContacto",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "SegundoNombreDependiente",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "TelefonoContacto",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "TipoContacto",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "TipoDependiente",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "TipoDiscapacidad",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "TipoSangre",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "VigDesdeDependiente",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "VigHastaDependiente",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "VigenciaDesde",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "VigenciaHasta",
                table: "Formularios");
        }
    }
}
