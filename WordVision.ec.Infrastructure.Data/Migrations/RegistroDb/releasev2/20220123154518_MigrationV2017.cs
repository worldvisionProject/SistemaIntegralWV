using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class MigrationV2017 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Maximo",
                schema: "valoracion",
                table: "ObjetivoAnioFiscales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Minimo",
                schema: "valoracion",
                table: "ObjetivoAnioFiscales",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Maximo",
                schema: "valoracion",
                table: "ObjetivoAnioFiscales");

            migrationBuilder.DropColumn(
                name: "Minimo",
                schema: "valoracion",
                table: "ObjetivoAnioFiscales");
        }
    }
}
