using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class MigrationV2057 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleVinculacionIndicador_IndicadoresPR_IdIndicadorPR",
                schema: "indicador",
                table: "DetalleVinculacionIndicador");

            migrationBuilder.DropIndex(
                name: "IX_DetalleVinculacionIndicador_IdIndicadorPR",
                schema: "indicador",
                table: "DetalleVinculacionIndicador");

            migrationBuilder.DropColumn(
                name: "IdIndicadorPR",
                schema: "indicador",
                table: "DetalleVinculacionIndicador");

            migrationBuilder.AddColumn<int>(
                name: "IdIndicadorPR",
                schema: "indicador",
                table: "VinculacionIndicadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VinculacionIndicadores_IdIndicadorPR",
                schema: "indicador",
                table: "VinculacionIndicadores",
                column: "IdIndicadorPR");

            migrationBuilder.AddForeignKey(
                name: "FK_VinculacionIndicadores_IndicadoresPR_IdIndicadorPR",
                schema: "indicador",
                table: "VinculacionIndicadores",
                column: "IdIndicadorPR",
                principalSchema: "adm",
                principalTable: "IndicadoresPR",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VinculacionIndicadores_IndicadoresPR_IdIndicadorPR",
                schema: "indicador",
                table: "VinculacionIndicadores");

            migrationBuilder.DropIndex(
                name: "IX_VinculacionIndicadores_IdIndicadorPR",
                schema: "indicador",
                table: "VinculacionIndicadores");

            migrationBuilder.DropColumn(
                name: "IdIndicadorPR",
                schema: "indicador",
                table: "VinculacionIndicadores");

            migrationBuilder.AddColumn<int>(
                name: "IdIndicadorPR",
                schema: "indicador",
                table: "DetalleVinculacionIndicador",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVinculacionIndicador_IdIndicadorPR",
                schema: "indicador",
                table: "DetalleVinculacionIndicador",
                column: "IdIndicadorPR");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleVinculacionIndicador_IndicadoresPR_IdIndicadorPR",
                schema: "indicador",
                table: "DetalleVinculacionIndicador",
                column: "IdIndicadorPR",
                principalSchema: "adm",
                principalTable: "IndicadoresPR",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
