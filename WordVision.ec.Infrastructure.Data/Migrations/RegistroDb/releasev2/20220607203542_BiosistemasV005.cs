using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class BiosistemasV005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EReporteTabulados",
                schema: "survey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rta_nombre_indicador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rta_tipo_indicador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rta_nombre_pa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rta_numerador = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    rta_denominador = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    rta_porcentaje = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    rta_resultado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EEvaluacionId = table.Column<int>(type: "int", nullable: true),
                    EProgramaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EIndicadorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ERegionId = table.Column<int>(type: "int", nullable: true),
                    EProvinciaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ECantonId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EReporteTabulados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EReporteTabulados_ECantones_ECantonId",
                        column: x => x.ECantonId,
                        principalSchema: "survey",
                        principalTable: "ECantones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EReporteTabulados_EEvaluaciones_EEvaluacionId",
                        column: x => x.EEvaluacionId,
                        principalSchema: "survey",
                        principalTable: "EEvaluaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EReporteTabulados_EIndicadores_EIndicadorId",
                        column: x => x.EIndicadorId,
                        principalSchema: "survey",
                        principalTable: "EIndicadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EReporteTabulados_EProgramas_EProgramaId",
                        column: x => x.EProgramaId,
                        principalSchema: "survey",
                        principalTable: "EProgramas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EReporteTabulados_EProvincias_EProvinciaId",
                        column: x => x.EProvinciaId,
                        principalSchema: "survey",
                        principalTable: "EProvincias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EReporteTabulados_ERegiones_ERegionId",
                        column: x => x.ERegionId,
                        principalSchema: "survey",
                        principalTable: "ERegiones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EReporteTabulados_ECantonId",
                schema: "survey",
                table: "EReporteTabulados",
                column: "ECantonId");

            migrationBuilder.CreateIndex(
                name: "IX_EReporteTabulados_EEvaluacionId",
                schema: "survey",
                table: "EReporteTabulados",
                column: "EEvaluacionId");

            migrationBuilder.CreateIndex(
                name: "IX_EReporteTabulados_EIndicadorId",
                schema: "survey",
                table: "EReporteTabulados",
                column: "EIndicadorId");

            migrationBuilder.CreateIndex(
                name: "IX_EReporteTabulados_EProgramaId",
                schema: "survey",
                table: "EReporteTabulados",
                column: "EProgramaId");

            migrationBuilder.CreateIndex(
                name: "IX_EReporteTabulados_EProvinciaId",
                schema: "survey",
                table: "EReporteTabulados",
                column: "EProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_EReporteTabulados_ERegionId",
                schema: "survey",
                table: "EReporteTabulados",
                column: "ERegionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EReporteTabulados",
                schema: "survey");
        }
    }
}
