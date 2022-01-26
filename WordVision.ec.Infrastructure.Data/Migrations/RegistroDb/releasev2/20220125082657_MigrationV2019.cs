using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class MigrationV2019 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                schema: "valoracion",
                table: "Resultados",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EsObligatorio",
                schema: "valoracion",
                table: "Resultados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                schema: "valoracion",
                table: "Responsabilidades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EsObligatorio",
                schema: "valoracion",
                table: "Responsabilidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                schema: "valoracion",
                table: "Competencias",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EsObligatorio",
                schema: "valoracion",
                table: "Competencias",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                schema: "valoracion",
                table: "Resultados");

            migrationBuilder.DropColumn(
                name: "EsObligatorio",
                schema: "valoracion",
                table: "Resultados");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                schema: "valoracion",
                table: "Responsabilidades");

            migrationBuilder.DropColumn(
                name: "EsObligatorio",
                schema: "valoracion",
                table: "Responsabilidades");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                schema: "valoracion",
                table: "Competencias");

            migrationBuilder.DropColumn(
                name: "EsObligatorio",
                schema: "valoracion",
                table: "Competencias");
        }
    }
}
