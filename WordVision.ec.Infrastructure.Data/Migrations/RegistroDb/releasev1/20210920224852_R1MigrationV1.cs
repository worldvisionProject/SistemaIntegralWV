using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev1
{
    public partial class R1MigrationV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "soporte");

            migrationBuilder.CreateTable(
                name: "Donantes",
                schema: "soporte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDHubspot = table.Column<int>(type: "int", nullable: false),
                    FechaConversion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Canal = table.Column<int>(type: "int", nullable: false),
                    Responsable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Categoria = table.Column<int>(type: "int", nullable: false),
                    Campana = table.Column<int>(type: "int", nullable: false),
                    EstadoDonante = table.Column<int>(type: "int", nullable: false),
                    Nombre1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    Cedula = table.Column<int>(type: "int", nullable: false),
                    RUC = table.Column<int>(type: "int", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Region = table.Column<int>(type: "int", nullable: false),
                    Provincia = table.Column<int>(type: "int", nullable: false),
                    Ciudad = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoConvencional = table.Column<int>(type: "int", nullable: false),
                    TelefonoCelular = table.Column<int>(type: "int", nullable: false),
                    WhatsApp = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrecuenciaDonacion = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    MesInicialDebito = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FormaPago = table.Column<int>(type: "int", nullable: false),
                    NumReferencia = table.Column<int>(type: "int", nullable: false),
                    TipoCuenta = table.Column<int>(type: "int", nullable: false),
                    NumeroCuenta = table.Column<int>(type: "int", nullable: false),
                    TiposTarjetasCredito = table.Column<int>(type: "int", nullable: false),
                    NumeroTarjeta = table.Column<int>(type: "int", nullable: false),
                    FechaCaducidad = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Banco = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                schema: "soporte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSolicitud = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    FechaEnvioEmail = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonaEnvioEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personales",
                schema: "soporte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPersonal = table.Column<int>(type: "int", nullable: false),
                    IdArea = table.Column<int>(type: "int", nullable: false),
                    IdPersona = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ponentes",
                schema: "soporte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Perfil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ponentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Solicitudes",
                schema: "soporte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoSistema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Solicitante = table.Column<int>(type: "int", nullable: false),
                    PersonaaContactar = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    FechaRequerida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ruta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreArchivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TiposTramites = table.Column<int>(type: "int", nullable: false),
                    DescripcionTramite = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    InformacionAdicional = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AsignadoA = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    DescripcionSolucion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObservacionesSolucion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoSatisfaccion = table.Column<int>(type: "int", nullable: false),
                    NumSolicitud = table.Column<int>(type: "int", nullable: false),
                    TipoSolicitud = table.Column<int>(type: "int", nullable: false),
                    AreaSolicitante = table.Column<int>(type: "int", nullable: false),
                    FechaSolicitud = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Presupuesto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DisponibilidadPresupuestaria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutorizacióndelLíderInmediato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Informativo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Responsable = table.Column<int>(type: "int", nullable: false),
                    NumdeTicketTI = table.Column<int>(type: "int", nullable: false),
                    NombredelEvento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechadelEvento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoradelEvento = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    FechaRequiereProducto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DescripciónProducto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjetivoProducto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicoObjetivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MensajeClave = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentoBasedeTrabajo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitudes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadosSolicitudes",
                schema: "soporte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    IdSolicitud = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosSolicitudes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstadosSolicitudes_Solicitudes_IdSolicitud",
                        column: x => x.IdSolicitud,
                        principalSchema: "soporte",
                        principalTable: "Solicitudes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstadosSolicitudes_IdSolicitud",
                schema: "soporte",
                table: "EstadosSolicitudes",
                column: "IdSolicitud");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donantes",
                schema: "soporte");

            migrationBuilder.DropTable(
                name: "Emails",
                schema: "soporte");

            migrationBuilder.DropTable(
                name: "EstadosSolicitudes",
                schema: "soporte");

            migrationBuilder.DropTable(
                name: "Personales",
                schema: "soporte");

            migrationBuilder.DropTable(
                name: "Ponentes",
                schema: "soporte");

            migrationBuilder.DropTable(
                name: "Solicitudes",
                schema: "soporte");
        }
    }
}
