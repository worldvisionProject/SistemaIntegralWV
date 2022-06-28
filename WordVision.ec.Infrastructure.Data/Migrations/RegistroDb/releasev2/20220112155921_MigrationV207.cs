using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class MigrationV207 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resultados_ObjetivoAnioFiscales_IdResultado",
                schema: "valoracion",
                table: "Resultados");

            migrationBuilder.DropIndex(
                name: "IX_Resultados_IdResultado",
                schema: "valoracion",
                table: "Resultados");

            migrationBuilder.DropColumn(
                name: "IdResultado",
                schema: "valoracion",
                table: "Resultados");

            migrationBuilder.CreateIndex(
                name: "IX_Resultados_IdObjetivoAnioFiscal",
                schema: "valoracion",
                table: "Resultados",
                column: "IdObjetivoAnioFiscal");

            migrationBuilder.AddForeignKey(
                name: "FK_Resultados_ObjetivoAnioFiscales_IdObjetivoAnioFiscal",
                schema: "valoracion",
                table: "Resultados",
                column: "IdObjetivoAnioFiscal",
                principalSchema: "valoracion",
                principalTable: "ObjetivoAnioFiscales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resultados_ObjetivoAnioFiscales_IdObjetivoAnioFiscal",
                schema: "valoracion",
                table: "Resultados");

            migrationBuilder.DropIndex(
                name: "IX_Resultados_IdObjetivoAnioFiscal",
                schema: "valoracion",
                table: "Resultados");

            migrationBuilder.AddColumn<int>(
                name: "IdResultado",
                schema: "valoracion",
                table: "Resultados",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resultados_IdResultado",
                schema: "valoracion",
                table: "Resultados",
                column: "IdResultado");

            migrationBuilder.AddForeignKey(
                name: "FK_Resultados_ObjetivoAnioFiscales_IdResultado",
                schema: "valoracion",
                table: "Resultados",
                column: "IdResultado",
                principalSchema: "valoracion",
                principalTable: "ObjetivoAnioFiscales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
