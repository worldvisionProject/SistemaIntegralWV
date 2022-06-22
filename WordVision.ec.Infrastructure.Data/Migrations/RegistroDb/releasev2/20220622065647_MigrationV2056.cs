using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class MigrationV2056 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetalleVinculacionIndicador",
                schema: "indicador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVinculacionIndicador = table.Column<int>(type: "int", nullable: false),
                    IdIndicadorPR = table.Column<int>(type: "int", nullable: false),
                    IdOtroIndicador = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleVinculacionIndicador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleVinculacionIndicador_IndicadoresPR_IdIndicadorPR",
                        column: x => x.IdIndicadorPR,
                        principalSchema: "adm",
                        principalTable: "IndicadoresPR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleVinculacionIndicador_OtrosIndicadores_IdOtroIndicador",
                        column: x => x.IdOtroIndicador,
                        principalSchema: "adm",
                        principalTable: "OtrosIndicadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleVinculacionIndicador_VinculacionIndicadores_IdVinculacionIndicador",
                        column: x => x.IdVinculacionIndicador,
                        principalSchema: "indicador",
                        principalTable: "VinculacionIndicadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVinculacionIndicador_IdIndicadorPR",
                schema: "indicador",
                table: "DetalleVinculacionIndicador",
                column: "IdIndicadorPR");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVinculacionIndicador_IdOtroIndicador",
                schema: "indicador",
                table: "DetalleVinculacionIndicador",
                column: "IdOtroIndicador");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVinculacionIndicador_IdVinculacionIndicador",
                schema: "indicador",
                table: "DetalleVinculacionIndicador",
                column: "IdVinculacionIndicador");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleVinculacionIndicador",
                schema: "indicador");
        }
    }
}
