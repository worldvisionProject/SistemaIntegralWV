using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class MigrationV202 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responsabilidad_Objetivos_IdObjetivo",
                table: "Responsabilidad");

            migrationBuilder.DropForeignKey(
                name: "FK_Resultados_ObjetivoAnioFiscales_ObjetivoAnioFiscalesId",
                schema: "valoracion",
                table: "Resultados");

            migrationBuilder.RenameColumn(
                name: "ObjetivoAnioFiscalesId",
                schema: "valoracion",
                table: "Resultados",
                newName: "IdResultado");

            migrationBuilder.RenameIndex(
                name: "IX_Resultados_ObjetivoAnioFiscalesId",
                schema: "valoracion",
                table: "Resultados",
                newName: "IX_Resultados_IdResultado");

            migrationBuilder.RenameColumn(
                name: "IdObjetivo",
                table: "Responsabilidad",
                newName: "IdResponsabilidad");

            migrationBuilder.RenameIndex(
                name: "IX_Responsabilidad_IdObjetivo",
                table: "Responsabilidad",
                newName: "IX_Responsabilidad_IdResponsabilidad");

            migrationBuilder.AddColumn<int>(
                name: "IdObjetivoAnioFiscal",
                schema: "valoracion",
                table: "Resultados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Responsabilidad_Objetivos_IdResponsabilidad",
                table: "Responsabilidad",
                column: "IdResponsabilidad",
                principalSchema: "valoracion",
                principalTable: "Objetivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responsabilidad_Objetivos_IdResponsabilidad",
                table: "Responsabilidad");

            migrationBuilder.DropForeignKey(
                name: "FK_Resultados_ObjetivoAnioFiscales_IdResultado",
                schema: "valoracion",
                table: "Resultados");

            migrationBuilder.DropColumn(
                name: "IdObjetivoAnioFiscal",
                schema: "valoracion",
                table: "Resultados");

            migrationBuilder.RenameColumn(
                name: "IdResultado",
                schema: "valoracion",
                table: "Resultados",
                newName: "ObjetivoAnioFiscalesId");

            migrationBuilder.RenameIndex(
                name: "IX_Resultados_IdResultado",
                schema: "valoracion",
                table: "Resultados",
                newName: "IX_Resultados_ObjetivoAnioFiscalesId");

            migrationBuilder.RenameColumn(
                name: "IdResponsabilidad",
                table: "Responsabilidad",
                newName: "IdObjetivo");

            migrationBuilder.RenameIndex(
                name: "IX_Responsabilidad_IdResponsabilidad",
                table: "Responsabilidad",
                newName: "IX_Responsabilidad_IdObjetivo");

            migrationBuilder.AddForeignKey(
                name: "FK_Responsabilidad_Objetivos_IdObjetivo",
                table: "Responsabilidad",
                column: "IdObjetivo",
                principalSchema: "valoracion",
                principalTable: "Objetivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Resultados_ObjetivoAnioFiscales_ObjetivoAnioFiscalesId",
                schema: "valoracion",
                table: "Resultados",
                column: "ObjetivoAnioFiscalesId",
                principalSchema: "valoracion",
                principalTable: "ObjetivoAnioFiscales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
