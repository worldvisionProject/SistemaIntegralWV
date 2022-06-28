using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class MigrationV2040 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeguimientoObjetivos_PlanificacionResultados_IdPlanificacion",
                schema: "valoracion",
                table: "SeguimientoObjetivos");

            migrationBuilder.DropIndex(
                name: "IX_SeguimientoObjetivos_IdPlanificacion",
                schema: "valoracion",
                table: "SeguimientoObjetivos");

            migrationBuilder.RenameColumn(
                name: "IdPlanificacion",
                schema: "valoracion",
                table: "SeguimientoObjetivos",
                newName: "IdColaborador");

            migrationBuilder.AddColumn<int>(
                name: "AnioFiscal",
                schema: "valoracion",
                table: "SeguimientoObjetivos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnioFiscal",
                schema: "valoracion",
                table: "SeguimientoObjetivos");

            migrationBuilder.RenameColumn(
                name: "IdColaborador",
                schema: "valoracion",
                table: "SeguimientoObjetivos",
                newName: "IdPlanificacion");

            migrationBuilder.CreateIndex(
                name: "IX_SeguimientoObjetivos_IdPlanificacion",
                schema: "valoracion",
                table: "SeguimientoObjetivos",
                column: "IdPlanificacion");

            migrationBuilder.AddForeignKey(
                name: "FK_SeguimientoObjetivos_PlanificacionResultados_IdPlanificacion",
                schema: "valoracion",
                table: "SeguimientoObjetivos",
                column: "IdPlanificacion",
                principalSchema: "valoracion",
                principalTable: "PlanificacionResultados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
