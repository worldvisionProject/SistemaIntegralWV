using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev1
{
    public partial class MigrationV017 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaSolicitante",
                schema: "soporte",
                table: "Comunicaciones");

            migrationBuilder.DropColumn(
                name: "AutorizacióndelLíderInmediato",
                schema: "soporte",
                table: "Comunicaciones");

            migrationBuilder.DropColumn(
                name: "DescripciónProducto",
                schema: "soporte",
                table: "Comunicaciones");

            migrationBuilder.DropColumn(
                name: "DisponibilidadPresupuestaria",
                schema: "soporte",
                table: "Comunicaciones");

            migrationBuilder.DropColumn(
                name: "DocumentoBasedeTrabajo",
                schema: "soporte",
                table: "Comunicaciones");

            migrationBuilder.DropColumn(
                name: "FechaRequiereProducto",
                schema: "soporte",
                table: "Comunicaciones");

            migrationBuilder.DropColumn(
                name: "FechadelEvento",
                schema: "soporte",
                table: "Comunicaciones");

            migrationBuilder.DropColumn(
                name: "GuionMinuto_a_MinutoEvento",
                schema: "soporte",
                table: "Comunicaciones");

            migrationBuilder.DropColumn(
                name: "Informativo",
                schema: "soporte",
                table: "Comunicaciones");

            migrationBuilder.DropColumn(
                name: "NumSolicitud",
                schema: "soporte",
                table: "Comunicaciones");

            migrationBuilder.DropColumn(
                name: "NumdeTicketTI",
                schema: "soporte",
                table: "Comunicaciones");

            migrationBuilder.DropColumn(
                name: "NúmerodeParticipantesEstimado",
                schema: "soporte",
                table: "Comunicaciones");

            migrationBuilder.RenameColumn(
                name: "TransmisiónVirtual",
                schema: "soporte",
                table: "Comunicaciones",
                newName: "TransmisionVirtual");

            migrationBuilder.RenameColumn(
                name: "SociosQuienesInteractuar",
                schema: "soporte",
                table: "Comunicaciones",
                newName: "SociosInteractuar");

            migrationBuilder.RenameColumn(
                name: "SituacionesInteresParaWorldVision",
                schema: "soporte",
                table: "Comunicaciones",
                newName: "SituacionesInteresWV");

            migrationBuilder.RenameColumn(
                name: "Responsable",
                schema: "soporte",
                table: "Comunicaciones",
                newName: "NumeroParticipantes");

            migrationBuilder.RenameColumn(
                name: "PúblicoObjetivo",
                schema: "soporte",
                table: "Comunicaciones",
                newName: "PersonasAsistiran");

            migrationBuilder.RenameColumn(
                name: "PersonasAutoridadesAsistirán",
                schema: "soporte",
                table: "Comunicaciones",
                newName: "PersonalWV");

            migrationBuilder.RenameColumn(
                name: "PersonalWVInvolucrado",
                schema: "soporte",
                table: "Comunicaciones",
                newName: "ObjetivoEvento");

            migrationBuilder.RenameColumn(
                name: "ObjetivodelEvento",
                schema: "soporte",
                table: "Comunicaciones",
                newName: "NombreEvento");

            migrationBuilder.RenameColumn(
                name: "ObjetivoProducto",
                schema: "soporte",
                table: "Comunicaciones",
                newName: "LogosSocios");

            migrationBuilder.RenameColumn(
                name: "NombredelEvento",
                schema: "soporte",
                table: "Comunicaciones",
                newName: "GuionEvento");

            migrationBuilder.RenameColumn(
                name: "LogosSociosInvolucrados",
                schema: "soporte",
                table: "Comunicaciones",
                newName: "DocumentoBase");

            migrationBuilder.RenameColumn(
                name: "HoradelEvento",
                schema: "soporte",
                table: "Comunicaciones",
                newName: "HoraEvento");

            migrationBuilder.AddColumn<int>(
                name: "TipoSistema",
                schema: "soporte",
                table: "Solicitudes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaEvento",
                schema: "soporte",
                table: "Comunicaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoSistema",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "FechaEvento",
                schema: "soporte",
                table: "Comunicaciones");

            migrationBuilder.RenameColumn(
                name: "TransmisionVirtual",
                schema: "soporte",
                table: "Comunicaciones",
                newName: "TransmisiónVirtual");

            migrationBuilder.RenameColumn(
                name: "SociosInteractuar",
                schema: "soporte",
                table: "Comunicaciones",
                newName: "SociosQuienesInteractuar");

            migrationBuilder.RenameColumn(
                name: "SituacionesInteresWV",
                schema: "soporte",
                table: "Comunicaciones",
                newName: "SituacionesInteresParaWorldVision");

            migrationBuilder.RenameColumn(
                name: "PersonasAsistiran",
                schema: "soporte",
                table: "Comunicaciones",
                newName: "PúblicoObjetivo");

            migrationBuilder.RenameColumn(
                name: "PersonalWV",
                schema: "soporte",
                table: "Comunicaciones",
                newName: "PersonasAutoridadesAsistirán");

            migrationBuilder.RenameColumn(
                name: "ObjetivoEvento",
                schema: "soporte",
                table: "Comunicaciones",
                newName: "PersonalWVInvolucrado");

            migrationBuilder.RenameColumn(
                name: "NumeroParticipantes",
                schema: "soporte",
                table: "Comunicaciones",
                newName: "Responsable");

            migrationBuilder.RenameColumn(
                name: "NombreEvento",
                schema: "soporte",
                table: "Comunicaciones",
                newName: "ObjetivodelEvento");

            migrationBuilder.RenameColumn(
                name: "LogosSocios",
                schema: "soporte",
                table: "Comunicaciones",
                newName: "ObjetivoProducto");

            migrationBuilder.RenameColumn(
                name: "HoraEvento",
                schema: "soporte",
                table: "Comunicaciones",
                newName: "HoradelEvento");

            migrationBuilder.RenameColumn(
                name: "GuionEvento",
                schema: "soporte",
                table: "Comunicaciones",
                newName: "NombredelEvento");

            migrationBuilder.RenameColumn(
                name: "DocumentoBase",
                schema: "soporte",
                table: "Comunicaciones",
                newName: "LogosSociosInvolucrados");

            migrationBuilder.AddColumn<int>(
                name: "AreaSolicitante",
                schema: "soporte",
                table: "Comunicaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AutorizacióndelLíderInmediato",
                schema: "soporte",
                table: "Comunicaciones",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescripciónProducto",
                schema: "soporte",
                table: "Comunicaciones",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisponibilidadPresupuestaria",
                schema: "soporte",
                table: "Comunicaciones",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentoBasedeTrabajo",
                schema: "soporte",
                table: "Comunicaciones",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRequiereProducto",
                schema: "soporte",
                table: "Comunicaciones",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechadelEvento",
                schema: "soporte",
                table: "Comunicaciones",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GuionMinuto_a_MinutoEvento",
                schema: "soporte",
                table: "Comunicaciones",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Informativo",
                schema: "soporte",
                table: "Comunicaciones",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumSolicitud",
                schema: "soporte",
                table: "Comunicaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumdeTicketTI",
                schema: "soporte",
                table: "Comunicaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NúmerodeParticipantesEstimado",
                schema: "soporte",
                table: "Comunicaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
