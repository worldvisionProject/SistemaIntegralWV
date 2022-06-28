using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class MigrationV206 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resultados_ObjetivoAnioFiscales_IdResultado",
                schema: "valoracion",
                table: "Resultados");

            migrationBuilder.AlterColumn<int>(
                name: "IdResultado",
                schema: "valoracion",
                table: "Resultados",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdObjetivoAnioFiscal",
                schema: "valoracion",
                table: "Resultados",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "FK_Resultados_ObjetivoAnioFiscales_IdResultado",
                schema: "valoracion",
                table: "Resultados");

            migrationBuilder.DropColumn(
                name: "IdObjetivoAnioFiscal",
                schema: "valoracion",
                table: "Resultados");

            migrationBuilder.AlterColumn<int>(
                name: "IdResultado",
                schema: "valoracion",
                table: "Resultados",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Resultados_ObjetivoAnioFiscales_IdResultado",
                schema: "valoracion",
                table: "Resultados",
                column: "IdResultado",
                principalSchema: "valoracion",
                principalTable: "ObjetivoAnioFiscales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
