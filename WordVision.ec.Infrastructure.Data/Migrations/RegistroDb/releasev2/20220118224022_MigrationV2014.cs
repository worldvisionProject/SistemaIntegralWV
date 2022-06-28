using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class MigrationV2014 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdResponsabilidad",
                schema: "valoracion",
                table: "Responsabilidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Padre",
                schema: "valoracion",
                table: "Responsabilidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "IdCompetencia",
                schema: "valoracion",
                table: "Competencias",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "NombreCompetencia",
                schema: "valoracion",
                table: "Competencias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Padre",
                schema: "valoracion",
                table: "Competencias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdResponsabilidad",
                schema: "valoracion",
                table: "Responsabilidades");

            migrationBuilder.DropColumn(
                name: "Padre",
                schema: "valoracion",
                table: "Responsabilidades");

            migrationBuilder.DropColumn(
                name: "NombreCompetencia",
                schema: "valoracion",
                table: "Competencias");

            migrationBuilder.DropColumn(
                name: "Padre",
                schema: "valoracion",
                table: "Competencias");

            migrationBuilder.AlterColumn<string>(
                name: "IdCompetencia",
                schema: "valoracion",
                table: "Competencias",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
