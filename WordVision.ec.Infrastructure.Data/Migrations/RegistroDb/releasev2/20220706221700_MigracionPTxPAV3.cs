using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class MigracionPTxPAV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProyectoTecnicoPorProgramaAreas_LogFrameIndicadoresPR_LogFrameIndicadorPRId",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas");

            migrationBuilder.DropIndex(
                name: "IX_ProyectoTecnicoPorProgramaAreas_LogFrameIndicadorPRId",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas");

            migrationBuilder.DropColumn(
                name: "LogFrameIndicadorPRId",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoTecnicoPorProgramaAreas_IdLogFrameIndicadorPR",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas",
                column: "IdLogFrameIndicadorPR");

            migrationBuilder.AddForeignKey(
                name: "FK_ProyectoTecnicoPorProgramaAreas_LogFrameIndicadoresPR_IdLogFrameIndicadorPR",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas",
                column: "IdLogFrameIndicadorPR",
                principalSchema: "adm",
                principalTable: "LogFrameIndicadoresPR",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProyectoTecnicoPorProgramaAreas_LogFrameIndicadoresPR_IdLogFrameIndicadorPR",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas");

            migrationBuilder.DropIndex(
                name: "IX_ProyectoTecnicoPorProgramaAreas_IdLogFrameIndicadorPR",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas");

            migrationBuilder.AddColumn<int>(
                name: "LogFrameIndicadorPRId",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoTecnicoPorProgramaAreas_LogFrameIndicadorPRId",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas",
                column: "LogFrameIndicadorPRId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProyectoTecnicoPorProgramaAreas_LogFrameIndicadoresPR_LogFrameIndicadorPRId",
                schema: "indicador",
                table: "ProyectoTecnicoPorProgramaAreas",
                column: "LogFrameIndicadorPRId",
                principalSchema: "adm",
                principalTable: "LogFrameIndicadoresPR",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
