using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb
{
    public partial class MigrationV12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CedulaDependiente",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "CelularContacto",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "CodigoAreaContacto",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "EdadContacto",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "EmailContacto",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "FecNacimientoDependiente",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "GeneroDependiente",
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
                name: "TelefonoContacto",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "TipoContacto",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "TipoDependiente",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "VigDesdeDependiente",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "VigHastaDependiente",
                table: "Formularios");

            migrationBuilder.CreateTable(
                name: "Tercero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Identificacion = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    PrimerApellido = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SegundoApellido = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PrimerNombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SegundoNombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FecNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    VigDesde = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VigHasta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodigoArea = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tercero", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormularioTercero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFormulario = table.Column<int>(type: "int", nullable: false),
                    IdTercero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTeceroFormulario = table.Column<int>(type: "int", nullable: true),
                    IdFormularioTecero = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormularioTercero", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormularioTercero_Formularios_IdFormularioTecero",
                        column: x => x.IdFormularioTecero,
                        principalTable: "Formularios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FormularioTercero_Tercero_IdTeceroFormulario",
                        column: x => x.IdTeceroFormulario,
                        principalTable: "Tercero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormularioTercero_IdFormularioTecero",
                table: "FormularioTercero",
                column: "IdFormularioTecero");

            migrationBuilder.CreateIndex(
                name: "IX_FormularioTercero_IdTeceroFormulario",
                table: "FormularioTercero",
                column: "IdTeceroFormulario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormularioTercero");

            migrationBuilder.DropTable(
                name: "Tercero");

            migrationBuilder.AddColumn<string>(
                name: "CedulaDependiente",
                table: "Formularios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CelularContacto",
                table: "Formularios",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CodigoAreaContacto",
                table: "Formularios",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EdadContacto",
                table: "Formularios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EmailContacto",
                table: "Formularios",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FecNacimientoDependiente",
                table: "Formularios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "GeneroDependiente",
                table: "Formularios",
                type: "nvarchar(50)",
                maxLength: 50,
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
        }
    }
}
