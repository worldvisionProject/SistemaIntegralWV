using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev1
{
    public partial class MigrationV03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndicadorCicloEstrategico_EstrategiaNacionales_IdIndicadorCiclo",
                table: "IndicadorCicloEstrategico");

            migrationBuilder.DropIndex(
                name: "IX_IndicadorCicloEstrategico_IdIndicadorCiclo",
                table: "IndicadorCicloEstrategico");

            migrationBuilder.DropColumn(
                name: "IdEmpresa",
                table: "MetaCicloEstrategico");

            migrationBuilder.DropColumn(
                name: "IdIndicadorCiclo",
                table: "IndicadorCicloEstrategico");

            migrationBuilder.RenameTable(
                name: "MetaCicloEstrategico",
                newName: "MetaCicloEstrategico",
                newSchema: "planifica");

            migrationBuilder.RenameTable(
                name: "IndicadorCicloEstrategico",
                newName: "IndicadorCicloEstrategico",
                newSchema: "planifica");

            migrationBuilder.CreateIndex(
                name: "IX_IndicadorCicloEstrategico_IdEstrategia",
                schema: "planifica",
                table: "IndicadorCicloEstrategico",
                column: "IdEstrategia");

            migrationBuilder.AddForeignKey(
                name: "FK_IndicadorCicloEstrategico_EstrategiaNacionales_IdEstrategia",
                schema: "planifica",
                table: "IndicadorCicloEstrategico",
                column: "IdEstrategia",
                principalSchema: "planifica",
                principalTable: "EstrategiaNacionales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndicadorCicloEstrategico_EstrategiaNacionales_IdEstrategia",
                schema: "planifica",
                table: "IndicadorCicloEstrategico");

            migrationBuilder.DropIndex(
                name: "IX_IndicadorCicloEstrategico_IdEstrategia",
                schema: "planifica",
                table: "IndicadorCicloEstrategico");

            migrationBuilder.RenameTable(
                name: "MetaCicloEstrategico",
                schema: "planifica",
                newName: "MetaCicloEstrategico");

            migrationBuilder.RenameTable(
                name: "IndicadorCicloEstrategico",
                schema: "planifica",
                newName: "IndicadorCicloEstrategico");

            migrationBuilder.AddColumn<decimal>(
                name: "IdEmpresa",
                table: "MetaCicloEstrategico",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdIndicadorCiclo",
                table: "IndicadorCicloEstrategico",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IndicadorCicloEstrategico_IdIndicadorCiclo",
                table: "IndicadorCicloEstrategico",
                column: "IdIndicadorCiclo");

            migrationBuilder.AddForeignKey(
                name: "FK_IndicadorCicloEstrategico_EstrategiaNacionales_IdIndicadorCiclo",
                table: "IndicadorCicloEstrategico",
                column: "IdIndicadorCiclo",
                principalSchema: "planifica",
                principalTable: "EstrategiaNacionales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
