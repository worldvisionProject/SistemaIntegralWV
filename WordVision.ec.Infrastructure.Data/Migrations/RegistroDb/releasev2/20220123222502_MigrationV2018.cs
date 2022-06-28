using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class MigrationV2018 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdObjetivoAnioFiscal",
                schema: "valoracion",
                table: "Responsabilidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Responsabilidades_IdObjetivoAnioFiscal",
                schema: "valoracion",
                table: "Responsabilidades",
                column: "IdObjetivoAnioFiscal");

            migrationBuilder.AddForeignKey(
                name: "FK_Responsabilidades_ObjetivoAnioFiscales_IdObjetivoAnioFiscal",
                schema: "valoracion",
                table: "Responsabilidades",
                column: "IdObjetivoAnioFiscal",
                principalSchema: "valoracion",
                principalTable: "ObjetivoAnioFiscales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responsabilidades_ObjetivoAnioFiscales_IdObjetivoAnioFiscal",
                schema: "valoracion",
                table: "Responsabilidades");

            migrationBuilder.DropIndex(
                name: "IX_Responsabilidades_IdObjetivoAnioFiscal",
                schema: "valoracion",
                table: "Responsabilidades");

            migrationBuilder.DropColumn(
                name: "IdObjetivoAnioFiscal",
                schema: "valoracion",
                table: "Responsabilidades");
        }
    }
}
