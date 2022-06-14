using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class Migration_V2047 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "indicador");

            migrationBuilder.CreateTable(
                name: "FaseProgramaAreas",
                schema: "indicador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaDisenio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaRedisenio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaTransicion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dip1 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Dip2 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Dip3 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Dip4 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Dip5 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Dip6 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IdProgramaArea = table.Column<int>(type: "int", nullable: false),
                    IdProyectoTecnico = table.Column<int>(type: "int", nullable: false),
                    IdFaseProyecto = table.Column<int>(type: "int", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaseProgramaAreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaseProgramaAreas_DetalleCatalogos_IdEstado",
                        column: x => x.IdEstado,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FaseProgramaAreas_DetalleCatalogos_IdFaseProyecto",
                        column: x => x.IdFaseProyecto,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FaseProgramaAreas_ProgramaAreas_IdProgramaArea",
                        column: x => x.IdProgramaArea,
                        principalSchema: "adm",
                        principalTable: "ProgramaAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FaseProgramaAreas_ProyectoTecnicos_IdProyectoTecnico",
                        column: x => x.IdProyectoTecnico,
                        principalSchema: "adm",
                        principalTable: "ProyectoTecnicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "IndicadoresPR",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Asunciones = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    MedioVerificacion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Poblacion = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CWB = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    InclucionRC = table.Column<bool>(type: "bit", nullable: false),
                    IncluyeAdvovacy = table.Column<bool>(type: "bit", nullable: false),
                    IdTarget = table.Column<int>(type: "int", nullable: false),
                    IdFrecuencia = table.Column<int>(type: "int", nullable: false),
                    IdTipoMedida = table.Column<int>(type: "int", nullable: false),
                    IdActorParticipante = table.Column<int>(type: "int", nullable: false),
                    IdRubro = table.Column<int>(type: "int", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicadoresPR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndicadoresPR_ActorParticipantes_IdActorParticipante",
                        column: x => x.IdActorParticipante,
                        principalSchema: "adm",
                        principalTable: "ActorParticipantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_IndicadoresPR_DetalleCatalogos_IdEstado",
                        column: x => x.IdEstado,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_IndicadoresPR_DetalleCatalogos_IdFrecuencia",
                        column: x => x.IdFrecuencia,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_IndicadoresPR_DetalleCatalogos_IdRubro",
                        column: x => x.IdRubro,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_IndicadoresPR_DetalleCatalogos_IdTarget",
                        column: x => x.IdTarget,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_IndicadoresPR_DetalleCatalogos_IdTipoMedida",
                        column: x => x.IdTipoMedida,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OtrosIndicadores",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Asunciones = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IdFrecuencia = table.Column<int>(type: "int", nullable: false),
                    IdTipoIndicador = table.Column<int>(type: "int", nullable: false),
                    IdTipoMedida = table.Column<int>(type: "int", nullable: false),
                    IdActorParticipante = table.Column<int>(type: "int", nullable: false),
                    IdArea = table.Column<int>(type: "int", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtrosIndicadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtrosIndicadores_ActorParticipantes_IdActorParticipante",
                        column: x => x.IdActorParticipante,
                        principalSchema: "adm",
                        principalTable: "ActorParticipantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OtrosIndicadores_DetalleCatalogos_IdArea",
                        column: x => x.IdArea,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OtrosIndicadores_DetalleCatalogos_IdEstado",
                        column: x => x.IdEstado,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OtrosIndicadores_DetalleCatalogos_IdFrecuencia",
                        column: x => x.IdFrecuencia,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OtrosIndicadores_DetalleCatalogos_IdTipoIndicador",
                        column: x => x.IdTipoIndicador,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OtrosIndicadores_DetalleCatalogos_IdTipoMedida",
                        column: x => x.IdTipoMedida,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PresupuestoProyectos",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostoSoporte = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Nomina = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TI = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Administracion = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LineamientosOnAdmistrativos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LineamientosOnOperativos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TechoPresupuestario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdProgramaArea = table.Column<int>(type: "int", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresupuestoProyectos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PresupuestoProyectos_DetalleCatalogos_IdEstado",
                        column: x => x.IdEstado,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PresupuestoProyectos_ProgramaAreas_IdProgramaArea",
                        column: x => x.IdProgramaArea,
                        principalSchema: "adm",
                        principalTable: "ProgramaAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "VinculacionIndicadores",
                schema: "indicador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Riesgos = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PlanNacionalDesarrollo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IdIndicadorPR = table.Column<int>(type: "int", nullable: false),
                    IdOtroIndicador = table.Column<int>(type: "int", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VinculacionIndicadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VinculacionIndicadores_DetalleCatalogos_IdEstado",
                        column: x => x.IdEstado,
                        principalSchema: "adm",
                        principalTable: "DetalleCatalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_VinculacionIndicadores_IndicadoresPR_IdIndicadorPR",
                        column: x => x.IdIndicadorPR,
                        principalSchema: "adm",
                        principalTable: "IndicadoresPR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_VinculacionIndicadores_OtrosIndicadores_IdOtroIndicador",
                        column: x => x.IdOtroIndicador,
                        principalSchema: "adm",
                        principalTable: "OtrosIndicadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FaseProgramaAreas_IdEstado",
                schema: "indicador",
                table: "FaseProgramaAreas",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_FaseProgramaAreas_IdFaseProyecto",
                schema: "indicador",
                table: "FaseProgramaAreas",
                column: "IdFaseProyecto");

            migrationBuilder.CreateIndex(
                name: "IX_FaseProgramaAreas_IdProgramaArea",
                schema: "indicador",
                table: "FaseProgramaAreas",
                column: "IdProgramaArea");

            migrationBuilder.CreateIndex(
                name: "IX_FaseProgramaAreas_IdProyectoTecnico",
                schema: "indicador",
                table: "FaseProgramaAreas",
                column: "IdProyectoTecnico");

            migrationBuilder.CreateIndex(
                name: "IX_IndicadoresPR_IdActorParticipante",
                schema: "adm",
                table: "IndicadoresPR",
                column: "IdActorParticipante");

            migrationBuilder.CreateIndex(
                name: "IX_IndicadoresPR_IdEstado",
                schema: "adm",
                table: "IndicadoresPR",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_IndicadoresPR_IdFrecuencia",
                schema: "adm",
                table: "IndicadoresPR",
                column: "IdFrecuencia");

            migrationBuilder.CreateIndex(
                name: "IX_IndicadoresPR_IdRubro",
                schema: "adm",
                table: "IndicadoresPR",
                column: "IdRubro");

            migrationBuilder.CreateIndex(
                name: "IX_IndicadoresPR_IdTarget",
                schema: "adm",
                table: "IndicadoresPR",
                column: "IdTarget");

            migrationBuilder.CreateIndex(
                name: "IX_IndicadoresPR_IdTipoMedida",
                schema: "adm",
                table: "IndicadoresPR",
                column: "IdTipoMedida");

            migrationBuilder.CreateIndex(
                name: "IX_OtrosIndicadores_IdActorParticipante",
                schema: "adm",
                table: "OtrosIndicadores",
                column: "IdActorParticipante");

            migrationBuilder.CreateIndex(
                name: "IX_OtrosIndicadores_IdArea",
                schema: "adm",
                table: "OtrosIndicadores",
                column: "IdArea");

            migrationBuilder.CreateIndex(
                name: "IX_OtrosIndicadores_IdEstado",
                schema: "adm",
                table: "OtrosIndicadores",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_OtrosIndicadores_IdFrecuencia",
                schema: "adm",
                table: "OtrosIndicadores",
                column: "IdFrecuencia");

            migrationBuilder.CreateIndex(
                name: "IX_OtrosIndicadores_IdTipoIndicador",
                schema: "adm",
                table: "OtrosIndicadores",
                column: "IdTipoIndicador");

            migrationBuilder.CreateIndex(
                name: "IX_OtrosIndicadores_IdTipoMedida",
                schema: "adm",
                table: "OtrosIndicadores",
                column: "IdTipoMedida");

            migrationBuilder.CreateIndex(
                name: "IX_PresupuestoProyectos_IdEstado",
                schema: "adm",
                table: "PresupuestoProyectos",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_PresupuestoProyectos_IdProgramaArea",
                schema: "adm",
                table: "PresupuestoProyectos",
                column: "IdProgramaArea");

            migrationBuilder.CreateIndex(
                name: "IX_VinculacionIndicadores_IdEstado",
                schema: "indicador",
                table: "VinculacionIndicadores",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_VinculacionIndicadores_IdIndicadorPR",
                schema: "indicador",
                table: "VinculacionIndicadores",
                column: "IdIndicadorPR");

            migrationBuilder.CreateIndex(
                name: "IX_VinculacionIndicadores_IdOtroIndicador",
                schema: "indicador",
                table: "VinculacionIndicadores",
                column: "IdOtroIndicador");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FaseProgramaAreas",
                schema: "indicador");

            migrationBuilder.DropTable(
                name: "PresupuestoProyectos",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "VinculacionIndicadores",
                schema: "indicador");

            migrationBuilder.DropTable(
                name: "IndicadoresPR",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "OtrosIndicadores",
                schema: "adm");
        }
    }
}
