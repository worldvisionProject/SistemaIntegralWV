using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class BiosistemasV007 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EObjetivoId",
                schema: "survey",
                table: "EIndicadores",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ind_proyecto",
                schema: "survey",
                table: "EIndicadores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ind_tipo",
                schema: "survey",
                table: "EIndicadores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "EMetas",
                schema: "survey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    met_valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EEvaluacionId = table.Column<int>(type: "int", nullable: false),
                    EIndicadorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EProgramaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMetas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EMetas_EEvaluaciones_EEvaluacionId",
                        column: x => x.EEvaluacionId,
                        principalSchema: "survey",
                        principalTable: "EEvaluaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EMetas_EIndicadores_EIndicadorId",
                        column: x => x.EIndicadorId,
                        principalSchema: "survey",
                        principalTable: "EIndicadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EMetas_EProgramas_EProgramaId",
                        column: x => x.EProgramaId,
                        principalSchema: "survey",
                        principalTable: "EProgramas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EObjetivos",
                schema: "survey",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    obj_Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EObjetivos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ETabulado",
                columns: table => new
                {
                    CodigoIndicador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoPA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Indicador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoIndicador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTotal = table.Column<int>(type: "int", nullable: false),
                    EntrevistadosTotal = table.Column<int>(type: "int", nullable: false),
                    Porcentaje = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Result = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CodigoRegion = table.Column<int>(type: "int", nullable: false),
                    CodigoProvincia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoCanton = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateIndex(
                name: "IX_EIndicadores_EObjetivoId",
                schema: "survey",
                table: "EIndicadores",
                column: "EObjetivoId");

            migrationBuilder.CreateIndex(
                name: "IX_EMetas_EEvaluacionId",
                schema: "survey",
                table: "EMetas",
                column: "EEvaluacionId");

            migrationBuilder.CreateIndex(
                name: "IX_EMetas_EIndicadorId",
                schema: "survey",
                table: "EMetas",
                column: "EIndicadorId");

            migrationBuilder.CreateIndex(
                name: "IX_EMetas_EProgramaId",
                schema: "survey",
                table: "EMetas",
                column: "EProgramaId");

            migrationBuilder.AddForeignKey(
                name: "FK_EIndicadores_EObjetivos_EObjetivoId",
                schema: "survey",
                table: "EIndicadores",
                column: "EObjetivoId",
                principalSchema: "survey",
                principalTable: "EObjetivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EIndicadores_EObjetivos_EObjetivoId",
                schema: "survey",
                table: "EIndicadores");

            migrationBuilder.DropTable(
                name: "EMetas",
                schema: "survey");

            migrationBuilder.DropTable(
                name: "EObjetivos",
                schema: "survey");

            migrationBuilder.DropTable(
                name: "ETabulado");

            migrationBuilder.DropIndex(
                name: "IX_EIndicadores_EObjetivoId",
                schema: "survey",
                table: "EIndicadores");

            migrationBuilder.DropColumn(
                name: "EObjetivoId",
                schema: "survey",
                table: "EIndicadores");

            migrationBuilder.DropColumn(
                name: "ind_proyecto",
                schema: "survey",
                table: "EIndicadores");

            migrationBuilder.DropColumn(
                name: "ind_tipo",
                schema: "survey",
                table: "EIndicadores");
        }
    }
}
