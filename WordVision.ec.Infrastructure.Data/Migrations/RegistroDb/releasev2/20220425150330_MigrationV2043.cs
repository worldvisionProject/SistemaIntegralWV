using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev2
{
    public partial class MigrationV2043 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ComentarioColaborador",
                schema: "valoracion",
                table: "SeguimientoObjetivos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComentarioLider1",
                schema: "valoracion",
                table: "SeguimientoObjetivos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComentarioLider2",
                schema: "valoracion",
                table: "SeguimientoObjetivos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComentarioLiderMatricial",
                schema: "valoracion",
                table: "SeguimientoObjetivos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorValoracionFinal",
                schema: "valoracion",
                table: "SeguimientoObjetivos",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValoracionFinal",
                schema: "valoracion",
                table: "SeguimientoObjetivos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValoracionLider1",
                schema: "valoracion",
                table: "SeguimientoObjetivos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComentarioColaborador",
                schema: "valoracion",
                table: "SeguimientoObjetivos");

            migrationBuilder.DropColumn(
                name: "ComentarioLider1",
                schema: "valoracion",
                table: "SeguimientoObjetivos");

            migrationBuilder.DropColumn(
                name: "ComentarioLider2",
                schema: "valoracion",
                table: "SeguimientoObjetivos");

            migrationBuilder.DropColumn(
                name: "ComentarioLiderMatricial",
                schema: "valoracion",
                table: "SeguimientoObjetivos");

            migrationBuilder.DropColumn(
                name: "ValorValoracionFinal",
                schema: "valoracion",
                table: "SeguimientoObjetivos");

            migrationBuilder.DropColumn(
                name: "ValoracionFinal",
                schema: "valoracion",
                table: "SeguimientoObjetivos");

            migrationBuilder.DropColumn(
                name: "ValoracionLider1",
                schema: "valoracion",
                table: "SeguimientoObjetivos");
        }
    }
}
