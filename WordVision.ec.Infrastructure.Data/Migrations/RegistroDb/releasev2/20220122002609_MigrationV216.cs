using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class MigrationV216 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanificacionResultados_Resultados_IdResultado",
                schema: "valoracion",
                table: "PlanificacionResultados");

            migrationBuilder.DropIndex(
                name: "IX_PlanificacionResultados_IdResultado",
                schema: "valoracion",
                table: "PlanificacionResultados");

            migrationBuilder.DropColumn(
                name: "TipoObjetivo",
                schema: "valoracion",
                table: "Resultados");

            migrationBuilder.AddColumn<int>(
                name: "IdObjetivoAnioFiscal",
                schema: "valoracion",
                table: "PlanificacionResultados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoObjetivo",
                schema: "valoracion",
                table: "PlanificacionResultados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PlanificacionResultados_IdObjetivoAnioFiscal",
                schema: "valoracion",
                table: "PlanificacionResultados",
                column: "IdObjetivoAnioFiscal");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanificacionResultados_ObjetivoAnioFiscales_IdObjetivoAnioFiscal",
                schema: "valoracion",
                table: "PlanificacionResultados",
                column: "IdObjetivoAnioFiscal",
                principalSchema: "valoracion",
                principalTable: "ObjetivoAnioFiscales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanificacionResultados_ObjetivoAnioFiscales_IdObjetivoAnioFiscal",
                schema: "valoracion",
                table: "PlanificacionResultados");

            migrationBuilder.DropIndex(
                name: "IX_PlanificacionResultados_IdObjetivoAnioFiscal",
                schema: "valoracion",
                table: "PlanificacionResultados");

            migrationBuilder.DropColumn(
                name: "IdObjetivoAnioFiscal",
                schema: "valoracion",
                table: "PlanificacionResultados");

            migrationBuilder.DropColumn(
                name: "TipoObjetivo",
                schema: "valoracion",
                table: "PlanificacionResultados");

            migrationBuilder.AddColumn<int>(
                name: "TipoObjetivo",
                schema: "valoracion",
                table: "Resultados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PlanificacionResultados_IdResultado",
                schema: "valoracion",
                table: "PlanificacionResultados",
                column: "IdResultado");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanificacionResultados_Resultados_IdResultado",
                schema: "valoracion",
                table: "PlanificacionResultados",
                column: "IdResultado",
                principalSchema: "valoracion",
                principalTable: "Resultados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
