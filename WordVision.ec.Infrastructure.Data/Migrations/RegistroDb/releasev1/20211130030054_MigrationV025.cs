using Microsoft.EntityFrameworkCore.Migrations;

namespace WordVision.ec.Infrastructure.Data.Migrations.RegistroDb.releasev1
{
    public partial class MigrationV025 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ComentarioActualizacion",
                schema: "soporte",
                table: "Donantes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComentarioActualizacion",
                schema: "soporte",
                table: "Donantes");
        }
    }
}
