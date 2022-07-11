using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class MigracionPTxPAV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProyectoTecnicoPorProgramaAreas",
                schema: "indicador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLogFrameIndicadorPR = table.Column<int>(type: "int", nullable: false),
                    LogFrameIndicadorPRId = table.Column<int>(type: "int", nullable: true),
                    Asignado = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProyectoTecnicoPorProgramaAreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProyectoTecnicoPorProgramaAreas_LogFrameIndicadoresPR_LogFrameIndicadorPRId",
                        column: x => x.LogFrameIndicadorPRId,
                        principalSchema: "adm",
                        principalTable: "LogFrameIndicadoresPR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoTecnicoPorProgramaAreas_LogFrameIndicadorPRId",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas",
                column: "LogFrameIndicadorPRId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProyectoTecnicoPorProgramaAreas",
                schema: "indicador");
        }
    }
}
