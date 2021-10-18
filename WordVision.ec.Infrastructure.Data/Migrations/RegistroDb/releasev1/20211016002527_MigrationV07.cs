using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev1
{
    public partial class MigrationV07 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Archivo",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "AreaSolicitante",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "AutorizacióndelLíderInmediato",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "Celular",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "DescripcionTramite",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "DescripciónProducto",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "Direccion",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "DisponibilidadPresupuestaria",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "DocumentoBasedeTrabajo",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "FechaRequerida",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "FechaRequiereProducto",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "FechaSolicitud",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "FechadelEvento",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "GuionMinuto_a_MinutoEvento",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "HoradelEvento",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "InformacionAdicional",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "Informativo",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "LogosSociosInvolucrados",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "LugarEvento",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "MensajeClave",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "NombredelEvento",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "NumSolicitud",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "NumdeTicketTI",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "NúmerodeParticipantesEstimado",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "ObjetivoProducto",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "ObjetivodelEvento",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "PersonaaContactar",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "PersonalWVInvolucrado",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "PersonasAutoridadesAsistirán",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "Presupuesto",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "PublicoObjetivo",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "PúblicoObjetivo",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "Responsable",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "SituacionesInteresParaWorldVision",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "SociosQuienesInteractuar",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "Solicitante",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "Telefono",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "TipoSistema",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "TransmisiónVirtual",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.RenameColumn(
                name: "TiposTramites",
                schema: "soporte",
                table: "Solicitudes",
                newName: "IdColaborador");

            migrationBuilder.RenameColumn(
                name: "TipoSolicitud",
                schema: "soporte",
                table: "Solicitudes",
                newName: "IdAsignadoA");

            migrationBuilder.AlterColumn<string>(
                name: "AsignadoA",
                schema: "soporte",
                table: "Solicitudes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdSolicitud",
                schema: "soporte",
                table: "Solicitudes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Comunicacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumSolicitud = table.Column<int>(type: "int", nullable: false),
                    TipoSolicitud = table.Column<int>(type: "int", nullable: false),
                    AreaSolicitante = table.Column<int>(type: "int", nullable: false),
                    FechaSolicitud = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Presupuesto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DisponibilidadPresupuestaria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutorizacióndelLíderInmediato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Informativo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Responsable = table.Column<int>(type: "int", nullable: false),
                    NumdeTicketTI = table.Column<int>(type: "int", nullable: false),
                    NombredelEvento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechadelEvento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoradelEvento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LugarEvento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjetivodelEvento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PúblicoObjetivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NúmerodeParticipantesEstimado = table.Column<int>(type: "int", nullable: false),
                    TransmisiónVirtual = table.Column<bool>(type: "bit", nullable: false),
                    GuionMinuto_a_MinutoEvento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogosSociosInvolucrados = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonasAutoridadesAsistirán = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalWVInvolucrado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SituacionesInteresParaWorldVision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SociosQuienesInteractuar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRequiereProducto = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DescripciónProducto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjetivoProducto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicoObjetivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MensajeClave = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentoBasedeTrabajo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdSolicitud = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comunicacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mensajeria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaaContactar = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    FechaRequerida = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Archivo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    TiposTramites = table.Column<int>(type: "int", nullable: false),
                    DescripcionTramite = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    InformacionAdicional = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IdSolicitud = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensajeria", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_IdColaborador",
                schema: "soporte",
                table: "Solicitudes",
                column: "IdColaborador");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_IdSolicitud",
                schema: "soporte",
                table: "Solicitudes",
                column: "IdSolicitud",
                unique: true,
                filter: "[IdSolicitud] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitudes_Colaboradores_IdColaborador",
                schema: "soporte",
                table: "Solicitudes",
                column: "IdColaborador",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitudes_Comunicacion_IdSolicitud",
                schema: "soporte",
                table: "Solicitudes",
                column: "IdSolicitud",
                principalTable: "Comunicacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitudes_Mensajeria_IdSolicitud",
                schema: "soporte",
                table: "Solicitudes",
                column: "IdSolicitud",
                principalTable: "Mensajeria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solicitudes_Colaboradores_IdColaborador",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitudes_Comunicacion_IdSolicitud",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitudes_Mensajeria_IdSolicitud",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropTable(
                name: "Comunicacion");

            migrationBuilder.DropTable(
                name: "Mensajeria");

            migrationBuilder.DropIndex(
                name: "IX_Solicitudes_IdColaborador",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropIndex(
                name: "IX_Solicitudes_IdSolicitud",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "IdSolicitud",
                schema: "soporte",
                table: "Solicitudes");

            migrationBuilder.RenameColumn(
                name: "IdColaborador",
                schema: "soporte",
                table: "Solicitudes",
                newName: "TiposTramites");

            migrationBuilder.RenameColumn(
                name: "IdAsignadoA",
                schema: "soporte",
                table: "Solicitudes",
                newName: "TipoSolicitud");

            migrationBuilder.AlterColumn<int>(
                name: "AsignadoA",
                schema: "soporte",
                table: "Solicitudes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Archivo",
                schema: "soporte",
                table: "Solicitudes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AreaSolicitante",
                schema: "soporte",
                table: "Solicitudes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AutorizacióndelLíderInmediato",
                schema: "soporte",
                table: "Solicitudes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                schema: "soporte",
                table: "Solicitudes",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescripcionTramite",
                schema: "soporte",
                table: "Solicitudes",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescripciónProducto",
                schema: "soporte",
                table: "Solicitudes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                schema: "soporte",
                table: "Solicitudes",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisponibilidadPresupuestaria",
                schema: "soporte",
                table: "Solicitudes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentoBasedeTrabajo",
                schema: "soporte",
                table: "Solicitudes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRequerida",
                schema: "soporte",
                table: "Solicitudes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRequiereProducto",
                schema: "soporte",
                table: "Solicitudes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaSolicitud",
                schema: "soporte",
                table: "Solicitudes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechadelEvento",
                schema: "soporte",
                table: "Solicitudes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "GuionMinuto_a_MinutoEvento",
                schema: "soporte",
                table: "Solicitudes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "HoradelEvento",
                schema: "soporte",
                table: "Solicitudes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "InformacionAdicional",
                schema: "soporte",
                table: "Solicitudes",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Informativo",
                schema: "soporte",
                table: "Solicitudes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogosSociosInvolucrados",
                schema: "soporte",
                table: "Solicitudes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LugarEvento",
                schema: "soporte",
                table: "Solicitudes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MensajeClave",
                schema: "soporte",
                table: "Solicitudes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombredelEvento",
                schema: "soporte",
                table: "Solicitudes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumSolicitud",
                schema: "soporte",
                table: "Solicitudes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumdeTicketTI",
                schema: "soporte",
                table: "Solicitudes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NúmerodeParticipantesEstimado",
                schema: "soporte",
                table: "Solicitudes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ObjetivoProducto",
                schema: "soporte",
                table: "Solicitudes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObjetivodelEvento",
                schema: "soporte",
                table: "Solicitudes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonaaContactar",
                schema: "soporte",
                table: "Solicitudes",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonalWVInvolucrado",
                schema: "soporte",
                table: "Solicitudes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonasAutoridadesAsistirán",
                schema: "soporte",
                table: "Solicitudes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Presupuesto",
                schema: "soporte",
                table: "Solicitudes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "PublicoObjetivo",
                schema: "soporte",
                table: "Solicitudes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PúblicoObjetivo",
                schema: "soporte",
                table: "Solicitudes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Responsable",
                schema: "soporte",
                table: "Solicitudes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SituacionesInteresParaWorldVision",
                schema: "soporte",
                table: "Solicitudes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SociosQuienesInteractuar",
                schema: "soporte",
                table: "Solicitudes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Solicitante",
                schema: "soporte",
                table: "Solicitudes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                schema: "soporte",
                table: "Solicitudes",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoSistema",
                schema: "soporte",
                table: "Solicitudes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TransmisiónVirtual",
                schema: "soporte",
                table: "Solicitudes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
