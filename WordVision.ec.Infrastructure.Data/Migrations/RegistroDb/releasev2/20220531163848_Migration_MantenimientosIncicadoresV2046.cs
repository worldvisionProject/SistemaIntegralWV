using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class Migration_MantenimientosIncicadoresV2046 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActorParticipantes",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ActoresParticipantes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorParticipantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActorParticipantes_DetalleCatalogos_IdEstado",
                        column: x => x.IdEstado,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EtapaModeloProyectos",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Etapa = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IdAccionOperativa = table.Column<int>(type: "int", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtapaModeloProyectos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EtapaModeloProyectos_DetalleCatalogos_IdAccionOperativa",
                        column: x => x.IdAccionOperativa,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EtapaModeloProyectos_DetalleCatalogos_IdEstado",
                        column: x => x.IdEstado,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LogFrames",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OutCome = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    OutPut = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Activity = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    SumaryObjetives = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IdNivel = table.Column<int>(type: "int", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogFrames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogFrames_DetalleCatalogos_IdEstado",
                        column: x => x.IdEstado,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LogFrames_DetalleCatalogos_IdNivel",
                        column: x => x.IdNivel,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProyectoTecnicos",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NombreProyecto = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IdUbicacion = table.Column<int>(type: "int", nullable: false),
                    IdFinanciamiento = table.Column<int>(type: "int", nullable: false),
                    IdTipoProyecto = table.Column<int>(type: "int", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProyectoTecnicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProyectoTecnicos_DetalleCatalogos_IdEstado",
                        column: x => x.IdEstado,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProyectoTecnicos_DetalleCatalogos_IdFinanciamiento",
                        column: x => x.IdFinanciamiento,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProyectoTecnicos_DetalleCatalogos_IdTipoProyecto",
                        column: x => x.IdTipoProyecto,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProyectoTecnicos_DetalleCatalogos_IdUbicacion",
                        column: x => x.IdUbicacion,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ModeloProyectos",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IdEtapaModeloProyecto = table.Column<int>(type: "int", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloProyectos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModeloProyectos_DetalleCatalogos_IdEstado",
                        column: x => x.IdEstado,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ModeloProyectos_EtapaModeloProyectos_IdEtapaModeloProyecto",
                        column: x => x.IdEtapaModeloProyecto,
                        principalSchema: "adm",
                        principalTable: "EtapaModeloProyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProgramaAreas",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IdProyectoTecnico = table.Column<int>(type: "int", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramaAreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramaAreas_DetalleCatalogos_IdEstado",
                        column: x => x.IdEstado,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProgramaAreas_ProyectoTecnicos_IdProyectoTecnico",
                        column: x => x.IdProyectoTecnico,
                        principalSchema: "adm",
                        principalTable: "ProyectoTecnicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RCNinoPatrocinados",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Comunidad = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Patrocinado = table.Column<bool>(type: "bit", nullable: false),
                    IdGrupoEtario = table.Column<int>(type: "int", nullable: false),
                    IdGenero = table.Column<int>(type: "int", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    IdProgramaArea = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RCNinoPatrocinados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RCNinoPatrocinados_DetalleCatalogos_IdEstado",
                        column: x => x.IdEstado,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RCNinoPatrocinados_DetalleCatalogos_IdGenero",
                        column: x => x.IdGenero,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RCNinoPatrocinados_DetalleCatalogos_IdGrupoEtario",
                        column: x => x.IdGrupoEtario,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RCNinoPatrocinados_ProgramaAreas_IdProgramaArea",
                        column: x => x.IdProgramaArea,
                        principalSchema: "adm",
                        principalTable: "ProgramaAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorParticipantes_IdEstado",
                schema: "adm",
                table: "ActorParticipantes",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_EtapaModeloProyectos_IdAccionOperativa",
                schema: "adm",
                table: "EtapaModeloProyectos",
                column: "IdAccionOperativa");

            migrationBuilder.CreateIndex(
                name: "IX_EtapaModeloProyectos_IdEstado",
                schema: "adm",
                table: "EtapaModeloProyectos",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_LogFrames_IdEstado",
                schema: "adm",
                table: "LogFrames",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_LogFrames_IdNivel",
                schema: "adm",
                table: "LogFrames",
                column: "IdNivel");

            migrationBuilder.CreateIndex(
                name: "IX_ModeloProyectos_IdEstado",
                schema: "adm",
                table: "ModeloProyectos",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_ModeloProyectos_IdEtapaModeloProyecto",
                schema: "adm",
                table: "ModeloProyectos",
                column: "IdEtapaModeloProyecto");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramaAreas_IdEstado",
                schema: "adm",
                table: "ProgramaAreas",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramaAreas_IdProyectoTecnico",
                schema: "adm",
                table: "ProgramaAreas",
                column: "IdProyectoTecnico");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoTecnicos_IdEstado",
                schema: "adm",
                table: "ProyectoTecnicos",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoTecnicos_IdFinanciamiento",
                schema: "adm",
                table: "ProyectoTecnicos",
                column: "IdFinanciamiento");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoTecnicos_IdTipoProyecto",
                schema: "adm",
                table: "ProyectoTecnicos",
                column: "IdTipoProyecto");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoTecnicos_IdUbicacion",
                schema: "adm",
                table: "ProyectoTecnicos",
                column: "IdUbicacion");

            migrationBuilder.CreateIndex(
                name: "IX_RCNinoPatrocinados_IdEstado",
                schema: "adm",
                table: "RCNinoPatrocinados",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_RCNinoPatrocinados_IdGenero",
                schema: "adm",
                table: "RCNinoPatrocinados",
                column: "IdGenero");

            migrationBuilder.CreateIndex(
                name: "IX_RCNinoPatrocinados_IdGrupoEtario",
                schema: "adm",
                table: "RCNinoPatrocinados",
                column: "IdGrupoEtario");

            migrationBuilder.CreateIndex(
                name: "IX_RCNinoPatrocinados_IdProgramaArea",
                schema: "adm",
                table: "RCNinoPatrocinados",
                column: "IdProgramaArea");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorParticipantes",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "LogFrames",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "ModeloProyectos",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "RCNinoPatrocinados",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "EtapaModeloProyectos",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "ProgramaAreas",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "ProyectoTecnicos",
                schema: "adm");
        }
    }
}
