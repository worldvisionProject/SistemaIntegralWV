using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class MigrationV2036 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IndicadorVinculadoCE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoIndicador = table.Column<int>(type: "int", nullable: false),
                    CodigoIndicador = table.Column<int>(type: "int", nullable: false),
                    UnidadMedida = table.Column<int>(type: "int", nullable: false),
                    ActorParticipante = table.Column<int>(type: "int", nullable: false),
                    IdIndicadorCicloEstrategico = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicadorVinculadoCE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndicadorVinculadoCE_IndicadorCicloEstrategico_IdIndicadorCicloEstrategico",
                        column: x => x.IdIndicadorCicloEstrategico,
                        principalSchema: "planifica",
                        principalTable: "IndicadorCicloEstrategico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndicadorVinculadoE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoIndicador = table.Column<int>(type: "int", nullable: false),
                    CodigoIndicador = table.Column<int>(type: "int", nullable: false),
                    UnidadMedida = table.Column<int>(type: "int", nullable: false),
                    ActorParticipante = table.Column<int>(type: "int", nullable: false),
                    IdIndicadorEstrategico = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicadorVinculadoE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndicadorVinculadoE_IndicadorEstrategicos_IdIndicadorEstrategico",
                        column: x => x.IdIndicadorEstrategico,
                        principalSchema: "planifica",
                        principalTable: "IndicadorEstrategicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndicadorVinculadoPO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoIndicador = table.Column<int>(type: "int", nullable: false),
                    CodigoIndicador = table.Column<int>(type: "int", nullable: false),
                    UnidadMedida = table.Column<int>(type: "int", nullable: false),
                    ActorParticipante = table.Column<int>(type: "int", nullable: false),
                    IdIndicadorProductoObjetivo = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicadorVinculadoPO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndicadorVinculadoPO_IndicadorProductoObjetivos_IdIndicadorProductoObjetivo",
                        column: x => x.IdIndicadorProductoObjetivo,
                        principalSchema: "planifica",
                        principalTable: "IndicadorProductoObjetivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndicadorVinculadoPOA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoIndicador = table.Column<int>(type: "int", nullable: false),
                    CodigoIndicador = table.Column<int>(type: "int", nullable: false),
                    UnidadMedida = table.Column<int>(type: "int", nullable: false),
                    ActorParticipante = table.Column<int>(type: "int", nullable: false),
                    IdIndicadorPOA = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicadorVinculadoPOA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndicadorVinculadoPOA_IndicadorPOAs_IdIndicadorPOA",
                        column: x => x.IdIndicadorPOA,
                        principalSchema: "planifica",
                        principalTable: "IndicadorPOAs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndicadorVinculadoCE_IdIndicadorCicloEstrategico",
                table: "IndicadorVinculadoCE",
                column: "IdIndicadorCicloEstrategico");

            migrationBuilder.CreateIndex(
                name: "IX_IndicadorVinculadoE_IdIndicadorEstrategico",
                table: "IndicadorVinculadoE",
                column: "IdIndicadorEstrategico");

            migrationBuilder.CreateIndex(
                name: "IX_IndicadorVinculadoPO_IdIndicadorProductoObjetivo",
                table: "IndicadorVinculadoPO",
                column: "IdIndicadorProductoObjetivo");

            migrationBuilder.CreateIndex(
                name: "IX_IndicadorVinculadoPOA_IdIndicadorPOA",
                table: "IndicadorVinculadoPOA",
                column: "IdIndicadorPOA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndicadorVinculadoCE");

            migrationBuilder.DropTable(
                name: "IndicadorVinculadoE");

            migrationBuilder.DropTable(
                name: "IndicadorVinculadoPO");

            migrationBuilder.DropTable(
                name: "IndicadorVinculadoPOA");
        }
    }
}
